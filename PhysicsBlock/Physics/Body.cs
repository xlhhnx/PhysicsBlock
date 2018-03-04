using Microsoft.Xna.Framework;

class Body
{
    public Vector2 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public Vector2 Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public float Restitution { get { return restitution; } }

    public float Mass
    {
        get { return mass; }
        set
        {
            mass = value;
            if (mass == 0)
                inverseMass = 0;
            else
                inverseMass = 1 / value;
        }
    }

    public float InverseMass
    {
        get { return inverseMass; }
        set
        {
            inverseMass = value;
            if (inverseMass == 0)
                mass = 0;
            else
                mass = 1 / inverseMass;
        }
    }

    public float StaticFriction { get { return staticFriction; } }
    public float DynamicFriction { get { return dynamicFriction; } }

    public float Density
    {
        get { return density; }
        set
        {
            density = value;
        }
    }

    
    protected Vector2 velocity;
    protected Vector2 acceleration;
    protected float restitution;
    protected float mass;
    protected float inverseMass;
    protected float staticFriction;
    protected float dynamicFriction;
    protected float density;


    public Body(Vector2 velocity, Vector2 acceleration, float restitution, float staticFriction, float dynamicFriction, float density)
    {
        this.velocity = velocity;
        this.acceleration = acceleration;
        this.restitution = restitution;
        this.staticFriction = staticFriction;
        this.dynamicFriction = dynamicFriction;
        this.density = density;
    }
}