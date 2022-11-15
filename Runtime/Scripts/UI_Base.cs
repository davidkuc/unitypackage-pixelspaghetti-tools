using UnityEngine;

public abstract class UI_Base : Debuggable
{
    private GameObject container;

    protected virtual void Awake()
    {
        GetObjectsAndButtons();
        AddListeners();
    }

    protected abstract bool ToggleContainer(bool active);

    protected abstract void GetObjectsAndButtons();

    protected abstract void AddListeners();
}

