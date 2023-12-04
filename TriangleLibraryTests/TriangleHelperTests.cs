using NUnit.Framework;
using System;
using TriangleLibrary;

namespace TriangleLibraryTests
{
    [TestFixture]
    public class TriangleHelperTests
    {
        [Test]
        public void GetAngleType_NotPositiveLength_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(-1, 1, 12));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(1, -2, 5));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(45, 2, -12));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(-13, -16, -12));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(0, 22, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(10, 0, 32));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(11, 30, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleHelper.GetAngleType(500000055, 300000033, 400000044));
        }

        [Test]
        public void GetAngleType_IncorrectTriangleLengths_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => TriangleHelper.GetAngleType(6, 5.99, 12));
            Assert.Throws<ArgumentException>(() => TriangleHelper.GetAngleType(6, 6, 12));
        }

        [TestCase(5, 3, 4, TriangleAngleTypeEnum.Right)]
        [TestCase(5, 3.1, 4, TriangleAngleTypeEnum.Acture)]
        [TestCase(5, 2.999, 4, TriangleAngleTypeEnum.Obtuse)]

        [TestCase(15, 17, 8, TriangleAngleTypeEnum.Right)]
        [TestCase(15, 18, 8, TriangleAngleTypeEnum.Obtuse)]
        [TestCase(16, 17, 8, TriangleAngleTypeEnum.Acture)]
        [TestCase(15, 17, 7, TriangleAngleTypeEnum.Obtuse)]

        [TestCase(120, 169, 119, TriangleAngleTypeEnum.Right)]
        [TestCase(229, 221, 60, TriangleAngleTypeEnum.Right)]
       
        [TestCase(13.35, 61.6789, 63.107124837137050479447920290031, TriangleAngleTypeEnum.Right)]
        [TestCase(13.35, 61.6789, 63.10712483, TriangleAngleTypeEnum.Acture)]
        [TestCase(13.35, 61.6789, 63.10712484, TriangleAngleTypeEnum.Obtuse)]

        [TestCase(0.5, 0.3, 0.4, TriangleAngleTypeEnum.Right)]
        [TestCase(0.000000005, 0.000000003, 0.000000004, TriangleAngleTypeEnum.Right)]
        [TestCase(5000000.05, 3000000.03, 4000000.04, TriangleAngleTypeEnum.Right)]

        [TestCase(50000005.05005555555, 30000003.03300333333, 40000004.04004444444, TriangleAngleTypeEnum.Right)]
        
        [TestCase(135, 135, 135, TriangleAngleTypeEnum.Acture)]
        public void GetAngleType_VariateLength_CorrectResult(double a, double b, double c, TriangleAngleTypeEnum expected)
        {
            Assert.AreEqual(expected, TriangleHelper.GetAngleType(a, b, c));
        }
    }
}