using UnityEngine;

public abstract class Ability : ScriptableObject
{
    string abilityName;
    float cooldown;

    public abstract void Initialize();
    public abstract void Cast();
}
