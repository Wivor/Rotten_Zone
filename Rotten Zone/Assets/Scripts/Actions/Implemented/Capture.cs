public class Capture : Action
{
    public Capture(Rat rat) : base(rat)
    {
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(rat.capturePoint.transform.position + rat.capturePosition);
        rat.capturePoint.captureChange += rat.CapPointChange();
    }

    public override void OnEnd()
    {
        rat.capturePoint.captureChange -= rat.CapPointChange();
        rat.capturePoint = null;
    }

    public override void Update()
    {
        if (rat.capturePoint.owner == rat.team)
        {
            ratController.SetActionTo(new Move(rat));
        }

        SearchForAviableEnemy();
    }
}
