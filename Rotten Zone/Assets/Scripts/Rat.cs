using DragonBones;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public ScriptableRat scriptableRat;
    UnityArmatureComponent armatureComponent;

    void Start()
    {
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("rat_model", "rat_model");
        Debug.Log(armatureComponent);
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        armatureComponent.animation.Play("animation0");
    }
}
