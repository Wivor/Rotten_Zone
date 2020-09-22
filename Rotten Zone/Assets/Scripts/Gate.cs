using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : AttackableObject
{
    public GameObject popupWin;
    public GameObject popupLost;

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

        gameManager.showHP();
        if (team == Team.A)
        {
            gameManager.baseAhealth -= damage;
            if (gameManager.baseAhealth <= 0)
            {
                gameEnded = true;
                gameManager.PlayerLost();
            }
        }
        else
        {
            gameManager.baseBhealth -= damage;
            if (gameManager.baseBhealth <= 0)
            {
                gameEnded = true;
                gameManager.PlayerWon();
            }
        }
    }

}
