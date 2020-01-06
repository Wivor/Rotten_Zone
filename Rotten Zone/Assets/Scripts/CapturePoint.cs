using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public Material teamAMaterial;
    public Material teamBMaterial;

    public Team owner;
    public float capturePoints = 50;
    public float distanceModifier = 2.0f;

    public int income = 50;
    public int captureChange;

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
}
