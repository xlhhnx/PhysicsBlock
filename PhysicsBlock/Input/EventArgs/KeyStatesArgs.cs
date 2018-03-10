using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

class KeyStatesArgs : EventArgs
{
    #region Properties
    public Dictionary<Keys, ButtonState> KeyStates { get; set; }
    #endregion

    #region Constructors
    public KeyStatesArgs(Dictionary<Keys, ButtonState> keyStates)
    {
        KeyStates = keyStates;
    }
    #endregion
}