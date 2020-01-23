using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    public Camera camera;
    RaycastHit hit;

    void Start()
    {
    }

    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            Transform objectHit = hit.transform;
            if(Enumerable.Range(9, 11).Contains(objectHit.gameObject.layer)){
                //Debug.Log("Spawn " + objectHit.gameObject.layer);
                FindObjectOfType<UnitSpawner>().SpawnUnit(objectHit.gameObject.layer, false);
            }
        }
    }
}
