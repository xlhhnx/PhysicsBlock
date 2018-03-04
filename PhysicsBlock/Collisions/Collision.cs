using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Collision
{
    #region Properties
    public Fixture FixtureA
    {
        get { return fixtureA; }
        set { fixtureA = value; }
    }

    public Fixture FixtureB
    {
        get { return fixtureB; }
        set { fixtureB = value; }
    }

    public Vector2 Normal { get { return normal; } }
    public float Penetration { get { return penetration; } }
    #endregion

    #region Variables
    protected Fixture fixtureA;
    protected Fixture fixtureB;
    protected Vector2 normal;
    protected float penetration;
    #endregion

    #region Constructors
    public Collision(Fixture fixtureA, Fixture fixtureB, Vector2 normal, float penetration)
    {
        this.fixtureA = fixtureA;
        this.fixtureB = fixtureB;
        this.normal = normal;
        this.penetration = penetration;
    }
    #endregion
}