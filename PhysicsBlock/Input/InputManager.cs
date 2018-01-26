using System.Collections.Generic;

class InputManager
{
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
}