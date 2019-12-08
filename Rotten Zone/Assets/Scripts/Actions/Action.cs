using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    protected Rat rat;
    protected RatController ratController;

    public Action(Rat rat)
    {
        this.rat = rat;
        ratController = rat.GetComponent<RatController>();
        OnStart();
    }

    public abstract void OnStart();
    public abstract void Update();
}
