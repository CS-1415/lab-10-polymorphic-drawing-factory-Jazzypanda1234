using NUnit.Framework;
using NUnit.Framework.Legacy;
using Lab09;
namespace Lab09.Tests;

public class RectangleTests
{
    Rectangle rectangle;
    AbstractGraphic2D shape;

    [SetUp]
    public void Setup()
    {
        rectangle = new Rectangle(3, 4, 5, 6);
        shape = rectangle;
    }

    [Test]
    public void EnsurePropertiesAreCorrect()
    {
        
        ClassicAssert.AreEqual(3, rectangle.Left);
        ClassicAssert.AreEqual(4, rectangle.Top);
        ClassicAssert.AreEqual(5, rectangle.Width);
        ClassicAssert.AreEqual(6, rectangle.Height);
    }

    [Test]
    public void CheckLowerBounds()
    {
        // lower bound is the smallest x that needs to be checked when drawing the shape
        ClassicAssert.AreEqual(3, shape.LowerBoundX);
        ClassicAssert.AreEqual(4, shape.LowerBoundY);
    }

    [Test]
    public void CheckUpperBounds()
    {
        // upper bound is the largest x that needs to be checked when drawing the shape
        ClassicAssert.AreEqual(3 + 5, shape.UpperBoundX);
        ClassicAssert.AreEqual(4 + 6, shape.UpperBoundY);
    }

    [Test]
    public void MiddleOfShapeIsIncluded()
    {
        ClassicAssert.IsTrue(shape.ContainsPoint(5.5m, 7));
    }

    [Test]
    public void CornersIncluded()
    {
        ClassicAssert.IsTrue(shape.ContainsPoint(3, 4));
        ClassicAssert.IsTrue(shape.ContainsPoint(8, 4));
        ClassicAssert.IsTrue(shape.ContainsPoint(3, 10));
        ClassicAssert.IsTrue(shape.ContainsPoint(8, 10));
    }

    [Test]
    public void OutsideOfCornersNotIncludedInShape()
    {
        ClassicAssert.IsFalse(shape.ContainsPoint(3 - 0.1m, 4));
        ClassicAssert.IsFalse(shape.ContainsPoint(8, 4 - 0.1m));
        ClassicAssert.IsFalse(shape.ContainsPoint(3, 10 + 0.1m));
        ClassicAssert.IsFalse(shape.ContainsPoint(8 + 0.1m, 10));
    }
}