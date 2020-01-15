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
    public Dictionary<int, ScriptableRat> rats;
    
    // Start is called before the first frame update
    void Start()
    {
        rats = new Dictionary<int, ScriptableRat>();
        rats[1] = rat1;
        rats[2] = rat2;
        rats[3] = rat3;
    }

    public void SpawnUnit(int laneID)
    {
        int score = GetComponent<GameManager>().playerAScore;

        if (rats[currentRat].cost > score)
            return;
        else
            GetComponent<GameManager>().playerAScore -= rats[currentRat].cost;
        switch (laneID)
        {
            case 9:
                GameObject rat1 = Instantiate(ratPrefab);
                rat1.transform.position = GetComponent<GameManager>().pathThree[0].transform.position;
                rat1.GetComponent<NavMeshAgent>().agentTypeID = int.Parse(NavMesh.GetSettingsNameFromID(0));
                rat1.GetComponent<Rat>().Initialize(rats[currentRat]);
                break;
            case 10:
                GameObject rat2 = Instantiate(ratPrefab);
                rat2.transform.position = GetComponent<GameManager>().pathTwo[0].transform.position;
                rat2.GetComponent<NavMeshAgent>().agentTypeID = NavMesh.GetSettingsByIndex(1).agentTypeID;
                rat2.GetComponent<Rat>().Initialize(rats[currentRat]);
                break;
            case 11:
                GameObject rat3 = Instantiate(ratPrefab);
                rat3.transform.position = GetComponent<GameManager>().pathOne[0].transform.position;
                rat3.GetComponent<NavMeshAgent>().agentTypeID = NavMesh.GetSettingsByIndex(2).agentTypeID;
                rat3.GetComponent<Rat>().Initialize(rats[currentRat]);
                break;
        }
    }
}
