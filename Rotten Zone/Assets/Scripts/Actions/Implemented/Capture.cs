public class Capture : Action
{
    public Capture(Rat rat) : base(rat)
    {
        OnStart();
    }

    public override void OnEnd()
    {
        
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(rat.capturePoint.transform.position + rat.capturePosition);
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
