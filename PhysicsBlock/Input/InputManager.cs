using System;
using System.Collections.Generic;

class InputManager
{
    #region Events
    protected event EventHandler<MouseClickArgs> mouseClickEvent;
    protected event EventHandler<MouseMoveArgs> mouseMoveEvent;
    protected event EventHandler<KeyStatesArgs> keyPressEvent;
    #endregion

    #region Variables
    protected List<InputController> controllers;
    #endregion

    #region Constructors
    public InputManager()
    {
        controllers = new List<InputController>();
    }
    #endregion

    #region Public Methods
    public void Update()
    {
        foreach(InputController controller in controllers) controller.Update();
    }

    public void AddController(InputController controller)
    {
        controllers.Add(controller);
    }

    public void RemoveController(InputController controller)
    {
        controllers.Remove(controller);
    }

    public void RemoveController(int index)
    {
        controllers.RemoveAt(index);
    }

    public void onMouseClick(MouseClickArgs args)
    {
        if (!(mouseClickEvent == null))
            mouseClickEvent.Invoke(this, args);
    }

    public void onMouseMove(MouseMoveArgs args)
    {
        if (!(mouseMoveEvent == null))
            mouseMoveEvent.Invoke(this, args);
    }

    public void onKeyPress(KeyStatesArgs args)
    {
        if(!(keyPressEvent == null))
            keyPressEvent.Invoke(this, args);
    }

    public void Subscribe(object handler)
    {
        if(handler is EventHandler<MouseClickArgs>)
            mouseClickEvent += (EventHandler<MouseClickArgs>)handler;
        else if (handler is EventHandler<MouseMoveArgs>)
            mouseMoveEvent += (EventHandler<MouseMoveArgs>)handler;
        else if(handler is EventHandler<KeyStatesArgs>)
            keyPressEvent += (EventHandler<KeyStatesArgs>)handler;
        else
            LogManager.LogWarning($"Unhandled Type | [{handler}] does not have a valid Event Handler type.");
    }

    public void Unsubscribe(object handler, Type type)
    {
        if (handler is EventHandler<MouseClickArgs>)
            mouseClickEvent -= (EventHandler<MouseClickArgs>)handler;
        else if(handler is EventHandler<MouseMoveArgs>)
            mouseMoveEvent -= (EventHandler<MouseMoveArgs>)handler;
        else if (handler is EventHandler<KeyStatesArgs>)
            keyPressEvent -= (EventHandler<KeyStatesArgs>)handler;
        else
            LogManager.LogWarning($"Unhandled Type | {handler} does not have a valid Event Handler type.");
    }
    #endregion
}