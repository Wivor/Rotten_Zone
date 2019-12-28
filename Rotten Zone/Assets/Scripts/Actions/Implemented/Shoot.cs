using UnityEngine;

public class Shoot : Action
{
    Rat enemy;

    public Shoot(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
        rat.agent.destination = rat.transform.position;
    }

    public override void Update()
    {
        if (enemy == null)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else if (Vector3.Distance(rat.transform.position, enemy.transform.position) > rat.Statistics.range)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else
        {
            enemy.DealDamage(rat.scriptableRat.attack + (int)Random.Range(rat.scriptableRat.attack * 0.1f, rat.scriptableRat.attack * 0.1f));
        }
    }
}