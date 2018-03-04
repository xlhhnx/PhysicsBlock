using Microsoft.Xna.Framework;

class OrientedBox : Shape
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

    public Vector2 Extent
    {
        get { return extent; }
        set
        {
            extent = value;
            parentFixture.CalculateMass();
        }
    }

    public Vector2 Axis
    {
        get { return extent; }
        set { extent = value; }
    }

    public float Area
    {
        get { return Extent.X * Extent.Y * 4; }
    }


    protected Fixture parentFixture;
    protected Vector2 position;
    protected Vector2 extent;
    protected Vector2 axis;


    public OrientedBox(Vector2 position, Vector2 extent, Vector2 axis)
    {
        this.position = position;
        this.extent = extent;
        this.axis = axis;
    }
}
