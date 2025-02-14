using System;
using System.Collections.Generic;

namespace Engin_Bliiard
{
    class BilliardGame
    {
        static void Main()
        {
            // Erstelle ein GamePhysics-Objekt
            GamePhysics gamePhysics = new GamePhysics();

            // Erstelle einige Billardkugeln
            BilliardBall ball1 = new BilliardBall(1, 1, 1, 0);
            BilliardBall ball2 = new BilliardBall(3, 1, -1, 0);
            BilliardBall ball3 = new BilliardBall(2, 2, 0, -1);

            // Füge die Billiardkugeln zum Spiel hinzu
            gamePhysics.AddGameObject(ball1);
            gamePhysics.AddGameObject(ball2);
            gamePhysics.AddGameObject(ball3);

            // Erstelle eine unbewegliche Linie
            UnmovableLine line = new UnmovableLine(new Position(0, 0), new Position(0, 5));

            // Füge die Linie zum Spiel hinzu
            gamePhysics.AddGameObject(line);

            // Simuliere das Spiel für einige Schritte
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Step {i + 1}:");

                // Aktualisiere die Positionen der Billiardkugeln
                ball1.UpdatePosition(0.1);
                ball2.UpdatePosition(0.1);
                ball3.UpdatePosition(0.1);

                // Überprüfe Kollisionen zwischen den Billiardkugeln
                if (gamePhysics.CheckCollision(ball1, ball2))
                {
                    Console.WriteLine("Collision detected between ball1 and ball2");
                    gamePhysics.HitChangeVelocity(ball1, ball2);
                }

                if (gamePhysics.CheckCollision(ball1, ball3))
                {
                    Console.WriteLine("Collision detected between ball1 and ball3");
                    gamePhysics.HitChangeVelocity(ball1, ball3);
                }

                if (gamePhysics.CheckCollision(ball2, ball3))
                {
                    Console.WriteLine("Collision detected between ball2 and ball3");
                    gamePhysics.HitChangeVelocity(ball2, ball3);
                }

                // Überprüfe Kollisionen zwischen den Billiardkugeln und der Linie
                if (gamePhysics.CheckCollision(ball1, line))
                {
                    Console.WriteLine("Collision detected between ball1 and the line");
                    gamePhysics.HitChangeVelocity(ball1, line);
                }

                if (gamePhysics.CheckCollision(ball2, line))
                {
                    Console.WriteLine("Collision detected between ball2 and the line");
                    gamePhysics.HitChangeVelocity(ball2, line);
                }

                if (gamePhysics.CheckCollision(ball3, line))
                {
                    Console.WriteLine("Collision detected between ball3 and the line");
                    gamePhysics.HitChangeVelocity(ball3, line);
                }

                // Ausgabe der Positionen und Geschwindigkeiten der Billiardkugeln
                Console.WriteLine($"Ball1 Position: ({ball1.Position.X}, {ball1.Position.Y}), Velocity: ({ball1.Velocity.Vx}, {ball1.Velocity.Vy})");
                Console.WriteLine($"Ball2 Position: ({ball2.Position.X}, {ball2.Position.Y}), Velocity: ({ball2.Velocity.Vx}, {ball2.Velocity.Vy})");
                Console.WriteLine($"Ball3 Position: ({ball3.Position.X}, {ball3.Position.Y}), Velocity: ({ball3.Velocity.Vx}, {ball3.Velocity.Vy})");
                Console.WriteLine();
            }
        }
    }
}
