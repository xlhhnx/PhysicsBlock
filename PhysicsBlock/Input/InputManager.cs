using System;
using System.Collections.Generic;

class InputManager
{
    protected event EventHandler<MouseClickArgs> mouseClickEvent;
    protected event EventHandler<MouseMoveArgs> mouseMoveEvent;
    protected event EventHandler<KeyStatesArgs> keyPressEvent;

    protected List<InputController> controllers;

    public InputManager()
    {
        controllers = new List<InputController>();
    }

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
        mouseClickEvent.Invoke(this, args);
    }

    public void onMouseMove(MouseMoveArgs args)
    {
        mouseMoveEvent.Invoke(this, args);
    }

    public void onKeyPress(KeyStatesArgs args)
    {
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
}