using UnityEngine;
using System;

[Serializable]
public class Statistics
{
    public bool ranged;
    public int health;
    public int attack;
    public int attackSpeed;
    public int defence;
    public int range;
    public int speed;
    public int capPoints;
    public int cost;
    
    public Statistics(ScriptableRat scriptableRat)
    {
        ranged = scriptableRat.ranged;
        health = scriptableRat.health;
        attack = scriptableRat.attack;
        attackSpeed = scriptableRat.attackSpeed;
        defence = scriptableRat.defence;
        range = scriptableRat.range;
        speed = scriptableRat.speed;
        capPoints = scriptableRat.capPoints;
        cost = scriptableRat.capPoints;
    }
}
