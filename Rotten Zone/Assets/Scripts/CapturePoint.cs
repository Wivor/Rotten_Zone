using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public Material teamAMaterial;
    public Material teamBMaterial;

    public Team owner;
    public float capturePoints = 50;

    public int income = 50;
    public int captureChange;
    public List<Rat> ratsAInRange = new List<Rat>();
    public List<Rat> ratsBInRange = new List<Rat>();

    void FixedUpdate()
    {
            capturePoints += captureChange * Time.deltaTime;
            if(capturePoints >= 100)
            {
                capturePoints = 100;
                owner = Team.A;
                FindObjectOfType<GameManager>().teamAPoints.Add(this);
                if (FindObjectOfType<GameManager>().teamBPoints.Contains(this))
                    FindObjectOfType<GameManager>().teamBPoints.Remove(this);
                GetComponent<Renderer>().material = teamAMaterial;
            }
            if (capturePoints <= 0)
            {
                capturePoints = 0;
                owner = Team.B;
                FindObjectOfType<GameManager>().teamBPoints.Add(this);
                    if (FindObjectOfType<GameManager>().teamAPoints.Contains(this))
                    FindObjectOfType<GameManager>().teamAPoints.Remove(this);
                GetComponent<Renderer>().material = teamBMaterial;
            }
    }

    void OnTriggerEnter(Collider collider)
    {
        Rat rat = collider.gameObject.GetComponent<Rat>();

        AddRatToList(rat);
    }

    void OnTriggerExit(Collider collider)
    {
        Rat rat = collider.gameObject.GetComponent<Rat>();

        RemoveRatFromList(rat);
    }

    public void RemoveRatFromList(Rat rat)
    {
        if (rat.team == Team.A)
        {
            captureChange -= rat.scriptableRat.capPoints;
            ratsAInRange.Remove(rat);
        }
        else
        {
            captureChange += rat.scriptableRat.capPoints;
            ratsBInRange.Remove(rat);
        }
    }

    public void AddRatToList(Rat rat)
    {
        if (rat.team == Team.A)
        {
            captureChange += rat.scriptableRat.capPoints;
            ratsAInRange.Add(rat);
        }
        else
        {
            captureChange -= rat.scriptableRat.capPoints;
            ratsBInRange.Add(rat);
        }
    }
}
