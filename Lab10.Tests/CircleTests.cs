using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Lab09.Tests;

public class CircleTests
{
    Circle circle;
    AbstractGraphic2D shape;

    [SetUp]
    public void Setup()
    {
        // should be x, y, and radius
        circle = new Circle(8, 10, 2);

        // should extend the abstract class
        shape = circle;
    }

    [Test]
    public void CircleHasCorrectDimensions()
    {
        ClassicAssert.AreEqual(8, circle.CenterX);
        ClassicAssert.AreEqual(10, circle.CenterY);
        ClassicAssert.AreEqual(2, circle.Radius);
    }

    [Test]
    public void HasCorrectBoundingBox()
    {
        ClassicAssert.AreEqual(8 - 2, shape.LowerBoundX);
        ClassicAssert.AreEqual(10 - 2, shape.LowerBoundY);
        ClassicAssert.AreEqual(8 + 2, shape.UpperBoundX);
        ClassicAssert.AreEqual(10 + 2, shape.UpperBoundY);
    }

    [Test]
    public void CenterIsIncluded()
    {
        ClassicAssert.IsTrue(shape.ContainsPoint(8, 10));
    }

    [Test]
    public void ContainsAllFourPointsOfTheCompass()
    {
        ClassicAssert.IsTrue(shape.ContainsPoint(8 - 2, 10));
        ClassicAssert.IsTrue(shape.ContainsPoint(8 + 2, 10));
        ClassicAssert.IsTrue(shape.ContainsPoint(8, 10 - 2));
        ClassicAssert.IsTrue(shape.ContainsPoint(8, 10 + 2));
    }

    [Test]
    public void ShouldNotContainFourCorners()
    {
        ClassicAssert.IsFalse(shape.ContainsPoint(8 - 2, 10 - 2));
        ClassicAssert.IsFalse(shape.ContainsPoint(8 + 2, 10 - 2));
        ClassicAssert.IsFalse(shape.ContainsPoint(8 - 2, 10 + 2));
        ClassicAssert.IsFalse(shape.ContainsPoint(8 + 2, 10 + 2));
    }
}