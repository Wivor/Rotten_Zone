public class Gate : AttackableObject
{
    GameManager gameManager;
    bool gameEnded = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //team = Team.A;
    }

    public override void DealDamage(int damage)
    {
        if (gameEnded)
            return;

        if (team == Team.A)
        {
            gameManager.baseAhealth -= damage;
            if (gameManager.baseAhealth <= 0)
            {
                gameEnded = true;
                PlayerWon();
            }
        }
        else
        {
            gameManager.baseBhealth -= damage;
            if (gameManager.baseBhealth <= 0)
            {
                gameEnded = true;
                PlayerLost();
            }
        }
    }

    private void PlayerWon()
    {

    }

    private void PlayerLost()
    {

    }
}
