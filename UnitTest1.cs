using Engin_Bliiard;

namespace Bili.Test
{
    using NUnit.Framework;
    using Engin_Bliiard;

    namespace EnginBliiard.Tests
    {
        [TestFixture]
        public class BilliardBallTests
        {
            private BilliardBall ball1;
            private BilliardBall ball2;
            private GamePhysics gamePhysics;

            [SetUp]
            public void Setup()
            {
                ball1 = new BilliardBall(0, 0, 1, 0);
                ball2 = new BilliardBall(2, 0, -1, 0);
                gamePhysics = new GamePhysics();
            }

            [Test]
            public void UpdatePosition_ShouldUpdatePositionCorrectly()
            {
                ball1.UpdatePosition(0.1);
                Assert.AreEqual(0.099, ball1.Position.X, 0.001);
                Assert.AreEqual(0, ball1.Position.Y, 0.001);
            }

            [Test]
            public void HitChangeVelocity_ShouldReverseVelocityOnCollision()
            {
                gamePhysics.HitChangeVelocity(ball1, ball2);
                Assert.AreEqual(-1, ball1.Velocity.Vx);
                Assert.AreEqual(1, ball2.Velocity.Vx);
            }

            [Test]
            public void CheckCollision_ShouldDetectCollision()
            {
                bool result = gamePhysics.CheckCollision(ball1, ball2);
                Assert.IsTrue(result);
            }

            [Test]
            public void CheckCollision_ShouldNotDetectCollisionWhenFarApart()
            {
                ball2.Position = new Position(10, 0);
                bool result = gamePhysics.CheckCollision(ball1, ball2);
                Assert.IsFalse(result);
            }

            [Test]
            public void HitChangeVelocity_ShouldHandleCollisionWithLine()
            {
                UnmovableLine line = new UnmovableLine(new Position(0, -1), new Position(0, 1));
                gamePhysics.HitChangeVelocity(ball1, line);
                Assert.AreEqual(-1, ball1.Velocity.Vx);
            }

            [Test]
            public void UpdatePosition_ShouldApplyFriction()
            {
                ball1.UpdatePosition(1);
                Assert.Less(ball1.Velocity.Vx, 1);
            }

            [Test]
            public void Vector_Length_ShouldCalculateCorrectly()
            {
                Vector vector = new Vector(3, 4);
                Assert.AreEqual(5, vector.Length(), 0.001);
            }

            [Test]
            public void Vector_Normalize_ShouldReturnUnitVector()
            {
                Vector vector = new Vector(3, 4);
                Vector normalized = vector.Normalize();
                Assert.AreEqual(1, normalized.Length(), 0.001);
            }

            [Test]
            public void HitChangeVelocity_ShouldConserveMomentum()
            {
                double initialMomentum = ball1.Velocity.Vx + ball2.Velocity.Vx;
                gamePhysics.HitChangeVelocity(ball1, ball2);
                double finalMomentum = ball1.Velocity.Vx + ball2.Velocity.Vx;
                Assert.AreEqual(initialMomentum, finalMomentum, 0.001);
            }

            [Test]
            public void Position_ShouldInitializeCorrectly()
            {
                Position pos = new Position(1, 2);
                Assert.AreEqual(1, pos.X);
                Assert.AreEqual(2, pos.Y);
            }

            [Test]
            public void Position_ShouldUpdateCorrectly()
            {
                Position pos = new Position(1, 2);
                pos.X = 3;
                pos.Y = 4;
                Assert.AreEqual(3, pos.X);
                Assert.AreEqual(4, pos.Y);
            }

            [Test]
            public void Vector_Addition_ShouldWorkCorrectly()
            {
                Vector v1 = new Vector(1, 2);
                Vector v2 = new Vector(3, 4);
                Vector result = v1 + v2;
                Assert.AreEqual(4, result.Vx);
                Assert.AreEqual(6, result.Vy);
            }

            [Test]
            public void Vector_Subtraction_ShouldWorkCorrectly()
            {
                Vector v1 = new Vector(1, 2);
                Vector v2 = new Vector(3, 4);
                Vector result = v1 - v2;
                Assert.AreEqual(-2, result.Vx);
                Assert.AreEqual(-2, result.Vy);
            }

            [Test]
            public void Vector_ScalarMultiplication_ShouldWorkCorrectly()
            {
                Vector v = new Vector(1, 2);
                Vector result = v * 3;
                Assert.AreEqual(3, result.Vx);
                Assert.AreEqual(6, result.Vy);
            }

            [Test]
            public void Vector_ScalarDivision_ShouldWorkCorrectly()
            {
                Vector v = new Vector(3, 6);
                Vector result = v / 3;
                Assert.AreEqual(1, result.Vx);
                Assert.AreEqual(2, result.Vy);
            }

            [Test]
            public void BilliardBall_ShouldInitializeWithCorrectVelocity()
            {
                BilliardBall ball = new BilliardBall(0, 0, 2, 3);
                Assert.AreEqual(2, ball.Velocity.Vx);
                Assert.AreEqual(3, ball.Velocity.Vy);
            }

            [Test]
            public void BilliardBall_ShouldInitializeWithCorrectPosition()
            {
                BilliardBall ball = new BilliardBall(1, 2);
                Assert.AreEqual(1, ball.Position.X);
                Assert.AreEqual(2, ball.Position.Y);
            }

            [Test]
            public void GamePhysics_CheckCollision_ShouldHandleMultipleObjects()
            {
                BilliardBall ball3 = new BilliardBall(1, 1);
                gamePhysics.AddGameObject(ball1);
                gamePhysics.AddGameObject(ball2);
                gamePhysics.AddGameObject(ball3);
                Assert.IsTrue(gamePhysics.CheckCollision(ball1, ball2));
                Assert.IsFalse(gamePhysics.CheckCollision(ball1, ball3));
            }

            [Test]
            public void GamePhysics_HitChangeVelocity_ShouldHandleMultipleCollisions()
            {
                BilliardBall ball3 = new BilliardBall(1, 1, -1, -1);
                gamePhysics.HitChangeVelocity(ball1, ball2);
                gamePhysics.HitChangeVelocity(ball1, ball3);
                Assert.AreNotEqual(ball1.Velocity, ball2.Velocity);
                Assert.AreNotEqual(ball1.Velocity, ball3.Velocity);
            }
        }
    }
}