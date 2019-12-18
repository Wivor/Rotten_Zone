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
    public CapturePoint capturePoint;

    UnityArmatureComponent armatureComponent;
    Statistics Statistics;

    void Start()
    {
        Statistics = new Statistics(scriptableRat);

        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature1", gameObject: transform.GetChild(0).gameObject);
        armatureComponent.animation.Play("walking");

        pathPosition = Random.Range(0, 9);
        Vector3 capturePointSize = FindObjectOfType<CapturePoint>().transform.parent.gameObject.GetComponent<Renderer>().bounds.size;
        capturePosition = new Vector3(Random.Range(-capturePointSize.x / 2, capturePointSize.x / 2), 0, Random.Range(-capturePointSize.z / 2, capturePointSize.z / 2));
        
        fieldOfView = GetComponent<FieldOfView>();
        fieldOfView.Initialize(scriptableRat.viewDistance, this);

        GetComponent<RatController>().Initialize(this);
    }

    public void DealDamage(int dmg)
    {
        Statistics.health -= dmg;
        if (Statistics.health <= 0)
        {
            if (capturePoint != null)
            {
                capturePoint.RemoveRatFromList(this);
            }
            Destroy(gameObject);
        }
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
