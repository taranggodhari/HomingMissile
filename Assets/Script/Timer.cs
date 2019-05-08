using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timerText;
	private float startTime;
	public int timeSpent;
	public GameObject gameScreen;
	public GameObject homeScreen;
	public GameObject gameoverScreen;
	// Use this for initialization
	void Start () {
		if(homeScreen.activeInHierarchy == false && gameoverScreen.activeInHierarchy == false)
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (homeScreen.activeInHierarchy == false && gameoverScreen.activeInHierarchy == false) {
			float t = Time.time - startTime;
			timeSpent = (int)t;
			string minutes = ((int)t / 60).ToString ("");
			string seconds = (t % 60).ToString ("00");

			timerText.text = minutes + ":" + seconds;
		}
		}
}
//gameScreen.activeInHierarchy == true && 