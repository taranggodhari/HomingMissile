using UnityEngine;
using System.Collections;

public class AdColonyScoreDoubleAds : MonoBehaviour
{
    public string appid;
    public string zoneid;
    public string appversion;
    public GameObject GameOverAnimator;
    ScoreManager myScoreManager;

    public static AdColonyScoreDoubleAds Instance { get; set; }
    // Use this for initialization

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        GameOverAnimator.GetComponent<Animator>().Play("ScoreDoublerActive");
        myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
        AdColony.OnV4VCResult = V4VCResult;
        AdColony.Configure(appversion, appid, zoneid);
    }
    private void V4VCResult(bool success, string name, int amount)
    {
        if (success)
        {
       
            myScoreManager.UpdateScoreDoubler();
            GameOverAnimator.GetComponent<Animator>().Play("ScoreDoublerDeactive");
              Debug.Log("V4VC SUCCESS: name = " + name + ", amount = " + amount);
        }
        else
            Debug.LogWarning("V4VC FAILED!");
    }

    public void ShowAds()
    {
        print("adsShowm");
        AdColony.ShowV4VC(false, zoneid);
    }

   


}
