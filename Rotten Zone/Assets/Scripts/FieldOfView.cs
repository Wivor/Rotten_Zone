using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public class ExampleClass : MonoBehaviour
    {
        void Update()
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward);

            foreach (RaycastHit hit in hits)
            {
                Debug.Log("hit");
            }
            
        }
    }
}
