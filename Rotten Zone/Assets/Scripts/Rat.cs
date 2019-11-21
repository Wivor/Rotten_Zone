using DragonBones;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public ScriptableRat scriptableRat;
    UnityArmatureComponent armatureComponent;

    void Start()
    {
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature", gameObject: gameObject);
        armatureComponent.animation.Play("walking");
    }
}
