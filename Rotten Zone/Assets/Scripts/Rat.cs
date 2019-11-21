using DragonBones;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public ScriptableRat scriptableRat;
    UnityArmatureComponent armatureComponent;

    void Start()
    {
        // załadowanie DragonBonesData do fabryki
        UnityFactory.factory.LoadData(scriptableRat.dragonBonesData);

        // przypisanie komponentu aktualnego obiektu do zmiennej
        // armatureComponent = GetComponent<UnityArmatureComponent>();

        // przypisanie DragonBonesData do komponentu aktualnego obiektu
        // armatureComponent.unityData = scriptableRat.dragonBonesData;
        
        // stworzenie nowego obiektu z fabryki
        armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature");
        
        Debug.Log(armatureComponent.animation);
        armatureComponent.animation.Play("walking");
    }
}
