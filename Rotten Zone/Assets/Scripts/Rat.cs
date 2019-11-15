using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Rat")]
public class Rat : ScriptableObject
{
    public string unitName;
    public int healt;
    public int attack;
    public int defence;
    public int speed;
    public int cost;

    public AudioClip attackClip;
    public AudioClip deathClip;

    public List<Ability> abilities;
}
