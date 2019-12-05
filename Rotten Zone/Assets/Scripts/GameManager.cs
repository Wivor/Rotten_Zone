using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Base baseA;
    public Base baseB;

    public List<List<Transform>> paths = new List<List<Transform>>();

    public List<Transform> pathOne = new List<Transform>();
    public List<Transform> pathTwo = new List<Transform>();
    public List<Transform> pathThree = new List<Transform>();

    public List<Vector3> positions = new List<Vector3>();

    private float radius = 0.35f;

    void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            positions.Add(new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius)));
        }

        foreach(Corner corner in FindObjectsOfType<Corner>())
        {
            corner.Initialize(positions);
        }

        paths.Add(pathOne);
        paths.Add(pathTwo);
        paths.Add(pathThree);
    }
}
