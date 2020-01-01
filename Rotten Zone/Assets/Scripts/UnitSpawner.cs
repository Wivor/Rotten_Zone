using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitSpawner : MonoBehaviour
{
    public GameObject rat1;
    public GameObject rat2;
    public GameObject rat3;
    public int currentRat = 1;

    private Dictionary<int, GameObject> rats;
    private Vector3 base1;
    private Vector3 base2;
    private Vector3 base3;
    // Start is called before the first frame update
    void Start()
    {
        rats = new Dictionary<int, GameObject>();
        rats[1] = rat1;
        rats[2] = rat2;
        rats[3] = rat3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUnit(int laneID)
    {
        switch (laneID)
        {
            case 9:
                GameObject rat1 = Instantiate(rats[currentRat]);
                rat1.GetComponent<NavMeshAgent>().agentTypeID = NavMesh.GetSettingsByIndex(2).agentTypeID;
                break;
            case 10:
                GameObject rat2 = Instantiate(rats[currentRat]);
                rat2.GetComponent<NavMeshAgent>().agentTypeID = NavMesh.GetSettingsByIndex(1).agentTypeID;
                break;
            case 11:
                GameObject rat3 = Instantiate(rats[currentRat]);
                rat3.GetComponent<NavMeshAgent>().agentTypeID = int.Parse(NavMesh.GetSettingsNameFromID(0));
                break;
        }
    }
}
