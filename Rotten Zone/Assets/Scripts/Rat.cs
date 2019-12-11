using DragonBones;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour
{
    public Team team;
    public NavMeshAgent agent;
    public ScriptableRat scriptableRat;
    public int pathPosition;
    public Vector3 capturePosition;
    public FieldOfView fieldOfView;

    UnityArmatureComponent armatureComponent;
    public CapturePoint capturePoint;

    void Start()
    {
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature", gameObject: transform.GetChild(0).gameObject);
        armatureComponent.animation.Play("walking");

        pathPosition = Random.Range(0, 9);
        Vector3 capturePointSize = FindObjectOfType<CapturePoint>().transform.parent.gameObject.GetComponent<Renderer>().bounds.size;
        capturePosition = new Vector3(Random.Range(-capturePointSize.x / 2, capturePointSize.x / 2), 0, Random.Range(-capturePointSize.z / 2, capturePointSize.z / 2));
        
        fieldOfView = GetComponent<FieldOfView>();
        fieldOfView.Initialize(scriptableRat.viewDistance, this);

        GetComponent<RatController>().Initialize(this);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<CapturePoint>() != null)
        {
            capturePoint = collider.GetComponent<CapturePoint>();
            GetComponent<RatController>().SetActionTo(new Capture(this));
        }
    }

    void OnTriggerExit(Collider collider)
    {

    }
}
