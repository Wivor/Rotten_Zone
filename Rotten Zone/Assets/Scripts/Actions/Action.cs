public abstract class Action
{
    protected Rat rat;
    protected RatController ratController;

    public Action(Rat rat)
    {
        this.rat = rat;
        ratController = rat.GetComponent<RatController>();
    }

    public abstract void OnStart();
    public abstract void Update();

    protected void SearchForAviableEnemy()
    {
        foreach (Rat enemy in rat.fieldOfView.GetEnemyRatsInRange())
        {
            RatController ratControllerOfEnemy = enemy.GetComponent<RatController>();

            if (!ratControllerOfEnemy.IsFighting())
            {
                ratController.SetActionTo(new ApproachEnemy(rat, enemy));
                ratControllerOfEnemy.SetActionTo(new ApproachEnemy(enemy, rat));
            }
        }
    }
}
