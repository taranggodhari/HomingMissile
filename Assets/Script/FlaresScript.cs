using UnityEngine;
using System.Collections;

public class FlaresScript : MonoBehaviour {
	public float speed = 5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
print (transform.rotation);
				Rigidbody2D rb = GetComponent<Rigidbody2D> ();
				rb.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0)); 
	}
}
