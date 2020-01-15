using System.Linq;
using UnityEngine;

public abstract class Action
{
    protected Rat rat;
    protected RatController ratController;
    protected AnimationsController animationsController;

    public Action(Rat rat)
    {
        this.rat = rat;
        ratController = rat.GetComponent<RatController>();
        animationsController = rat.GetComponent<AnimationsController>();
    }

    public abstract void OnStart();
    public abstract void OnEnd();
    public abstract void Update();

    protected void ChangeActionTo(Action action)
    {
        OnEnd();
        ratController.SetActionTo(action);
    }

    protected void SearchForAviableEnemy()
    {
        if (rat.IsRanged())
        {
            RangedBehaviour();
        }
        else
        {
            MeeleBehaviour();
        }
    }

    private void RangedBehaviour()
    {
        if (rat.fieldOfView.GetEnemyGateInRange().Count > 0)
        {
            ChangeActionTo(new Shoot(rat, rat.fieldOfView.GetEnemyGateInRange().OrderByDescending(r => Vector3.Distance(rat.transform.position, r.transform.position)).FirstOrDefault()));
        }
        else if (rat.fieldOfView.GetEnemyRatsInRange().Count > 0)
        {
            ChangeActionTo(new Shoot(rat, rat.fieldOfView.GetEnemyRatsInRange().OrderByDescending(r => Vector3.Distance(rat.transform.position, r.transform.position)).FirstOrDefault()));
        }
    }

    private void MeeleBehaviour()
    {
        foreach (Gate gate in rat.fieldOfView.GetEnemyGateInRange())
        {
            if (gate.team != rat.team)
            {
                ChangeActionTo(new ApproachGate(rat, gate));
            }
        }
        foreach (Rat enemy in rat.fieldOfView.GetEnemyRatsInRange())
        {
            RatController ratControllerOfEnemy = enemy.GetComponent<RatController>();

            if (enemy.IsRanged() || ratControllerOfEnemy.IsFightingGate())
            {
                ratController.SetActionTo(new ApproachRanged(rat, enemy));
            }
            else
            {
                if (!ratControllerOfEnemy.IsFighting())
                {
                    ChangeActionTo(new ApproachMeele(rat, enemy));
                    ratControllerOfEnemy.currentAction.ChangeActionTo(new ApproachMeele(enemy, rat));
                }
            }
        }
    }
}
