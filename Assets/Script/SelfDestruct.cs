using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
		StartCoroutine (SelfDestructor ());
	}

	IEnumerator SelfDestructor()
	{
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
	}
}
