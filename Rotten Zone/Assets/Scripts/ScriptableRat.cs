using System.Collections.Generic;
using UnityEngine;
using DragonBones;

[CreateAssetMenu (menuName ="Rat")]
public class ScriptableRat : ScriptableObject
{
    public string unitName;
    public int health;
    public int attack;
    public int defence;
    public int range;
    public int speed;
    public int capPoints;
    public int cost;

    public AudioClip attackClip;
    public AudioClip deathClip;

    public UnityDragonBonesData dragonBonesData;

    public List<Ability> abilities;
}
