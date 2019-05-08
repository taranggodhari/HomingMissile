using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour 
{
	

	void Awake()
	{
		if(PlayerPrefs.GetString("Sound") == "")
			PlayerPrefs.SetString("Sound","On");
	}


	void Update () 
	{
		if(PlayerPrefs.GetString("Sound") == "On")
			gameObject.GetComponent<AudioSource>().mute = false;
		else 
			gameObject.GetComponent<AudioSource>().mute = true;
	}
	
	public void Audioplay()
	{
		gameObject.GetComponent<AudioSource>().Play();
	}

}
