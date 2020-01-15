public class ApproachGate : Action
{
    Gate gate;

    public ApproachGate(Rat rat, Gate gate) : base(rat)
    {
        this.gate = gate;
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.isStopped = false;
        rat.agent.SetDestination(gate.transform.position);
        animationsController.ClearQueue();
        animationsController.ChangeAnimationTo("walking");
    }

    public override void OnEnd()
    {

    }

    public override void Update()
    {
        if (gate == null)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else if (rat.Statistics.range >= rat.agent.remainingDistance)
        {
            ratController.SetActionTo(new AttackBase(rat, gate));
        }
        else
        {
            rat.agent.SetDestination(gate.transform.position);
        }
    }
}
