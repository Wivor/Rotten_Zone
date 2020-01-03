using DragonBones;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    UnityArmatureComponent armatureComponent;

    public void Initialize(UnityArmatureComponent armatureComponent)
    {
        this.armatureComponent = armatureComponent;
    }

    public void ChangeAnimationTo(string animationName, int timesPlayed = -1)
    {
        armatureComponent.animation.Play(animationName, timesPlayed);
    }

    public bool IsAnimationFinished()
    {
        return armatureComponent.animation.isCompleted;
    }
}
