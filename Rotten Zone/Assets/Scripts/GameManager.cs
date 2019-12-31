using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Base baseA;
    public Base baseB;

    public int playerAScore = 100;
    public int playerBScore = 100;

    public List<List<Transform>> paths = new List<List<Transform>>();

    public List<Transform> pathOne = new List<Transform>();
    public List<Transform> pathTwo = new List<Transform>();
    public List<Transform> pathThree = new List<Transform>();

    public List<Vector3> positions = new List<Vector3>();

    public HashSet<CapturePoint> teamAPoints = new HashSet<CapturePoint>();
    public HashSet<CapturePoint> teamBPoints = new HashSet<CapturePoint>();

    private float radius = 0.35f;

    private System.Timers.Timer timer;

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
        SetTimer();
    }

    private void SetTimer()
    {
        timer = new System.Timers.Timer(5000);
        timer.Elapsed += new System.Timers.ElapsedEventHandler(this.UpdatePoints);
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private void UpdatePoints(object source, System.Timers.ElapsedEventArgs e)
    {
        playerAScore += 30;
        playerBScore += 30;
        foreach (CapturePoint cap in teamAPoints)
        {
            playerAScore += (int)(cap.income * cap.distanceModifier);
        }
        foreach (CapturePoint cap in teamBPoints)
        {
            playerBScore += (int)(cap.income * cap.distanceModifier);
        }
        Debug.Log(playerAScore);
        Debug.Log(playerBScore);
    }
}
