using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    public bool turnRight;
    public List<Transform> waypoints = new List<Transform>();

    public void Initialize(List<Vector3> positions)
    {
        foreach (Vector3 waypoint in positions)
        {
            GameObject temp = new GameObject();
            temp.name = "Waypoint";
            temp.transform.parent = transform;
            temp.transform.localPosition = waypoint;
            waypoints.Add(temp.transform);
        }
    }
}
