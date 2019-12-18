public class Move : Action
{
    public Move(Rat rat) : base(rat)
    {
        OnStart();
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
        ChangeWaypoint();
        SearchForAviableEnemy();

        if (rat.capturePoint != null && (rat.capturePoint.owner != rat.team))
        {
            ratController.SetActionTo(new Capture(rat));
        }
    }

    private void ChangeWaypoint()
    {
        if ((rat.agent.remainingDistance < rat.agent.stoppingDistance) && (ratController.stepOnPath != ratController.path.Count - 1))
        {
            ratController.stepOnPath++;
            rat.agent.SetDestination(ratController.GetDestinationOfNextWaypoint());
        }
    }
}
