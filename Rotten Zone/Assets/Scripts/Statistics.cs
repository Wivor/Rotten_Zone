public class Statistics
{
    public int health;
    public int attack;
    public int defence;
    public int range;
    public int speed;
    public int capPoints;
    public int cost;

    public Statistics(ScriptableRat scriptableRat)
    {
        health = scriptableRat.health;
        attack = scriptableRat.attack;
        defence = scriptableRat.defence;
        range = scriptableRat.range;
        speed = scriptableRat.speed;
        capPoints = scriptableRat.capPoints;
        cost = scriptableRat.capPoints;
    }
}
