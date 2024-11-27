namespace Lab09;

public interface IGraphic2DFactory
{
    string Name{ get; }
    IGraphic2D Create();
}

public class CircleFactory : IGraphic2DFactory
{
    public string Name => "Circle";

    public IGraphic2D Create()
    {
        Console.WriteLine("Enter the X-coordinate of the center:");
        decimal centerX = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Y-coordinate of the center:");
        decimal centerY = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter the radius:");
        decimal radius = decimal.Parse(Console.ReadLine());

        return new Circle(centerX, centerY, radius);
    }
}