using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VideoAdManager : MonoBehaviour, IUnityAdsListener { 

    string gameId = "3386462";
    string myPlacementId = "rewardedVideo";
    bool testMode = true;

    public GameObject modal;
    public GameObject textObject;
    // Initialize the Ads listener and service:
    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }

    public void getRandomAward()
    {

        modal.SetActive(true);
        System.Random random = new System.Random();
        int randomAward = random.Next(1, 50);

        textObject.GetComponent<Text>().text = randomAward + "";
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        getRandomAward();
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId) {
            Advertisement.Show (myPlacementId);
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}