using UnityEngine;
using System.Collections;

public class AdColonyVCV4 : MonoBehaviour {
    public string appid;
    public string zoneid;
    public string zoneid2;
    public string appversion;
    public GameObject ShowAdsDialog;
    public GameObject VideoWatchedDialog;
    //public GameObject homeScreen, Gameoverscreen, GameOverAnimator;

    public int coins;
    ScoreManager myScoreManager;

    public static AdColonyVCV4 Instance { get; set; }
	// Use this for initialization
    void Awake()
    {
        Instance = this;
    }
void Start () 
{
    myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof (ScoreManager));
    AdColony.OnV4VCResult = V4VCFinished;
    AdColony.OnVideoFinished = VideoFinished;
    AdColony.Configure(appversion, appid, zoneid,zoneid2);
}
 
void VideoFinished(bool b)
{
   
    
}

   
private void V4VCFinished(bool success, string name, int amount)
{
if(success)
{
        if (ShowAdsDialog.activeInHierarchy == true)
            ShowAdsDialog.SetActive(false);
        if (VideoWatchedDialog.activeInHierarchy == false)
            VideoWatchedDialog.SetActive(true);
         myScoreManager.UpdateRewardedAdsScore();
}
else
{
    Debug.LogWarning("V4VC FAILED!");   
}
}



public void ShowInterstials()
{
    AdColony.ShowVideoAd(zoneid2);
}
public void ShowAds()
{
     
    AdColony.ShowV4VC(false, zoneid);
}
    

    
}
