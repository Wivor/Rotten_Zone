using UnityEngine;

public abstract class AttackableObject : MonoBehaviour
{
    public Team team;

    public abstract void DealDamage(int damage);
}
