using Microsoft.Xna.Framework;

class Box : Shape
{
    public Vector2 Position
    {
        get { return new Vector2(max.X - min.X, max.Y - min.Y); }
        set
        {
            Vector2 extent = Extent;
            max = new Vector2(value.X + extent.X, value.Y + extent.Y);
            min = new Vector2(value.X - extent.X, value.Y - extent.Y);

            if(parentFixture is MultiShapeFixture)
                ((MultiShapeFixture)parentFixture).CalculatePosition();
        }
    }

    public Vector2 Max
    {
        get { return max; }
        set
        {
            max = value;
            parentFixture.CalculateMass();
        }
    }

    public Vector2 Min
    {
        get { return min; }
        set
        {
            min = value;
            parentFixture.CalculateMass();
        }
    }

    public float Area
    {
        get
        {
            Vector2 lengths = max - min;
            return lengths.X * lengths.Y;
        }
    }

    public Vector2 Extent { get { return new Vector2((Max.X - Min.X) / 2, (Max.Y - Min.Y) / 2); } }


    protected Fixture parentFixture;
    protected Vector2 max;
    protected Vector2 min;


    public Box(Fixture parentFixture, Vector2 max, Vector2 min)
    {
        this.parentFixture = parentFixture;
        this.max = max;
        this.min = min;
    }
}