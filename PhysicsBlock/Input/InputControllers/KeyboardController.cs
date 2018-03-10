using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

class KeyboardController : InputController
{
    protected InputManager manager;
    protected KeyboardState currentKeyboardState;
    protected Dictionary<Keys, ButtonState> previousKeyStates;

    public KeyboardController(InputManager manager)
    {
        this.manager = manager;

        previousKeyStates = new Dictionary<Keys, ButtonState>();

        foreach(Keys k in Enum.GetValues(typeof(Keys)))
            previousKeyStates.Add(k, ButtonState.Up);
    }

    public void Update()
    {
        currentKeyboardState = Keyboard.GetState();
        Dictionary<Keys, ButtonState> currentKeyStates = new Dictionary<Keys, ButtonState>();
        List<Keys> pressedKeys = new List<Keys>(currentKeyboardState.GetPressedKeys());

        // Loop through pressed keys, calculate current states, remove duplicates from checkKeys list
        foreach (Keys k in previousKeyStates.Keys)
        {
            ButtonState state;

            CalculateState(k, out state);
            currentKeyStates.Add(k, state);
        }

        manager.onKeyPress(new KeyStatesArgs(currentKeyStates));
        previousKeyStates = currentKeyStates;
    }

    protected void CalculateState(Keys k, out ButtonState state)
    {
        bool keyDown = currentKeyboardState.IsKeyDown(k);
        ButtonState prevState = previousKeyStates[k];

        switch (prevState)
        {
            case (ButtonState.Down):
                {
                    if (keyDown) state = ButtonState.Down;
                    else state = ButtonState.Released;
                }
                break;
            case (ButtonState.Pressed):
                {
                    if (keyDown) state = ButtonState.Down;
                    else state = ButtonState.Released;
                }
                break;
            case (ButtonState.Released):
                {
                    if (keyDown) state = ButtonState.Pressed;
                    else state = ButtonState.Up;
                }
                break;
            case (ButtonState.Up):
                {
                    if (keyDown) state = ButtonState.Pressed;
                    else state = ButtonState.Up;
                }
                break;
            default:
                {
                    state = ButtonState.Up;
                }
                break;
        }
    }
}