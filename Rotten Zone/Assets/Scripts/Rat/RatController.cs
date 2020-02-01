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

    public void Initialize(Rat rat, int pathID)
    {
        this.rat = rat;
        path = new List<Transform>(FindObjectOfType<GameManager>().paths[pathID]);

        if (rat.team == Team.B)
        {
            path.Reverse();
        }

        transform.position = path[0].position;
        stepOnPath = 1;

        currentAction = new Move(rat);
    }


    void Update()
    {
        currentAction.Update();
    }

    public void SetActionTo(Action action)
    {
        currentAction = action;
    }

    public bool IsFighting()
    {
        if (currentAction is Attack || currentAction is ApproachMeele)
        {
            return true;
        }
        return false;
    }

    public bool IsFightingGate()
    {
        if (currentAction is AttackBase)
        {
            return true;
        }
        return false;
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
