using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class BGSound : MonoBehaviour 
{
	public static BGSound i;
	public AudioClip homeSound , planeSound, chopperSound;
	bool once;
	void Awake () 
	{
//		homeScreen = GameObject.Find("Home");
//		gameScreen = GameObject.Find("Game");
		if(PlayerPrefs.GetInt("Restart") == 1)
			once = true;



		if(!i) 
		{
			i = this;
			GameObject.Find("BGSound").GetComponent<AudioSource>().Play();
			DontDestroyOnLoad(gameObject);
		}
		else 
			Destroy(transform.gameObject);
	}
	
	void Update () 
	{
		if(PlayerPrefs.GetString("Sound") == "On")
			gameObject.GetComponent<AudioSource>().mute = false;
		else 
			gameObject.GetComponent<AudioSource>().mute = true;

		if(GameObject.Find("Game") && GameObject.Find("Home") && !once && PlayerPrefs.GetInt("Restart") == 0)
		{
			once = !once;
			GetComponent<AudioSource>().clip = homeSound;
            GetComponent<AudioSource>().volume = 1;
			GetComponent<AudioSource>().Play();
		}
		else if(!GameObject.Find("Home") && !GameObject.Find("GameOver") && !GameObject.Find("Paused") && GameObject.Find("Game") && once)
		{
            if (PlayerPrefs.GetInt("Plane") == 4)
            {
                once = !once;
                GetComponent<AudioSource>().clip = chopperSound;
                GetComponent<AudioSource>().volume = 1;

                //			GetComponent<AudioSource>().clip = planeSound;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                once = !once;
                GetComponent<AudioSource>().clip = planeSound;
                GetComponent<AudioSource>().volume = 0.8f;

                //			GetComponent<AudioSource>().clip = planeSound;
                GetComponent<AudioSource>().Play();
            }
		}

			
	}
}
