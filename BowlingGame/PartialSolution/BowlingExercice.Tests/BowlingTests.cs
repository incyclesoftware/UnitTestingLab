using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingExercice.Tests
{
    [TestClass]
    public class BowlingTests
    {
        [TestMethod]
        public void BowlingGame_When_Start_Should_Have_10_Frames()
        {
            BowlingGame sut = new BowlingGame();

            sut.Start();

            Assert.IsTrue(sut.Frames.Length == 10);
        }

        [TestMethod]
        public void BowlingGame_When_Throw_First_Ball_Frame1_Indicate_Pin_Number()
        {
            BowlingGame sut = new BowlingGame();

            sut.Start();
            sut.Roll(10);

            Assert.IsTrue(sut.Frames[0].FirstThrow == 10);
        }

        [TestMethod]
        public void BowlingGame_When_Throw_Two_Ball_Frame_Current_Frame_Is_Incremented()
        {
            BowlingGame sut = new BowlingGame();

            sut.Start();
            sut.Roll(5);
            sut.Roll(5);

            Assert.IsTrue(sut.CurrentFrame == 2);

            sut.Start();
            for (int i = 0; i < 4; i++)
            {
                sut.Roll(1);
            }
            Assert.IsTrue(sut.CurrentFrame == 3);

            sut.Start();
            for (int i = 0; i < 18; i++)
            {
                sut.Roll(1);
            }

            Assert.IsTrue(sut.CurrentFrame == 10);
        }

        [TestMethod]
        public void BowlingGame_When_Next_Roll_After_Spare_Give_Bonus()
        {
            BowlingGame sut = new BowlingGame();

            sut.Start();
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(5);

            Assert.IsTrue(sut.Frames[sut.CurrentFrame - 2].Bonus == 5);

            sut = new BowlingGame();

            sut.Start();
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(3);

            Assert.IsTrue(sut.Frames[sut.CurrentFrame - 3].Bonus == 5);
        }
    }
}