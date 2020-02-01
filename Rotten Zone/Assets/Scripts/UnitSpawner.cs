using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitSpawner : MonoBehaviour
{
    public GameObject ratPrefab;

    public ScriptableRat rat1;
    public ScriptableRat rat2;
    public ScriptableRat rat3;
    public int currentRat = 1;
    public int selectedLane = 10;
    public Dictionary<int, ScriptableRat> rats;

    private Team team;
    
    // Start is called before the first frame update
    void Start()
    {
        rats = new Dictionary<int, ScriptableRat>();
        rats[1] = rat1;
        rats[2] = rat2;
        rats[3] = rat3;
    }

    public void SelectLane(int laneID)
    {
        selectedLane = laneID;
    }

    public void SpawnUnit(int laneID, bool isEnemy)
    {
        int score = isEnemy==true ? GetComponent<GameManager>().playerBScore : GetComponent<GameManager>().playerAScore;

        if (rats[currentRat].cost > score)
            return;
        else if(isEnemy)
        {
            GetComponent<GameManager>().playerBScore -= rats[currentRat].cost;
            team = Team.B;
        }
        else
        {
            GetComponent<GameManager>().playerAScore -= rats[currentRat].cost;
            team = Team.A;
        }

        switch (laneID)
        {
            case 9:
                Spawn(0);
                break;
            case 10:
                Spawn(1);
                break;
            case 11:
                Spawn(2);
                break;
        }
    }

    private void Spawn(int path)
    {
        GameObject rat = Instantiate(ratPrefab);
        rat.GetComponent<Rat>().Initialize(rats[currentRat], team, path);

        rat.GetComponent<NavMeshAgent>().enabled = false;
        rat.GetComponent<NavMeshAgent>().enabled = true;
    }
}
