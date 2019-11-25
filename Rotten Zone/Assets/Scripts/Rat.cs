using DragonBones;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour
{
    public NavMeshAgent agent;
    public ScriptableRat scriptableRat;
    UnityArmatureComponent armatureComponent;

    void Start()
    {
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature", gameObject: transform.GetChild(0).gameObject);
        armatureComponent.animation.Play("walking");

        //agent.SetDestination();
    }
}
