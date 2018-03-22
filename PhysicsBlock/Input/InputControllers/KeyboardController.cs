using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

class KeyboardController : InputController
{
    #region Variables
    protected InputManager manager;
    protected KeyboardState currentKeyboardState;
    protected Dictionary<Keys, ButtonState> previousKeyStates;
    #endregion

    #region Constructors
    public KeyboardController(InputManager manager)
    {
        this.manager = manager;

        previousKeyStates = new Dictionary<Keys, ButtonState>();

        foreach(Keys k in Enum.GetValues(typeof(Keys)))
            previousKeyStates.Add(k, ButtonState.Up);
    }
    #endregion

    #region Public Methods
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
    #endregion

    #region Protected Methods
    protected void CalculateState(Keys k, out ButtonState state)
    {
        bool keyDown = currentKeyboardState.IsKeyDown(k);
        ButtonState prevState = previousKeyStates[k];

        switch (prevState)
        {
            case (ButtonState.Down):
                {
                    if (keyDown)
                        state = ButtonState.Down;
                    else
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Released}");
                        state = ButtonState.Released;
                    }
                }
                break;
            case (ButtonState.Pressed):
                {
                    if (keyDown)
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Down}");
                        state = ButtonState.Down;
                    }
                    else
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Released}");
                        state = ButtonState.Released;
                    }
                }
                break;
            case (ButtonState.Released):
                {
                    if (keyDown)
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Pressed}");
                        state = ButtonState.Pressed;
                    }
                    else
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Up}");
                        state = ButtonState.Up;
                    }
                }
                break;
            case (ButtonState.Up):
                {
                    if (keyDown)
                    {
                        LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Pressed}");
                        state = ButtonState.Pressed;
                    }
                    else
                        state = ButtonState.Up;
                }
                break;
            default:
                {
                    LogManager.LogVerbose($"Key {k} state changed from {prevState} to {ButtonState.Up}");
                    state = ButtonState.Up;
                }
                break;
        }
    }
    #endregion
}