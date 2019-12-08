using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : Action
{
    public Capture(Rat rat) : base(rat)
    {
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(rat.capturePosition);
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
