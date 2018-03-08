using System;

class MouseMoveArgs : EventArgs
{
    #region Properties
    public int X { get; set; }
    public int Y { get; set; }
    #endregion

    #region Constructors
    public MouseMoveArgs(int x, int y)
    {
        X = x;
        Y = y;
    }
    #endregion
}