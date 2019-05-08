using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	ScoreManager myScoreManager;

	void Start()
	{
		myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Stars") 
		{
			Destroy (this.gameObject, 0.02f);
			GameObject.Find ("CoinSound").GetComponent<ClickSound> ().Audioplay ();
			myScoreManager.AddStarScore (10);
		}
		}
}
