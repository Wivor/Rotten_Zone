using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RewardGenerator : MonoBehaviour
{
    public GameObject modal;
    public GameObject textObject;
   
    public void getAward()
    {
        if(modal != null){
            modal.SetActive(true);
        }
        
        System.Random random = new System.Random();
        int randomAward= random.Next(1, 50);

        textObject.GetComponent<Text>().text = randomAward+ "";
    }

 

}
