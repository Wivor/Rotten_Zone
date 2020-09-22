﻿public abstract class ApproachEnemy : Action
{
    Rat enemy;

    public ApproachEnemy(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.isStopped = false;
        rat.agent.SetDestination(enemy.transform.position);
        animationsController.ClearQueue();
        animationsController.ChangeAnimationTo("walking");
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
        else if (rat.Statistics.range >= rat.agent.remainingDistance)
        {
            ratController.SetActionTo(new Attack(rat, enemy));
        }
        else
        {
            rat.agent.SetDestination(enemy.transform.position);
        }
    }
}
