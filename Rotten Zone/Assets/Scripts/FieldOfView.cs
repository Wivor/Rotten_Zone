using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private Rat rat;
    [SerializeField]
    private int radius;

    public LayerMask layerMask;

    public List<Rat> enemyRats = new List<Rat>();

    public void Initialize(int radius, Rat rat)
    {
        this.radius = radius;
        this.rat = rat;
    }

    public List<Rat> GetEnemyRatsInRange()
    {
        return Physics.OverlapSphere(transform.position, radius, layerMask)
            .Select(x => x.GetComponent<Rat>())
            .Where(x => x.team != rat.team)
            .ToList();
    }

    public void DrawLinesForRats()
    {
        foreach (Collider hit in Physics.OverlapSphere(transform.position, radius, layerMask))
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
        foreach (Collider hit in Physics.OverlapSphere(transform.position, radius, layerMask))
        {
            Debug.DrawLine(transform.position, hit.gameObject.transform.position);
        }
    }
}
