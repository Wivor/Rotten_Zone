using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Rat rat;
    private int radius;

    public LayerMask layerMask;

    public void Initialize(int radius, Rat rat)
    {
        this.radius = radius;
        this.rat = rat;
    }

    public void Update()
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, radius, layerMask))
        {
            if (hit.GetComponent<Rat>().team != rat.team)
            {
                Debug.DrawLine(transform.position, hit.gameObject.transform.position, Color.red);
            }
            if (hit.GetComponent<Rat>().team == rat.team)
            {
                Debug.DrawLine(transform.position, hit.gameObject.transform.position, Color.green);
            }
        }
    }
}
