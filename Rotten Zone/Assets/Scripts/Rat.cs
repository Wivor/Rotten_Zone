using DragonBones;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour
{
    public Team team;
    public NavMeshAgent agent;
    public ScriptableRat scriptableRat;
    public int pathPosition;

    UnityArmatureComponent armatureComponent;
    public CapturePoint capturePoint;

    void Start()
    {
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature", gameObject: transform.GetChild(0).gameObject);
        armatureComponent.animation.Play("walking");

        pathPosition = Random.Range(0, 9);

        GetComponent<RatController>().Initialize(this);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<CapturePoint>() != null)
        {
            capturePoint = collider.GetComponent<CapturePoint>();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<CapturePoint>() != null)
        {
            capturePoint = null;
        }
    }
}
