using System.Collections.Generic;
using UnityEngine;
using DragonBones;

[CreateAssetMenu (menuName ="Rat")]
public class ScriptableRat : ScriptableObject
{
    public string unitName;
    public bool ranged;
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public int capPoints;
    public int cost;
    public int range;
    public int viewDistance;

    public AudioClip attackClip;
    public AudioClip deathClip;

    public UnityDragonBonesData dragonBonesData;

    public List<Ability> abilities;
}
