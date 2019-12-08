using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    Rat rat;
    public int stepOnPath;
    public List<Transform> path;

    public Action currentAction;
    
    private Vector3 destination;

    public void Initialize(Rat rat)
    {
        this.rat = rat;
        path = new List<Transform>(FindObjectOfType<GameManager>().paths[int.Parse(NavMesh.GetSettingsNameFromID(rat.agent.agentTypeID))]);

        if (rat.team == Team.A)
        {
            path.Reverse();
        }

        stepOnPath = 1;
        
        currentAction = new Move(rat);
    }


    void Update()
    {
        currentAction.Update();
    }

    public void ChangeActionTo(Action action)
    {
        currentAction = action;
    }

    public Vector3 GetDestinationOfNextWaypoint()
    {
        if (path[stepOnPath].GetComponent<Corner>() != null)
        {
            return path[stepOnPath].GetComponent<Corner>().waypoints[rat.pathPosition].transform.position;
        }
        else
        {
            return path[stepOnPath].position;
        }
    }
}
