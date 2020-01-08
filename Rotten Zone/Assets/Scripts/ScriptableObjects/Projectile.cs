using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ScriptableObject
{
    public int velocity;
    public float damageMultiplier; //in future

    public AudioClip shotClip;

    public void onHit(Rat target, int damage)
    {
        target.DealDamage(damage + (int)Random.Range(-damage * 0.2f, damage * 0.2f));
    }
}
