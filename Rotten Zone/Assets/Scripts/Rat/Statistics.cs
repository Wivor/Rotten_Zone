using UnityEngine;
using System;

[Serializable]
public class Statistics
{
    public bool ranged;
    public int health;
    public int currentHealth;
    public int attack;
    public int attackSpeed;
    public int defence;
    public float range;
    public int speed;
    public int capPoints;
    public int cost;
    
    public Statistics(ScriptableRat scriptableRat)
    {
        ranged = scriptableRat.ranged;
        health = scriptableRat.health;
        currentHealth = scriptableRat.health;
        attack = scriptableRat.attack;
        attackSpeed = scriptableRat.attackSpeed;
        defence = scriptableRat.defence;
        range = scriptableRat.range;
        speed = scriptableRat.speed;
        capPoints = scriptableRat.capPoints;
        cost = scriptableRat.capPoints;
    }
}
