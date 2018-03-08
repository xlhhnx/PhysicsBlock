using Microsoft.Xna.Framework.Input;
using System;

class KeyPressArgs : EventArgs
{
    #region Properties
    public Keys Key { get; set; }
    public ButtonState State { get; set; }
    public bool ShiftDown { get; set; }
    public bool CtrlDown { get; set; }
    #endregion

    #region Constructors
    public KeyPressArgs(Keys key, ButtonState state, bool shiftDown, bool ctrlDown)
    {
        Key = key;
        State = state;
        ShiftDown = shiftDown;
        CtrlDown = ctrlDown;
    }
    #endregion
}