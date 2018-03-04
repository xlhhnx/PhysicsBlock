using Microsoft.Xna.Framework;
using System;

class CollisionResolver
{
    public void ResolveCollision(Collision collision)
    {
        Vector2 relativeVelocity = collision.FixtureA.Body.Velocity - collision.FixtureB.Body.Velocity;
        float contactVelocity = Vector2.Dot(relativeVelocity, collision.Normal);

        // No resolution if objects are seperating
        if (contactVelocity > 0) return;
        // TODO: Add logic to do more in-depth resolution for seperating objects.

        float restitution = Math.Min(collision.FixtureA.Body.Restitution, collision.FixtureB.Body.Restitution);

        float impulseScalar = -(1.0f + restitution) * contactVelocity;
        impulseScalar /= collision.FixtureA.Body.InverseMass + collision.FixtureB.Body.InverseMass;

        Vector2 impulse = impulseScalar * collision.Normal;

        collision.FixtureA.Body.Velocity -= collision.FixtureA.Body.InverseMass * impulse;
        collision.FixtureB.Body.Velocity += collision.FixtureB.Body.InverseMass * impulse;

        // Calculate friction
        relativeVelocity = collision.FixtureA.Body.Velocity - collision.FixtureB.Body.Velocity;

        Vector2 tangent = relativeVelocity - Vector2.Dot(relativeVelocity, collision.Normal) * collision.Normal;
        tangent.Normalize();

        float impulseScalarTangent = -Vector2.Dot(relativeVelocity, collision.Normal);
        impulseScalarTangent /= collision.FixtureA.Body.InverseMass + collision.FixtureB.Body.InverseMass;

        double mu = Math.Sqrt((collision.FixtureA.Body.StaticFriction * collision.FixtureA.Body.StaticFriction)
            + (collision.FixtureB.Body.StaticFriction * collision.FixtureB.Body.StaticFriction));

        Vector2 frictionImpulse;
        if (Math.Abs(impulseScalarTangent) < impulseScalar * mu)
        {
            frictionImpulse = impulseScalarTangent * tangent;
        }
        else
        {
            float dynamicFriction = (float)Math.Sqrt((collision.FixtureA.Body.DynamicFriction * collision.FixtureA.Body.DynamicFriction)
                + (collision.FixtureB.Body.DynamicFriction * collision.FixtureB.Body.DynamicFriction));

            frictionImpulse = -impulseScalar * tangent * dynamicFriction;
        }

        collision.FixtureA.Body.Velocity -= collision.FixtureA.Body.InverseMass * frictionImpulse;
        collision.FixtureB.Body.Velocity += collision.FixtureB.Body.InverseMass * frictionImpulse;
    }

    public void PositionalCorrection(Collision collision)
    {
        const float slop = 0.01f;
        const float percent = 0.2f;

        Vector2 correction = (Math.Max(collision.Penetration - slop, 0f) / (collision.FixtureA.Body.InverseMass + collision.FixtureB.Body.InverseMass)) * percent * collision.Normal;

        collision.FixtureA.Position -= collision.FixtureA.Body.InverseMass * correction;
        collision.FixtureB.Position += collision.FixtureB.Body.InverseMass * correction;
    }
}