using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;


public class FullAds : MonoBehaviour
{
    public string appID;
    InterstitialAd interstitial;

    void Start()
    {

#if UNITY_EDITOR
        interstitial = new InterstitialAd("");
#elif UNITY_ANDROID
		interstitial = new InterstitialAd(appID);
#elif UNITY_IPHONE
		interstitial = new InterstitialAd("ca-app-pub-6162761281029642/9606254618");
#endif

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void ShowAds()
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
    }

}
