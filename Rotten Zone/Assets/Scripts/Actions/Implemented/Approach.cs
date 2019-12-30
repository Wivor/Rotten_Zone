public abstract class Approach : Action
{
    Rat enemy;

    public Approach(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(enemy.transform.position);
    }

    public override void OnEnd()
    {

    }

    public override void Update()
    {
        if (enemy == null)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else if (rat.scriptableRat.range >= rat.agent.remainingDistance)
        {
            ratController.SetActionTo(new Attack(rat, enemy));
        }
        else
        {
            rat.agent.SetDestination(enemy.transform.position);
        }
    }
}
