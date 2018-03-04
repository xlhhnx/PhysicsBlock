using Microsoft.Xna.Framework;
using System.Collections.Generic;

class MultiShapeFixture
{
    public Body Body { get { return body; } }

    public List<Shape> Shapes
    {
        get { return shapes; }
        set { shapes = value; }
    }

    public Vector2 Position
    {
        get
        {
            return position;
        }
        set
        {
            Vector2 difference = value - Position;

            foreach(Shape shape in shapes)
                shape.Position += difference;

            CalculatePosition();
        }
    }


    protected Body body;
    protected List<Shape> shapes;
    protected Vector2 position;


    public MultiShapeFixture(List<Shape> shapes, Body body)
    {
        shapes = new List<Shape>();

        this.body = body;
        this.shapes.AddRange(shapes);

        CalculateMass();
        CalculatePosition();
    }

    public void CalculateMass()
    {
        foreach (Shape shape in shapes)
            body.Mass += body.Density * shape.Area;
    }

    public void CalculatePosition()
    {
        float sumX = 0f;
        float sumY = 0f;

        foreach (Shape shape in shapes)
        {
            sumX += shape.Position.X;
            sumY += shape.Position.Y;
        }

        position = new Vector2(sumX / shapes.Count, sumY / shapes.Count);
    }

    public void Rotate(float rotation)
    {
        // TODO
    }
}