using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnUnit", 4.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int Decide()
    {
        System.Random rand = new System.Random();
        return rand.Next(9, 11);
    }

    private void SpawnUnit()
    {
        int temp = Decide();
        FindObjectOfType<UnitSpawner>().SpawnUnit(temp, true);
    }
}
