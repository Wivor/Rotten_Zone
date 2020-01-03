public class Capture : Action
{
    public Capture(Rat rat) : base(rat)
    {
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.isStopped = true;
        rat.capturePoint.captureChange += rat.CapPointChange();
        animationsController.ClearQueue();
        animationsController.AddAnimationToQueue("standing");
    }

    public override void OnEnd()
    {
        rat.capturePoint.captureChange -= rat.CapPointChange();
        animationsController.ClearQueue();
        animationsController.AddAnimationToQueue("lying_down");
    }

    public override void Update()
    {
        if (rat.capturePoint.owner == rat.team)
        {
            ChangeActionTo(new Move(rat));
        }

        SearchForAviableEnemy();
    }
}
