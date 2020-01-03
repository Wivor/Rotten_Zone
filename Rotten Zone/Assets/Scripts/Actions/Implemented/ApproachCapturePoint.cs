public class ApproachCapturePoint : Action
{
    public ApproachCapturePoint(Rat rat) : base(rat)
    {
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.isStopped = false;
        rat.agent.SetDestination(rat.capturePoint.transform.position);
    }

    public override void OnEnd()
    {
    }

    public override void Update()
    {
        if (animationsController.CurrentAnimationName() == "walking")
        {
            SearchForAviableEnemy();
            if (rat.agent.remainingDistance <= 3.5f)
            {
                ChangeActionTo(new Capture(rat));
            }
        }
        else
        {
            if (animationsController.IsQueueEmpty())
            {
                animationsController.ChangeAnimationTo("walking");
            }
        }
    }
}
