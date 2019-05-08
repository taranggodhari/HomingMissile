using UnityEngine;
using System.Collections;

public class AdColonyInterstialAds : MonoBehaviour
{

    public static AdColonyInterstialAds Instance { get; set; }

    public string appId;
    public string zoneId;
    public string versionId;
    public GameObject GameOverAnimator;
    public int coins;
    ScoreManager myScoreManager;
    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
    void Start()
    {
        myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
        AdColony.OnV4VCResult = V4VCResult;


        AdColony.Configure(versionId, appId, zoneId);

    }

    void Update()
    {
        ScoreDoublerAdsAvailability();
    }


    private void V4VCResult(bool success, string name, int amount)
    {
        if (success)
        {

            myScoreManager.UpdateRewardedAdsScore();

            Debug.Log("V4VC SUCCESS: name = " + name + ", amount = " + amount);
        }
        else
        {


            Debug.LogWarning("V4VC FAILED!");
        }
    }
    public void ScoreDoublerAdsAvailability()
    {
        if (AdColony.IsV4VCAvailable(zoneId))
        {
            GameOverAnimator.GetComponent<Animator>().Play("ScoreDoublerActive");
            //PlayV4VCAd(zoneid3, false, false);  
        }
        else
        {
            GameOverAnimator.GetComponent<Animator>().Play("ScoreDoublerDeactive");
        }

    }
    public void ShowScoreDoublerAds()
    {
        AdColony.ShowV4VC(false, zoneId);
    }
	// Update is called once per frame
	
  

}
