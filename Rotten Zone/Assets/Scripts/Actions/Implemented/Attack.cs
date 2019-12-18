using UnityEngine;

public class Attack : Action
{
    Rat enemy;

    public Attack(Rat rat, Rat enemy) : base(rat)
    {
        this.enemy = enemy;
        OnStart();
    }

    public override void OnStart()
    {
    }

    public override void Update()
    {
        if (enemy == null)
        {
            ratController.SetActionTo(new Move(rat));
        }
        else
        {
            enemy.DealDamage(rat.scriptableRat.attack + (int)Random.Range(rat.scriptableRat.attack * 0.1f, rat.scriptableRat.attack * 0.1f));
        }
    }
}
