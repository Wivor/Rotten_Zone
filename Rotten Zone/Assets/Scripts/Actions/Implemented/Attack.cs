using UnityEngine;

public class Attack : Action
{
    AttackableObject enemy;
    Timer timer;

    public Attack(Rat rat, AttackableObject enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnEnd()
    {
        animationsController.ClearQueue();
        animationsController.AddAnimationToQueue("unwield_weapon");
        animationsController.AddAnimationToQueue("lying_down");
    }

    public override void OnStart()
    {
        rat.agent.velocity = Vector3.zero;
        rat.agent.isStopped = true;
        animationsController.ClearQueue();
        animationsController.AddAnimationToQueue("standing");
        animationsController.AddAnimationToQueue("wield_weapon");
    }

    public override void Update()
    {
        if (enemy == null)
        {
            ChangeActionTo(new Move(rat));
            return;
        }

        if (animationsController.CurrentAnimationName() == "hit1")
        {
            timer.Update();
        }
        else
        {
            if (animationsController.IsQueueEmpty())
            {
                timer = new Timer(Time.deltaTime, rat.Statistics.attackSpeed, Action);
                animationsController.ChangeAnimationTo("hit1");
            }
        }        
    }

    private void Action()
    {
        enemy.DealDamage(rat.Statistics.attack + (int)Random.Range(-rat.Statistics.attack * 0.2f, rat.Statistics.attack * 0.2f));
    }
}
