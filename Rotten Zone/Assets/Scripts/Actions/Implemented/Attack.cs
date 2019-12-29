using UnityEngine;

public class Attack : Action
{
    Rat enemy;
    Timer timer;

    public Attack(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
        timer = new Timer(Time.deltaTime, rat.Statistics.attackSpeed, Action);
    }

    public override void Update()
    {
        if (enemy == null)
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
