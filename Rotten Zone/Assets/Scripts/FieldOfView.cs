using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private Rat rat;
    [SerializeField]
    private int radius;

    public LayerMask unitLayerMask;
    public LayerMask gateLayerMask;

    public void Initialize(int radius, Rat rat)
    {
        this.radius = radius;
        this.rat = rat;
    }

    public List<Rat> GetEnemyRatsInRange()
    {
        return Physics.OverlapSphere(transform.position, radius, unitLayerMask)
            .Select(x => x.GetComponent<Rat>())
            .Where(x => x.team != rat.team)
            .ToList();
    }

    public List<Gate> GetEnemyGateInRange()
    {
        return Physics.OverlapSphere(transform.position, radius, gateLayerMask)
            .Select(x => x.GetComponent<Gate>())
            .Where(x => x.team != rat.team)
            .ToList();
    }

    public void DrawLinesForRats()
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, radius, unitLayerMask))
        {
            if (hit.GetComponent<Rat>().team != rat.team)
            {
                Debug.DrawLine(transform.position, hit.gameObject.transform.position, Color.red);
            }
            else if (hit.GetComponent<Rat>().team == rat.team)
            {
                Debug.DrawLine(transform.position, hit.gameObject.transform.position, Color.green);
            }
        }
    }

    public void DrawLinesForEverything()
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, radius, unitLayerMask))
        {
            Debug.DrawLine(transform.position, hit.gameObject.transform.position);
        }
    }
}
