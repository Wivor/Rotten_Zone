using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RewardGenerator : MonoBehaviour
{
    public GameObject modal;
    public Text txt;
    public void getAward()
    {
        modal.SetActive(true);
        System.Random random = new System.Random();
        int randomAward= random.Next(1, 30);

        txt = gameObject.GetComponent<Text>();
        txt.text = "Score : " + randomAward;
    }

}
