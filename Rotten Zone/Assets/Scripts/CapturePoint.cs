using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public Team owner = Team.none;
    public int capturePoints = 50;

    public int captureChange;

    void FixedUpdate()
    {
        if (owner == Team.none)
        {
            capturePoints += captureChange;
            if(capturePoints == 100)
            {
                owner = Team.A;
            }
            if (capturePoints == 0)
            {
                owner = Team.B;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Rat rat = collider.gameObject.GetComponent<Rat>();

        if (rat.team == Team.A)
        {
            captureChange += rat.scriptableRat.capPoints;
        }
        else
        {
            captureChange -= rat.scriptableRat.capPoints;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Rat rat = collider.gameObject.GetComponent<Rat>();

        if (rat.team == Team.A)
        {
            captureChange -= rat.scriptableRat.capPoints;
        }
        else
        {
            captureChange += rat.scriptableRat.capPoints;
        }
    }
}
