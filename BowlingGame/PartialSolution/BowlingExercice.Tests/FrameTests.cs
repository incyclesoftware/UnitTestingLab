using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingExercice.Tests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void Frame_When_Throw_First_Ball_Frame_Indicate_Pin_Number()
        {
            Frame sut = new Frame();

            sut.Roll(10);

            Assert.IsTrue(sut.FirstThrow == 10);
        }

        [TestMethod]
        public void Frame_When_Throw_Second_Ball_Frame_Indicate_Pin_Numbers()
        {
            Frame sut = new Frame();

            sut.Roll(5);
            sut.Roll(5);

            Assert.IsTrue(sut.FirstThrow == 5);
            Assert.IsTrue(sut.SecondThrow == 5);
        }

        [TestMethod]
        public void Frame_When_Throw_Third_Ball_Frame_Raise_Exception()
        {
            Frame sut = new Frame();

            sut.Roll(1);
            sut.Roll(2);          

            Assert.ThrowsException<InvalidOperationException>(() => sut.Roll(3));
        }

        [TestMethod]
        public void Frame_When_Throw_Second_Ball_With_Pin_Number_Greater_Than_Allowed_Raise_Exception()
        {
            Frame sut = new Frame();

            sut.Roll(5);

            Assert.ThrowsException<ArgumentException>(() => sut.Roll(6));
        }

        [TestMethod]
        public void Frame_When_Throw_Two_Balls_With_Pin_Number_10_Total()
        {
            Frame sut = new Frame();

            sut.Roll(5);
            sut.Roll(5);

            Assert.IsTrue(sut.IsSpare);

            sut = new Frame();

            sut.Roll(0);
            sut.Roll(10);

            Assert.IsTrue(sut.IsSpare);

            sut = new Frame();

            sut.Roll(10);            

            Assert.IsFalse(sut.IsSpare);
        }

        [TestMethod]
        public void Frame_When_Throw_One_Ball_With_Pin_Number_10_Total()
        {
            Frame sut = new Frame();

            sut.Roll(10);

            Assert.IsFalse(sut.IsSpare);
            Assert.IsTrue(sut.IsStrike);
        }
    }
}
