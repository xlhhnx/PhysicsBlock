using Microsoft.Xna.Framework.Input;
using System;

class MouseClickArgs : EventArgs
{
    #region Properties
    public MouseButtons Button { get; set; }
    public ButtonState State { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    #endregion

    #region Constructors
    public MouseClickArgs(MouseButtons button, ButtonState state, int x, int y)
    {
        // TODO: Assign Properties
        Button = button;
        State = state;
        X = x;
        Y = y;
    }
    #endregion
}