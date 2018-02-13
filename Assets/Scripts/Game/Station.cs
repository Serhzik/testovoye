using System;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {
    public event Action<bool> CanLoadAction;
    bool canLoad;

   public void Enter()
    {
        if (canLoad)
            return;
        canLoad = true;
        if (CanLoadAction != null)
            CanLoadAction(true);
    }
    public void Exit()
    {
        canLoad = false;
        if (CanLoadAction != null)
            CanLoadAction(false);
    }
}
