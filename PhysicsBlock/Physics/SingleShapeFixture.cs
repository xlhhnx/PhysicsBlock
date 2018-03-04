using Microsoft.Xna.Framework;
using System.Collections.Generic;

class SingleShapeFixture
{
    public Body Body { get { return body; } }

    public Shape Shape
    {
        get { return shape; }
        set { shape = value; }
    }

    public Vector2 Position
    {
        get { return shape.Position; }
        set { shape.Position = value; }
    }


    protected Body body;
    protected Shape shape;


    public SingleShapeFixture(Shape shape, Body body)
    {
        this.shape = shape;
        this.body = body;
    }

    public void CalculateMass()
    {
        body.Mass = body.Density * shape.Area;
    }

    public void Rotate(float rotation)
    {
        // TODO
    }
}