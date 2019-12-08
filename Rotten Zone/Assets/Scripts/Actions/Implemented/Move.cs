using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Action
{
    public Move(Rat rat) : base(rat)
    {
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(ratController.GetDestinationOfNextWaypoint());
    }

    public override void Update()
    {
        ChangeWaypointWhenCloseToCurrent();
    }

    private void ChangeWaypointWhenCloseToCurrent()
    {
        if ((rat.agent.remainingDistance < rat.agent.stoppingDistance) && (ratController.stepOnPath != ratController.path.Count - 1))
        {
            ratController.stepOnPath++;
            rat.agent.SetDestination(ratController.GetDestinationOfNextWaypoint());
        }
    }
}
