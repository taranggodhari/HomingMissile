using UnityEngine;
using System.Collections;

public class MissilleTracker : MonoBehaviour 
{
	private Transform target;
//	private Transform targetTransform;
	private Vector3 v_diff;
	MissileSpawn missileSpawn;
	private float atan2;
	void Start()
	{
		//missileSpawn = (MissileSpawn)FindObjectOfType (typeof(MissileSpawn));
	}
	void Update()

	{
		
		//Checks if the enemy exists so you dont get any errors
		//		target = GameObject.Find ("Star(Clone)").transform;
		//		Vector3 v3Screen = Camera.main.WorldToViewportPoint(target.transform.position);
		if (GameObject.Find ("Missile(Clone)") != null) 
		{
//			target  =(GameObject)Resources.Load("Misslie(Clone)",typeof(GameObject));
			target = GameObject.Find ("Missile(Clone)").transform;
//			targetTransform = target.transform;
			Vector3 v3Screen = Camera.main.WorldToViewportPoint(target.transform.position);

			if (v3Screen.x > -0.01f && v3Screen.x < 1.01f && v3Screen.y > -0.01f && v3Screen.y < 1.01f)
			{
				GetComponent<SpriteRenderer> ().enabled = false;
			} 
			else
			{
				GetComponent<SpriteRenderer> ().enabled = true;
				//				target = GameObject.Find ("Star(Clone)").transform;

				//Rotate towards the enemy

				v_diff = (target.position - transform.position);

				atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);

				transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg - 90);
				//Move Towards the target

				transform.position = Vector3.MoveTowards (transform.position, target.transform.position, 1000);
				//Clamp to the screen view

				Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);

				pos.x = Mathf.Clamp01 (pos.x);

				pos.y = Mathf.Clamp01 (pos.y);

				transform.position = Camera.main.ViewportToWorldPoint (pos);
			}

		} 



	}
}
