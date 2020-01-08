using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : ScriptableObject
{
    public int velocity;
    public int damage;

    public AudioClip shotClip;

    public abstract void onHit();
}
