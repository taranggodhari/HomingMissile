using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject homeScreen, gameScreen , joystick, LRButton, JoystickControllerButton, LeftRightButton;
	public GameObject plane;
	public Sprite plane1;
	public Sprite plane2;
	public Sprite plane3;
	public Sprite plane4;
	public Sprite plane5;
    public Sprite plane6;

	public GameObject RedMissileSpawner;
	public GameObject MissileSpawner;
	ScrollSnapRect myScroller;
	 MissileSpawn myMissileSpawn;
	MissileSpawn myRedMissileSpawn;
	PlaneController myPlaneController;
	public bool planeone,planetwo,planethree,planefour,planefive,planesix;
	public GameObject SoundOn;
	public GameObject SoundOff;

	void Start()
	{
		myPlaneController = (PlaneController)GameObject.FindObjectOfType (typeof(PlaneController));

		myScroller = (ScrollSnapRect)GameObject.FindObjectOfType (typeof(ScrollSnapRect));
		if (homeScreen.activeInHierarchy == false) {
			myRedMissileSpawn = RedMissileSpawner.GetComponent<MissileSpawn> ();
			myMissileSpawn = MissileSpawner.GetComponent<MissileSpawn> ();

		}
			//Sound
		if (PlayerPrefs.GetString ("Sound") == "")
			PlayerPrefs.SetString ("Sound", "On");
		
		if (PlayerPrefs.GetString ("Sound") == "On")
			SoundOnButton ();
		else
			SoundOffButton ();

		//Controller
		if (PlayerPrefs.GetString ("Controller") == "")
            PlayerPrefs.SetString("Controller", "LRButton");
		
		if(PlayerPrefs.GetString("Controller") == "Joystick")
			JoystickController();
		else
			LRButtonController();
	}	
		

	void Update()
	{
		

			if (homeScreen.activeInHierarchy == false) 
		{

			if (planeone == true) 
			{
				myPlaneController.speed = 2.5f;
				myPlaneController.rotationSpeed = 4;

				myMissileSpawn.startWait = 4;
				myMissileSpawn.spawnWait = 8;
		
				myRedMissileSpawn.startWait = 20;
				myRedMissileSpawn.spawnWait = 20;
				planeone = false;
			}
			if (planetwo == true) 
			{	
				myPlaneController.speed = 2.5f;
				myPlaneController.rotationSpeed = 4;

				myMissileSpawn.startWait = 4;
				myMissileSpawn.spawnWait = 8;

				myRedMissileSpawn.startWait = 20;
				myRedMissileSpawn.spawnWait = 20;
				planetwo = false;
			}
			if (planethree == true) 
			{
				myPlaneController.speed = 3.5f;
				myPlaneController.rotationSpeed = 5;

				myMissileSpawn.startWait = 2;
				myMissileSpawn.spawnWait = 2;

				myRedMissileSpawn.startWait = 11;
				myRedMissileSpawn.spawnWait = 11;
				planethree = false;
			}
			if (planefour == true) 
			{
				myPlaneController.speed = 4f;
				myPlaneController.rotationSpeed = 5.5f;

				myMissileSpawn.startWait = 2;
				myMissileSpawn.spawnWait = 2;

				myRedMissileSpawn.startWait = 7;
				myRedMissileSpawn.spawnWait = 7;
				planefour = false;
			}
            if (planefive == true)
            {
                myPlaneController.speed = 3.5f;
                myPlaneController.rotationSpeed = 9;

                myMissileSpawn.startWait = 2;
                myMissileSpawn.spawnWait = 2;

                myRedMissileSpawn.startWait = 7;
                myRedMissileSpawn.spawnWait = 7;
                planefive = false;
            }
            if (planesix == true)
            {
                myPlaneController.speed = 4.5f;
                myPlaneController.rotationSpeed = 6;

                myMissileSpawn.startWait = 2;
                myMissileSpawn.spawnWait = 2;

                myRedMissileSpawn.startWait = 4;
                myRedMissileSpawn.spawnWait = 4;
                planesix = false;
            }
		}
		//		if (myScroller._currentPage == 0) {
//			plane.GetComponent<SpriteRenderer> ().sprite = plane1;
//			PlayerPrefs.SetInt ("Plane", 1);
//		} 
//		if (myScroller._currentPage == 1) 
//		{
//			plane.GetComponent<SpriteRenderer> ().sprite = plane2;
//			PlayerPrefs.SetInt ("Plane", 2);
//		}
//		if (myScroller._currentPage == 2) 
//		{
//			plane.GetComponent<SpriteRenderer> ().sprite = plane3;
//			PlayerPrefs.SetInt ("Plane", 3);
//		}
//
//		if (myScroller._currentPage == 3) 
//		{
//			plane.GetComponent<SpriteRenderer> ().sprite = plane4;
//			PlayerPrefs.SetInt ("Plane", 4);
//		}
//		if (myScroller._currentPage == 4) 
//		{
//			plane.GetComponent<SpriteRenderer> ().sprite = plane5;
//			PlayerPrefs.SetInt ("Plane", 5);
//		}

	}
	public void SoundOnButton()
	{
		PlayerPrefs.SetString ("Sound", "On");
		SoundOn.SetActive (false);
		SoundOff.SetActive (true);
		print ("on");

	}

	public void SoundOffButton()
	{
		PlayerPrefs.SetString ("Sound", "Off");
		SoundOff.SetActive (false);
		SoundOn.SetActive (true);
		print ("off");

	}
	public void JoystickController()
	{
		PlayerPrefs.SetString ("Controller", "Joystick");
		JoystickControllerButton.SetActive (false);
		LeftRightButton.SetActive (true);
		joystick.SetActive (false);
		LRButton.SetActive(true);
	}
	
	public void LRButtonController()
	{
		PlayerPrefs.SetString ("Controller", "LRButton");

		JoystickControllerButton.SetActive (true);
		LeftRightButton.SetActive (false);
		joystick.SetActive (true);
		LRButton.SetActive(false);
	}

}
