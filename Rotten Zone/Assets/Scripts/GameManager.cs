using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject textObject;

    public int baseAhealth = 500;
    public int baseBhealth = 500;

    public bool isPaused = false;

    public int playerAScore = 100;
    public int playerBScore = 100;

    public List<List<Transform>> paths = new List<List<Transform>>();

    public List<Transform> pathOne = new List<Transform>();
    public List<Transform> pathTwo = new List<Transform>();
    public List<Transform> pathThree = new List<Transform>();

    public HashSet<CapturePoint> teamAPoints = new HashSet<CapturePoint>();
    public HashSet<CapturePoint> teamBPoints = new HashSet<CapturePoint>();

    private System.Timers.Timer timer;

    void Awake()
    {
        paths.Add(pathThree);
        paths.Add(pathTwo);
        paths.Add(pathOne);
        SetTimer();
        var ai = GetComponent<PrimitiveAI>();
        ai.enabled = true;
    }

    private void SetTimer()
    {
        timer = new System.Timers.Timer(5000);
        timer.Elapsed += new System.Timers.ElapsedEventHandler(this.UpdatePoints);
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    public void TogglePause()
    {
        timer.Enabled = !timer.Enabled;
        isPaused = !isPaused;
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

        if(textObject != null){
             textObject.GetComponent<Text>().text = playerAScore+ "";
        }
    }

    public void OnApplicationQuit()
    {
        timer.Stop();
    }

}
