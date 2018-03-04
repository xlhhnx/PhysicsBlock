using Microsoft.Xna.Framework;
using System.Collections.Generic;

interface Fixture
{
    Body Body { get; }
    Vector2 Position { get; set; }

    void CalculateMass();
    void Rotate(float rotation);
}