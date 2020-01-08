using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour
{
    private string id = "3386462";
    private string video = "video";

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(id,true);
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
            }
        }
    }
}
