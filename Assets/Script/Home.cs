using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class Home : MonoBehaviour {
	public GameObject homeScreen;
    public GameObject planedialogBox, AdNotReadyDialog, ShowAdsDialog, VideoWatchedDialog, QuitDialogBox, NoAdsDialog, BuyPlaneDialog;
	public GameObject gameScreen,gameoverScreen;
	public GameObject inGameUI;
	public GameObject playButton;

	public GameObject plane;
    public GameObject helliRotater;
	public Sprite plane1;
	public Sprite plane2;
	public Sprite plane3;
	public Sprite plane4;
	public Sprite plane5;
    public Sprite plane6;

//	public Sprite[] PlaneSprites;
	GameManager myGameManager;
	ScrollSnapRect myScroller;
	PlaneController myPlaneController;
	ScoreManager myScoreManager;

//	MissileSpawn myMissileSpawn;
	// Use this for initialization
	void Start () 
	{		
//		PlayerPrefs.SetInt ("TotalScore", 20000);
//		PlayerPrefs.DeleteAll();

		myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
		myGameManager = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));

		myScroller = (ScrollSnapRect)GameObject.FindObjectOfType(typeof(ScrollSnapRect));
//		myMissileSpawn = GameObject.Find ("RedMissileSpawner").GetComponent<MissileSpawn> ();
		if (PlayerPrefs.GetInt ("Restart") == 1) {
//			GameObject.Find ("BannerAds").GetComponent<BannerShow> ().bannerView.Hide ();

			GameScreen ();
		} 

	}
	void Update()
	{
		

		
//		for (int i = 0; i < PlaneSprites.Length; i +=1) 
//		{
//			if (myScroller._currentPage == i)
//			print ("CurrentPage" + myScroller._currentPage);
//			plane.GetComponent<SpriteRenderer> ().sprite = PlaneSprites [i];
//			PlayerPrefs.SetInt ("Plane", i);
//		}
//
//		PlayerPrefs.DeleteAll ();
		if (myScroller._currentPage == 0) {
			plane.GetComponent<SpriteRenderer> ().sprite = plane1;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
			PlayerPrefs.SetInt ("Plane", 0);
			playButton.SetActive(true);

		} 
		if (myScroller._currentPage == 1) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane2;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
			PlayerPrefs.SetInt ("Plane", 1);

			if (PlayerPrefs.GetInt ("PlaneOneBought") == 1) {

              
				playButton.SetActive (true);
//				int totalScore = PlayerPrefs.GetInt ("TotalScore");
//				totalScore -= 500;
//				PlayerPrefs.SetInt ("TotalScore", totalScore);

				GameObject.Find ("Plane2/buy").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Plane2/buy/Text").SetActive (false);
				GameObject.Find ("Plane2/buy/StarPoints").SetActive (false);
                if (Social.localUser.authenticated)
                    Social.ReportProgress(GameResource.achievement_thunder, 100.0f, (bool success) => { });
                else
                    GameCenter.Instance.LoginButton();
              


			} 
			else 
			{
				playButton.SetActive (false);
				GameObject.Find ("Plane2/buy").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Plane2/buy/Text").SetActive (true);
				GameObject.Find ("Plane2/buy/StarPoints").SetActive (true);
			}
		}
		if (myScroller._currentPage == 2) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane3;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
			PlayerPrefs.SetInt ("Plane", 2);

			if (PlayerPrefs.GetInt ("PlaneTwoBought") == 1) 
			{
          
				if (GameObject.Find ("Plane3/buy").activeInHierarchy == true)
				
				GameObject.Find ("Plane3/buy").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Plane3/buy/Text").SetActive (false);
				GameObject.Find ("Plane3/buy/StarPoints").SetActive (false);

                playButton.SetActive(true); if (Social.localUser.authenticated)
                    Social.ReportProgress(GameResource.achievement_rocketeer, 100.0f, (bool success) => { });
                else
                    GameCenter.Instance.LoginButton();
			} 
			else 
			{
				playButton.SetActive (false);
				GameObject.Find ("Plane3/buy").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Plane3/buy/Text").SetActive (true);
				GameObject.Find ("Plane3/buy/StarPoints").SetActive (true);			}
		}

		if (myScroller._currentPage == 3) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane4;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
			PlayerPrefs.SetInt ("Plane", 3);
			if (PlayerPrefs.GetInt ("PlaneFourBought") == 1) {
                
				playButton.SetActive (true);
				GameObject.Find ("Plane4/buy").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Plane4/buy/Text").SetActive (false);
				GameObject.Find ("Plane4/buy/StarPoints").SetActive (false);

                if (Social.localUser.authenticated)
                    Social.ReportProgress(GameResource.achievement_quick_shot, 100.0f, (bool success) => { });
                else
                    GameCenter.Instance.LoginButton();
                     
              
            } 
			else 
			{
				playButton.SetActive (false);
				GameObject.Find ("Plane4/buy").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Plane4/buy/Text").SetActive (true);
				GameObject.Find ("Plane4/buy/StarPoints").SetActive (true);
			}
		}
		if (myScroller._currentPage == 4) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane5;
            helliRotater.GetComponent<SpriteRenderer>().enabled = true;
            plane.GetComponent<TrailRenderer>().enabled = false;
			PlayerPrefs.SetInt ("Plane", 4);
			if (PlayerPrefs.GetInt ("PlaneFiveBought") == 1) {
           
				playButton.SetActive (true);
				GameObject.Find ("Plane5/buy").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Plane5/buy/Text").SetActive (false);
				GameObject.Find ("Plane5/buy/StarPoints").SetActive (false);
                if (Social.localUser.authenticated)
                    Social.ReportProgress(GameResource.achievement_aerial_acrobat, 100.0f, (bool success) => { });
                else
                    GameCenter.Instance.LoginButton();
			} 
			else 
			{
				playButton.SetActive (false);
				GameObject.Find ("Plane5/buy").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Plane5/buy/Text").SetActive (true);
				GameObject.Find ("Plane5/buy/StarPoints").SetActive (true);
			}
		}
        if (myScroller._currentPage == 5)
        {
            plane.GetComponent<SpriteRenderer>().sprite = plane6;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
            PlayerPrefs.SetInt("Plane", 5);
            if (PlayerPrefs.GetInt("PlaneSixBought") == 1)
            {
                playButton.SetActive(true);
                GameObject.Find("Plane6/buy").GetComponent<Image>().enabled = false;
                GameObject.Find("Plane6/buy/Text").SetActive(false);
                GameObject.Find("Plane6/buy/StarPoints").SetActive(false);
                if (Social.localUser.authenticated)
                    Social.ReportProgress(GameResource.achievement_ace, 100.0f, (bool success) => { });
                else
                    GameCenter.Instance.LoginButton();


            }
            else
            {
                playButton.SetActive(false);
                GameObject.Find("Plane6/buy").GetComponent<Image>().enabled = true;
                GameObject.Find("Plane6/buy/Text").SetActive(true);
                GameObject.Find("Plane6/buy/StarPoints").SetActive(true);
            }
        }
	}

	// Update is called once per frame
	void GameScreen() 
	{
		homeScreen.SetActive (false);
		gameScreen.SetActive (true);


//		for (int i = 0; i < PlaneSprites.Length; i++) 
//		{
			
//		}
		if (PlayerPrefs.GetInt ("Plane") == 0) {
			plane.GetComponent<SpriteRenderer> ().sprite = plane1;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
            myGameManager.planeone = true;
		}
		if (PlayerPrefs.GetInt ("Plane") == 1) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane2;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
            myGameManager.planetwo = true;	

		}
		if (PlayerPrefs.GetInt ("Plane") == 2) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane3;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
            myGameManager.planethree = true;
		}
		if (PlayerPrefs.GetInt ("Plane") == 3) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane4;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
			myGameManager.planefour = true;
		}
		if (PlayerPrefs.GetInt ("Plane") == 4) 
		{
			plane.GetComponent<SpriteRenderer> ().sprite = plane5;
            helliRotater.GetComponent<SpriteRenderer>().enabled = true;
            plane.GetComponent<TrailRenderer>().enabled = false;
			myGameManager.planefive = true;

		}
        if (PlayerPrefs.GetInt("Plane") == 5)
        {
            plane.GetComponent<SpriteRenderer>().sprite = plane6;
            helliRotater.GetComponent<SpriteRenderer>().enabled = false;
            plane.GetComponent<TrailRenderer>().enabled = true;
            myGameManager.planesix = true;
        }
	}

	public void planeOneBuy()
	{
		if (PlayerPrefs.GetInt ("TotalScore") >= 500) {
//			GameObject.Find ("Plane2/buy").SetActive (false);
		
			PlayerPrefs.SetInt ("PlaneOneBought", 1);
			int totalScore = PlayerPrefs.GetInt ("TotalScore");
			totalScore -= 500;
			PlayerPrefs.SetInt ("TotalScore", totalScore);
			myScoreManager.StoreTotalScore ();

		} else 
		{
			planedialogBox.SetActive (true);
		}
	}
	public void planeTwoBuy()
	{
		if (PlayerPrefs.GetInt ("TotalScore") >= 1000) 
		{
//			GameObject.Find ("Plane3/buy").GetComponent<Image> ().enabled = false;
			PlayerPrefs.SetInt ("PlaneTwoBought", 1);
			int totalScore = PlayerPrefs.GetInt ("TotalScore");
			totalScore -= 1000;
			PlayerPrefs.SetInt ("TotalScore", totalScore);
			myScoreManager.StoreTotalScore ();

		}else 
		{
			planedialogBox.SetActive (true);
		}
	}
	public void planeThreeBuy()
	{
		if (PlayerPrefs.GetInt ("TotalScore") >= 3000) 
		{
//			GameObject.Find ("Plane4/buy").GetComponent<Image> ().enabled = false;
			PlayerPrefs.SetInt ("PlaneFourBought", 1);
			int totalScore = PlayerPrefs.GetInt ("TotalScore");
			totalScore -= 3000;
			PlayerPrefs.SetInt ("TotalScore", totalScore);
			myScoreManager.StoreTotalScore ();

		}else 
		{
			planedialogBox.SetActive (true);
		}
	}
	public void planeFourBuy()
	{
		if (PlayerPrefs.GetInt ("TotalScore") >= 6000) 
		{
//			GameObject.Find ("Plane5/buy").GetComponent<Image> ().enabled = false;
			PlayerPrefs.SetInt ("PlaneFiveBought", 1);
			int totalScore = PlayerPrefs.GetInt ("TotalScore");
			totalScore -= 6000;
			PlayerPrefs.SetInt ("TotalScore", totalScore);
			myScoreManager.StoreTotalScore ();

		}else 
		{
			planedialogBox.SetActive (true);
		}
	}
    public void planeFiveBuy()
    {
        if (PlayerPrefs.GetInt("TotalScore") >= 10000)
        {
            //			GameObject.Find ("Plane5/buy").GetComponent<Image> ().enabled = false;
            PlayerPrefs.SetInt("PlaneSixBought", 1);
            int totalScore = PlayerPrefs.GetInt("TotalScore");
            totalScore -= 10000;
            PlayerPrefs.SetInt("TotalScore", totalScore);
            myScoreManager.StoreTotalScore();

        }
        else
        {
            planedialogBox.SetActive(true);
        }
    }

	public void onOk()
	{
		if(AdNotReadyDialog.activeInHierarchy == true)
			AdNotReadyDialog.SetActive (false);

		if(planedialogBox.activeInHierarchy == true)
			planedialogBox.SetActive (false);
	}
	public void TowatchVideo()
	{
		if(ShowAdsDialog.activeInHierarchy == false)
			ShowAdsDialog.SetActive (true);
	}
	public void AdWatchedOK ()
	{
		
		if (VideoWatchedDialog.activeInHierarchy == true)
		VideoWatchedDialog.SetActive (false);
       
	}
	public void quitShowDialog()
	{
		if (ShowAdsDialog.activeInHierarchy == true) 
			ShowAdsDialog.SetActive (false);
		
        if (VideoWatchedDialog.activeInHierarchy == true)
            VideoWatchedDialog.SetActive(false);

        if (NoAdsDialog.activeInHierarchy == true)
            NoAdsDialog.SetActive(false);

        if (AdNotReadyDialog.activeInHierarchy == true)
            AdNotReadyDialog.SetActive(false);

        if (BuyPlaneDialog.activeInHierarchy == true)
            BuyPlaneDialog.SetActive(false);

         if (QuitDialogBox.activeInHierarchy == true)
            QuitDialogBox.SetActive(false);
	}
    public void ShowNoAdsDialog()
    {
        if (NoAdsDialog.activeInHierarchy == false)
        {
            NoAdsDialog.SetActive(true);
        }
    }
  
}
