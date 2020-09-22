using DragonBones;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimationsController : MonoBehaviour
{
    public UnityArmatureComponent armatureComponent;
    List<string> animationList = new List<string>();

    public void Initialize(UnityArmatureComponent armatureComponent)
    {
        this.armatureComponent = armatureComponent;
    }

    private void Update()
    {
        if (AnimationIsFinished() && animationList.Count != 0)
        {
            animationList.Remove(animationList.First());
            if (animationList.Count == 0)
                return;
            ChangeAnimationTo(animationList.First(), 1);
        }
    }

    public void AddAnimationToQueue(string animationName)
    {
        if (animationList.Count == 0)
        {
            animationList.Add(animationName);
            ChangeAnimationTo(animationName, 1);
        }
        else
        {
            animationList.Add(animationName);
        }
    }

    public void ClearQueue()
    {
        animationList.Clear();
    }

    internal bool IsQueueEmpty()
    {
        if(animationList.Count == 0)
            return true;
        return false;
    }

    public void ChangeAnimationTo(string animationName, int timesPlayed = -1)
    {
        armatureComponent.animation.Play(animationName, timesPlayed);
    }

    public bool AnimationIsFinished()
    {
        return armatureComponent.animation.isCompleted;
    }

    public string CurrentAnimationName()
    {
        return armatureComponent.animation.lastAnimationName;
    }
}
