using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    Rat rat;
    public int stepOnPath = 1;
    public List<Transform> path;

    private Action action;
    private Vector3 destination;

    public void Initialize(Rat rat)
    {
        this.rat = rat;
        path = new List<Transform>(FindObjectOfType<GameManager>().paths[int.Parse(NavMesh.GetSettingsNameFromID(rat.agent.agentTypeID))]);

        if (rat.team == Team.A)
        {
            path.Reverse();
        }

        SetDestinationToNextWaypoint();
        MoveForward();
    }

    void Update()
    {
        if ((rat.agent.remainingDistance < rat.agent.stoppingDistance) && (stepOnPath != path.Count -1))
        {
            stepOnPath++;
            SetDestinationToNextWaypoint();
        }
    }

    private void MoveForward()
    {
        action = Action.MoveForward;
        rat.agent.SetDestination(destination);
    }

    private void SetDestinationToNextWaypoint()
    {
        if(path[stepOnPath].GetComponent<Corner>() != null)
        {
            destination = path[stepOnPath].GetComponent<Corner>().waypoints[rat.pathPosition].transform.position;
            
        }
        else
        {
            destination = path[stepOnPath].position;
        }
        if (action == Action.MoveForward)
        {
            MoveForward();
        }
    }
}

public enum Action
{
    MoveForward
}
