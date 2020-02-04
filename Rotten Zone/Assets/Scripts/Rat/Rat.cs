using DragonBones;
using UnityEngine;
using UnityEngine.AI;

public class Rat : AttackableObject
{
    public NavMeshAgent agent;
    public int pathPosition;
    public Vector3 capturePosition;
    public FieldOfView fieldOfView;
    [SerializeField]
    public CapturePoint capturePoint;
    public Gate gate;

    UnityArmatureComponent armatureComponent;

    [SerializeField]
    public Statistics Statistics;

    //-------------- FOR ANIMATION TESTING
    /*
    public ScriptableRat scriptableRat;
    private void Start()
    {
        Initialize(scriptableRat, team, 0);
    }
    */
    //-------------- FOR ANIMATION TESTING

    public void Initialize(ScriptableRat scriptableRat, Team team, int path)
    {
        Statistics = new Statistics(scriptableRat);
        this.team = team;

        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("melee_unit", gameObject: transform.GetChild(0).gameObject);

        pathPosition = Random.Range(0, 9);
        //Vector3 capturePointSize = FindObjectOfType<CapturePoint>().transform.parent.gameObject.GetComponent<Renderer>().bounds.size;
        Vector3 capturePointSize = new Vector3(1, 1, 1);
        capturePosition = new Vector3(Random.Range(-capturePointSize.x / 2, capturePointSize.x / 2), 0, Random.Range(-capturePointSize.z / 2, capturePointSize.z / 2));

        fieldOfView = GetComponent<FieldOfView>();
        fieldOfView.Initialize(scriptableRat.viewDistance, this);
        
        if (team == Team.B)
        {
            armatureComponent.armature.flipX = true;
        }

        agent.speed = Statistics.speed;
        GetComponent<AnimationsController>().Initialize(armatureComponent);
        GetComponent<RatController>().Initialize(this, path);
        GetComponent<HealthBar>().Initialize(this);
    }

    public override void DealDamage(int damage)
    {
        Statistics.currentHealth -= damage;
        GetComponent<HealthBar>().UpdateBar(Statistics.currentHealth, Statistics.health);

        if (Statistics.currentHealth <= 0)
        {
            if (GetComponent<RatController>().currentAction is Capture)
            {
                capturePoint.captureChange -= CapPointChange();
            }
            Destroy(gameObject);
        }
    }

    public int CapPointChange()
    {
        if (team == Team.A)
        {
            return Statistics.capPoints;
        }
        else
        {
            return -Statistics.capPoints;
        }
    }

    public bool IsRanged()
    {
        return Statistics.ranged;
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
