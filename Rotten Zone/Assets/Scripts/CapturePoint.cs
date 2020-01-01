using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public Material teamAMaterial;
    public Material teamBMaterial;

    public Team owner;
    public float capturePoints = 50;
    public int captureChange;

    void FixedUpdate()
    {
        capturePoints += captureChange * Time.deltaTime;
        if (capturePoints >= 100)
        {
            capturePoints = 100;
            owner = Team.A;
            GetComponent<Renderer>().material = teamAMaterial;
        }
        if (capturePoints <= 0)
        {
            capturePoints = 0;
            owner = Team.B;
            GetComponent<Renderer>().material = teamBMaterial;
        }
    }
}
