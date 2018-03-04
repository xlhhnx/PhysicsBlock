using System;
using Microsoft.Xna.Framework;

class Circle : Shape
{
    public Vector2 Position
    {
        get { return position; }
        set
        {
            position = value;

            if(parentFixture is MultiShapeFixture)
                ((MultiShapeFixture)parentFixture).CalculatePosition();
        }
    }

    public float Radius
    {
        get { return radius; }
        set
        {
            radius = value;
            parentFixture.CalculateMass();
        }
    }

    public float Area { get { return (float)(Math.PI * radius * radius); } }


    protected Fixture parentFixture;
    protected Vector2 position;
    protected float radius;


    public Circle(Vector2 position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }
}