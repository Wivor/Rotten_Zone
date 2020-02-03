using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    private string id = "3386462";
    private string video = "rewardedVideo";

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

        textObject.GetComponent<Text>().text =randomAward+"";
    }

    public void getsmallAward()
    {
         System.Random random = new System.Random();
         int randomAward = random.Next(1, 20);
        modal.SetActive(true);
        textObject.GetComponent<Text>().text = randomAward+"";
        
    }

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
    public void ShowAd () {
        StartCoroutine (WaitForAd ());
    }

    IEnumerator WaitForAd () {
        while (!Monetization.IsReady (video)) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (video) as ShowAdPlacementContent;

        if (ad != null) {
            ad.Show (AdFinished);
        }
    }

    void AdFinished (ShowResult result) {
        if (result == ShowResult.Finished) {
            getRandomAward();
        }
        else{
            getsmallAward();
        }
        
    }


}
