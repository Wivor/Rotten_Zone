public class ApproachEnemy : Action
{
    Rat enemy;

    public ApproachEnemy(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.SetDestination(enemy.transform.position);
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
