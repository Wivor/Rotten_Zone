using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RewardGenerator : MonoBehaviour
{
    public GameObject modal;
    public GameObject textObject;
    public Text txt;
    public void getAward()
    {
        txt = GetComponent<Text>();
        modal.SetActive(true);
        System.Random random = new System.Random();
        int randomAward= random.Next(1, 30);

        
        txt.text = "Your award: " + randomAward;
        textObject.GetComponent<Text>().text = "Your award: " + randomAward;
    }

}
