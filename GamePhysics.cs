using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class GamePhysics
    {
        List<IGameObject> gameObjects = new List<IGameObject>();

        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        public List<IGameObject> GetCollisions(BilliardBall billiardBall)
        {
            List<IGameObject> collisions = new List<IGameObject>();

            foreach (var gameObject in gameObjects)
            {
                if (CheckCollision(billiardBall, gameObject))
                {
                    collisions.Add(gameObject);
                }
            }

            return collisions;
        }
        public bool CheckCollision(BilliardBall billiardBall, IGameObject other)
        {
            if (other is UnmovableLine line)
            {
                double dx = line.End.X - line.Start.X;
                double dy = line.End.Y - line.Start.Y;
                double lengthSquared = dx * dx + dy * dy;
                double t = ((billiardBall.Position.X - line.Start.X) * dx + (billiardBall.Position.Y - line.Start.Y) * dy) / lengthSquared;
                t = Math.Max(0, Math.Min(1, t));
                double closestX = line.Start.X + t * dx;
                double closestY = line.Start.Y + t * dy;

                double distanceSquared = (billiardBall.Position.X - closestX) * (billiardBall.Position.X - closestX) + (billiardBall.Position.Y - closestY) * (billiardBall.Position.Y - closestY);
                return distanceSquared <= (billiardBall.Radius * billiardBall.Radius);
            }
            else if (other is BilliardBall otherBall)
            {
                double dx = billiardBall.Position.X - otherBall.Position.X;
                double dy = billiardBall.Position.Y - otherBall.Position.Y;
                double distanceSquared = dx * dx + dy * dy;
                double radiusSum = billiardBall.Radius + otherBall.Radius;
                return distanceSquared <= (radiusSum * radiusSum);
            }
            else
            {
                throw new InvalidOperationException("Unsupported game object type.");
            }
        }
        public double? CalculateCollisionTime(BilliardBall billiardBall, IGameObject other)
        {
            if (other is UnmovableLine line)
            {
                // Assuming the line is stationary, we only consider the velocity of the billiard ball
                Vector relativeVelocity = billiardBall.Velocity;
                Vector relativePosition = new Vector(billiardBall.Position.X - line.Start.X, billiardBall.Position.Y - line.Start.Y);

                // Quadratic coefficients
                double a = relativeVelocity.Vx * relativeVelocity.Vx + relativeVelocity.Vy * relativeVelocity.Vy;
                double b = 2 * (relativePosition.Vx * relativeVelocity.Vx + relativePosition.Vy * relativeVelocity.Vy);
                double c = relativePosition.Vx * relativePosition.Vx + relativePosition.Vy * relativePosition.Vy - billiardBall.Radius * billiardBall.Radius;

                // Discriminant
                double discriminant = b * b - 4 * a * c;

                if (discriminant < 0)
                {
                    return null;
                }

                // Calculate the two possible collision times
                double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

                // Choose the earliest positive time
                if (t1 > 0 && t2 > 0)
                {
                    return Math.Min(t1, t2);
                }
                else if (t1 > 0)
                {
                    return t1;
                }
                else if (t2 > 0)
                {
                    return t2;
                }
                else
                {
                    return null;
                }
            }
            else if (other is BilliardBall otherBall)
            {
                Vector relativeVelocity = new Vector(billiardBall.Velocity.Vx - otherBall.Velocity.Vx, billiardBall.Velocity.Vy - otherBall.Velocity.Vy);
                Vector relativePosition = new Vector(billiardBall.Position.X - otherBall.Position.X, billiardBall.Position.Y - otherBall.Position.Y);

                // Quadratic coefficients
                double a = relativeVelocity.Vx * relativeVelocity.Vx + relativeVelocity.Vy * relativeVelocity.Vy;
                double b = 2 * (relativePosition.Vx * relativeVelocity.Vx + relativePosition.Vy * relativeVelocity.Vy);
                double c = relativePosition.Vx * relativePosition.Vx + relativePosition.Vy * relativePosition.Vy - (billiardBall.Radius + otherBall.Radius) * (billiardBall.Radius + otherBall.Radius);

                // Discriminant
                double discriminant = b * b - 4 * a * c;

                if (discriminant < 0)
                {
                    return null;
                }

                // Calculate the two possible collision times
                double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

                // Choose the earliest positive time
                if (t1 > 0 && t2 > 0)
                {
                    return Math.Min(t1, t2);
                }
                else if (t1 > 0)
                {
                    return t1;
                }
                else if (t2 > 0)
                {
                    return t2;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new InvalidOperationException("Unsupported game object type.");
            }
        }
        public void HitChangeVelocity(BilliardBall billiardBall, IGameObject other)
        {
            if (other is BilliardBall otherBall) { 
        // Compute normal vector
                Vector normal = new Vector(otherBall.Position.X - billiardBall.Position.X,
                                            otherBall.Position.Y - billiardBall.Position.Y);
                normal = normal.Normalize();

                // Compute relative velocity
                Vector relativeVelocity = new Vector(
                otherBall.Velocity.Vx - billiardBall.Velocity.Vx,
                otherBall.Velocity.Vy - billiardBall.Velocity.Vy);

                // Compute velocity along the normal
                double velocityAlongNormal = relativeVelocity.Vx * normal.Vx + relativeVelocity.Vy * normal.Vy;

                // If the balls are moving apart, no collision response is needed
                if (velocityAlongNormal > 0)
                {
                    return;
                }

                // Assume equal masses (or replace with billiardBall.Mass and otherBall.Mass if available)
                double impulse = velocityAlongNormal; // Equivalent to dividing by sum of equal masses

                // Apply impulse in the normal direction
                billiardBall.Velocity = new Vector(
                    billiardBall.Velocity.Vx + impulse * normal.Vx,
                    billiardBall.Velocity.Vy + impulse * normal.Vy
                );

                otherBall.Velocity = new Vector(
                    otherBall.Velocity.Vx - impulse * normal.Vx,
                    otherBall.Velocity.Vy - impulse * normal.Vy
                );
            }
            else if (other is UnmovableLine line)
            {
                Vector normal = new Vector(line.End.Y - line.Start.Y, line.Start.X - line.End.X).Normalize();
                double velocityAlongNormal = billiardBall.Velocity.Vx * normal.Vx + billiardBall.Velocity.Vy * normal.Vy;
                billiardBall.Velocity = new Vector(
                    billiardBall.Velocity.Vx - 2 * velocityAlongNormal * normal.Vx,
                    billiardBall.Velocity.Vy - 2 * velocityAlongNormal * normal.Vy
                );
            }
            else
            {
                throw new InvalidOperationException("Unsupported game object type.");
            }
        }
    }
}
