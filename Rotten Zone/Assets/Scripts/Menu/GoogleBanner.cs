using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleBanner : MonoBehaviour
{
    private BannerView bannerView;
    
    public void Start()
    {
        string appId = "ca-app-pub-3940256099942544~3347511713";
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {

        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

     void OnDestroy() {
        this.bannerView.Destroy();
    }
}