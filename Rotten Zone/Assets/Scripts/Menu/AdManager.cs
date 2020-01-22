using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    private string id = "3386462";
    private string video = "video";

    public GameObject modal;
    public GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(id,true);
    }

    public void getRandomAward()
    {

        modal.SetActive(true);
        System.Random random = new System.Random();
        int randomAward = random.Next(1, 50);

        textObject.GetComponent<Text>().text = randomAward + "";
    }

    // Update is called once per frame
    public void Adshower()
    {
        if(Monetization.IsReady(video)){
            ShowAdPlacementContent ad =null;
            ad = Monetization.GetPlacementContent(video) as ShowAdPlacementContent;
            if(ad != null)
            {
                ad.Show();
                getRandomAward();
            }
        }
    }
}
