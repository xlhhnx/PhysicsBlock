using Microsoft.Xna.Framework.Input;
using System;

class KeyboardController : InputController
{
    protected KeyboardState currentState;
    protected KeyboardState previousState;

    public KeyboardController()
    {
        previousState = new KeyboardState();
    }

    public void Update()
    {
        currentState = Keyboard.GetState();



        previousState = currentState;
    }
}