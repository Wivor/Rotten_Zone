using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class Baner : MonoBehaviour
{
     public string gameId = "3386462";
    public string placementId = "rottenBanner";
    public bool testMode = true;

    void Start () {
        Monetization.Initialize (gameId,testMode);
        Advertisement.Initialize (gameId, testMode);
        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            yield return new WaitForSeconds (2.5f);
        }
        // Advertisement.Banner.SetPosition (BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show (placementId);
    }
}
