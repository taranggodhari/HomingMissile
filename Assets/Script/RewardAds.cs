using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class RewardAds : MonoBehaviour
{
	public GameObject ShowAdsDialog, VideoWatchedDialog, AdNotReadyDialog;
    public string AppID;

    private RewardBasedVideoAd rewardBasedVideo;
    private float deltaTime = 0.0f;
   
    void Start()
    {
        // Get singleton reward based video ad reference.

//         RewardBasedVideoAd is a singleton, so handlers should only be registered once.
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

		RequestRewardBasedVideo ();
    }

    void Update()
    {



        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

   
    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestRewardBasedVideo()
    {
        #if UNITY_EDITOR
        string adUnitId = "AppID";
        #elif UNITY_ANDROID
		string adUnitId = AppID;
    #elif UNITY_IPHONE
		    string adUnitId = "ca-app-pub-7850304550335702/1221009279";
    #else
            string adUnitId = "unexpected_platform";
    #endif

            rewardBasedVideo.LoadAd(createAdRequest(), adUnitId);
    }

    

	public void ShowRewardBasedVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
			if(ShowAdsDialog.activeInHierarchy == false)
			ShowAdsDialog.SetActive (true);  
        } 
		else
        {
			if(AdNotReadyDialog.activeInHierarchy == false)
			AdNotReadyDialog.SetActive (true);
        }
    }

	public void ShowRewardAds()
	{
		rewardBasedVideo.Show();
	}

  
    

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLoaded event received.");
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
		if(AdNotReadyDialog.activeInHierarchy == false)
		AdNotReadyDialog.SetActive (true);
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);


    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoOpened event received");
	
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoStarted event received");
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
		RequestRewardBasedVideo ();
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);

		if(VideoWatchedDialog.activeInHierarchy == false)
		VideoWatchedDialog.SetActive (true);
		  
	}

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLeftApplication event received");
		if(ShowAdsDialog.activeInHierarchy ==true)
		ShowAdsDialog.SetActive (false);

    }

    #endregion
}
