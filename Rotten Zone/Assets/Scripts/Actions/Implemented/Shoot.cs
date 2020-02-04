using UnityEngine;

public class Shoot : Action
{
    AttackableObject enemy;
    Timer timer;

    public Shoot(Rat rat, AttackableObject enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnEnd()
    {
        
    }

    public override void OnStart()
    {
        rat.agent.velocity = Vector3.zero;
        rat.agent.isStopped = true;
        timer = new Timer(Time.deltaTime, rat.Statistics.attackSpeed, Action);
    }

    public override void Update()
    {
        if (enemy == null)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else if (Vector3.Distance(rat.transform.position, enemy.transform.position) > rat.Statistics.range + 1)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else
        {
            timer.Update();
        }
    }

    private void Action()
    {
        enemy.DealDamage(rat.Statistics.attack + (int)Random.Range(-rat.Statistics.attack * 0.2f, rat.Statistics.attack * 0.2f));
    }
}