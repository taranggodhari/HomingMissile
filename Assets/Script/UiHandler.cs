using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour {

    public static UiHandler Instance { get; set; }
    public GameObject camera;
public GameObject Plane,heliRotater, homeScreen, gameUIScreen,gameScreen, gameoverScreen, PausedMenu, controlsBar, Spawners, dialogBox,BannerAds,fireButtonTrigger;

//	missileSpawn, starSpawn, shieldSpawn, BoosterSpawn;
private bool pausebool;
ScoreManager  myScoreManager ;

public bool gameover, ScoreSetter, once, showadsonce;
void Awake()
{
    Instance = this;
}
void Start()
{
    
    
    showadsonce = false;
    //PlayerPrefs.DeleteKey("Adsfree");
	PlayerPrefs.SetInt ("Restart", 0);
	myScoreManager  = (ScoreManager )GameObject.FindObjectOfType (typeof(ScoreManager ));
  
}

public void playButton()
{
	StartCoroutine (delayForAnimation ());
}

IEnumerator delayForAnimation()
{
//		BannerAds.GetComponent<BannerShow> ().bannerView.Hide ();

	yield return new WaitForSeconds (0.7f);
	if (Time.timeScale == 0)
		Time.timeScale = 1;
	PlayerPrefs.SetInt("Restart", 1);
    SceneManager.LoadScene("Plane_Landscape");
}
public void pausedPlayButton()
{
//		BannerAds.GetComponent<BannerShow> ().bannerView.Hide ();

	if (Time.timeScale == 0)
		Time.timeScale = 1;
	PlayerPrefs.SetInt("Restart", 1);
    SceneManager.LoadScene("Plane_Landscape");

}

public void playAgain ()
{
    showadsonce = false;
//		BannerAds.GetComponent<BannerShow> ().bannerView.Hide ();
	if (Time.timeScale == 0)
		Time.timeScale = 1;
	gameover = false;
	gameoverScreen.SetActive (false);
	gameUIScreen.SetActive (true);
	PlayerPrefs.SetInt("Restart", 1);
    SceneManager.LoadScene("Plane_Landscape");

}
public void homeButton()
{
    showadsonce = false;
	print ("clicked");
	if (Time.timeScale == 0)
		Time.timeScale = 1;
	PlayerPrefs.SetInt ("Restart", 0);
    SceneManager.LoadScene("Plane_Landscape");
}
public void onBack()
{
	if (pausebool)
	{

		if (Time.timeScale == 0)
			Time.timeScale = 1;
		PausedMenu.SetActive (false);
		pausebool = false;
		controlsBar.SetActive (true);
	}
}



public void onPause()
{
	if(!pausebool)
	{		
//			BannerAds.GetComponent<BannerShow> ().bannerView.Show ();

		controlsBar.SetActive (false);
		if (Time.timeScale == 1)
			Time.timeScale = 0f;
		PausedMenu.SetActive(true);
		pausebool=true;
	}
}
public void ShowQuitBanner ()
{
	dialogBox.SetActive (true);
}
public void YesButtom()
{
	Application.Quit ();
}
public void NoButton()
{
	dialogBox.SetActive (false);
}

void Update()
{
	if (Input.GetKey (KeyCode.Escape) )
		ShowQuitBanner ();

    
    //if ((homeScreen.activeInHierarchy == false && gameoverScreen.activeInHierarchy == false && PausedMenu.activeInHierarchy == false))
    //{
    //    if (!PlayerPrefs.HasKey("Adsfree"))
    //    {
    //        GameObject.Find("Banner").GetComponent<BannerShow>().bannerView.Hide();
    //        once = true;
    //    }
    //}
    //else
    //{
    //    if (!PlayerPrefs.HasKey("Adsfree"))
    //        GameObject.Find("Banner").GetComponent<BannerShow>().bannerView.Show();
    //}
    

    //if (homeScreen.activeInHierarchy == false)
    //{
    //    GameObject.Find("Plane").GetComponent<SpriteRenderer>().enabled = true;
    //    GameObject.Find("Plane").GetComponent<TrailRenderer>().enabled = true;
    //}
    //else
    //{
    //    GameObject.Find("Plane").GetComponent<SpriteRenderer>().enabled = false;
    //    GameObject.Find("Plane").GetComponent<TrailRenderer>().enabled = false;

    //}

	


	// Show Spawner, Controls And GameUI in Game Only
	if (homeScreen.activeInHierarchy == false && PausedMenu.activeInHierarchy == false) {
		Spawners.SetActive (true);
		controlsBar.SetActive (true);
		gameUIScreen.SetActive (true);

	}

   

	//On Escape Pressed While Playing Game
	if (homeScreen.activeInHierarchy == false && gameoverScreen.activeInHierarchy == false) 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (!pausebool) {	

				controlsBar.SetActive (false);
				if (Time.timeScale == 1)
					Time.timeScale = 0f;
				PausedMenu.SetActive (true);
				pausebool = true;
			} else {

				if (Time.timeScale == 0)
					Time.timeScale = 1;
				PausedMenu.SetActive (false);
				pausebool = false;
				controlsBar.SetActive (true);
			}
			
		}
        
	}

	//GAMEOVER
	if (gameover == true) {

        gameoverScreen.SetActive(true);
//		BannerAds.GetComponent<BannerShow> ().bannerView.Show ();
            

//			if (Time.timeScale == 1.0f)
//				Time.timeScale = 0;
		if (ScoreSetter == false)
		{
				
			myScoreManager.scoreSet = false;
			ScoreSetter = true;
		}
		Plane.GetComponent<SpriteRenderer> ().enabled = false;
		Plane.GetComponent<TrailRenderer> ().enabled = false;
        fireButtonTrigger.GetComponent<Animator>().Play("FireDeactive");
        //if (heliRotater.GetComponent<SpriteRenderer>().enabled == true)
        //    heliRotater.GetComponent<SpriteRenderer>().enabled = false;
		controlsBar.SetActive (false);
		gameUIScreen.SetActive (false);
		
	
        //AdColonyInterstial.Instance.PlayAVideo("vza6041e4edda043f68c");
        //ChartboostExample.Instance.ShowInterstial();
    if (!PlayerPrefs.HasKey("Adsfree"))
    {
        if(showadsonce == false)
        {
            print("Interstials once");
        //AdColonyInterstial.Instance.PlayAVideo("vza6041e4edda043f68c");
        AdColonyVCV4.Instance.ShowInterstials();
            
        //GameObject.Find("FullAds").GetComponent<FullAds>().ShowAds();
        showadsonce = true;
         }
    }
   } 
    }

}

