public class Gate : AttackableObject
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //team = Team.A;
    }

    public override void DealDamage(int damage)
    {
        if (team == Team.A)
        {
            gameManager.baseAhealth -= damage;
        }
        else
        {
            gameManager.baseBhealth -= damage;
        }
    }
}
