using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

class CollisionDetector
{

    public bool CheckCollision(SingleShapeFixture a, SingleShapeFixture b, out Collision c)
    {
        // Set default output
        bool collision = false;
        c = null;
        
        Vector2 normal = Vector2.Zero;
        float penetration = 0f;

        if(a.Shape is Circle && b.Shape is Circle)
            collision = CircleToCircle(a, b, out normal, out penetration);
        else if (a.Shape is Box && b.Shape is Box)
            collision = BoxToBox(a, b, out normal, out penetration);
        else if (a.Shape is Box && b.Shape is Circle)
            collision = BoxToCircle(a, b, out normal, out penetration);
        else if (a.Shape is Circle && b.Shape is Box)
            collision = BoxToCircle(b, a, out normal, out penetration);

        if(collision) c = new Collision(a, b, normal, penetration);
        return collision;
    }

    public bool CircleToCircle(SingleShapeFixture a, SingleShapeFixture b, out Vector2 normal, out float penetration)
    {
        // Set default output
        normal = Vector2.Zero;
        penetration = 0f;

        Vector2 translation = b.Shape.Position - a.Shape.Position;
        float cumulativeRadius = ((Circle)a.Shape).Radius + ((Circle)b.Shape).Radius;

        // Not intersecting
        if(translation.LengthSquared() > cumulativeRadius * cumulativeRadius)
            return false;

        float distance = translation.Length();

        if (distance == 0)
        {
            // Right on top of each other.
            penetration = ((Circle)a.Shape).Radius;
            normal = new Vector2(1, 0);
        }
        else
        {
            penetration = cumulativeRadius - distance;
            normal = translation / distance;
        }

        return true;
    }

    public bool BoxToBox(SingleShapeFixture a, SingleShapeFixture b, out Vector2 normal, out float penetration)
    {
        // Set default output
        normal = Vector2.Zero;
        penetration = 0f;

        Vector2 translation = b.Shape.Position - a.Shape.Position;

        float aExtentX = (((Box)a.Shape).Max.X - ((Box)a.Shape).Min.X) / 2;
        float bExtentX = (((Box)b.Shape).Max.X - ((Box)b.Shape).Min.X) / 2;

        float xOverlap = aExtentX + bExtentX - Math.Abs( translation.X);

        if (xOverlap > 0)
        {
            float aExtentY = (((Box)a.Shape).Max.Y - ((Box)a.Shape).Min.Y) / 2;
            float bExtentY = (((Box)b.Shape).Max.Y - ((Box)b.Shape).Min.Y) / 2;

            float yOverlap = aExtentY + bExtentY - Math.Abs(translation.Y);

            if (yOverlap > 0)
            {
                if (xOverlap > yOverlap)
                {
                    if (translation.X < 0)
                        normal = new Vector2(-1,0);
                    else
                        normal = new Vector2(1,0);

                    penetration = xOverlap;
                }
                else
                {
                    if (translation.X < 0)
                        normal = new Vector2(0, -1);
                    else
                        normal = new Vector2(0, 1);

                    penetration = yOverlap;
                }
            }
        }

        return true;
    }

    public bool BoxToCircle(SingleShapeFixture a, SingleShapeFixture b, out Vector2 normal, out float penetration)
    {
        // Set default output
        normal = Vector2.Zero;
        penetration = 0f;

        Vector2 translation = b.Shape.Position - a.Shape.Position;
        Vector2 closest = translation;

        float extentX = (((Box)a.Shape).Max.X - ((Box)a.Shape).Min.X) / 2;
        float extentY = (((Box)a.Shape).Max.Y - ((Box)a.Shape).Min.Y) / 2;

        closest.X = Clamp(closest.X, -extentX, extentX);
        closest.X = Clamp(closest.Y, -extentY, extentY);

        bool inside = false;

        if (translation == closest)
        {
            inside = true;

            if (Math.Abs(translation.X) > Math.Abs(translation.Y))
            {
                if (closest.X > 0)
                    closest.X = extentX;
                else
                    closest.X = -extentX;
            }
            else
            {
                if (closest.Y > 0)
                    closest.Y = extentY;
                else
                    closest.Y = -extentY;
            }
        }

        normal = translation - closest;
        float radius = ((Circle)b.Shape).Radius;

        if (translation.LengthSquared() > radius * radius && !inside)
            return false;

        float distance = translation.Length();

        if (inside)
        {
            normal = -translation;
            penetration = radius - distance;
        }
        else
        {
            normal = translation;
            penetration = radius - distance;
        }

        return true;
    }

    protected float Clamp(float val, float min, float max)
    {
        if(val < min)
            val = min;
        else if (val > max)
            val = max;

        return val;
    }
}