public class Move : Action
{
    public Move(Rat rat) : base(rat)
    {
        OnStart();
    }

    public override void OnEnd()
    {
        
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(ratController.GetDestinationOfNextWaypoint());
    }

    public override void Update()
    {
        if(animationsController.CurrentAnimationName() == "walking")
        {
            ChangeWaypointWhenCloseToCurrent();
            SearchForAviableEnemy();
            CheckForCapturePoint();
        }
        else
        {
            CheckIfAnimationQueueIsEmpty();
        }
    }

    private void ChangeWaypointWhenCloseToCurrent()
    {
        if ((rat.agent.remainingDistance < rat.agent.stoppingDistance) && (ratController.stepOnPath != ratController.path.Count - 1))
        {
            ratController.stepOnPath++;
            rat.agent.SetDestination(ratController.GetDestinationOfNextWaypoint());
        }
    }

    private void CheckForCapturePoint()
    {
        if (rat.capturePoint != null && (rat.capturePoint.owner != rat.team))
        {
            ChangeActionTo(new Capture(rat));
        }
    }

    private void CheckIfAnimationQueueIsEmpty()
    {
        if (animationsController.IsQueueEmpty())
        {
            rat.agent.isStopped = false;
            animationsController.ChangeAnimationTo("walking");
        }
    }
}
