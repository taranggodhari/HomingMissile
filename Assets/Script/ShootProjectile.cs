using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {

	GameObject prefab;
	bool shoot;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("Flares") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (shoot == true)
		{

			GameObject projectile = Instantiate (prefab)as GameObject;
			projectile.transform.position = new Vector3 (Random.Range(-3,3), transform.position.y, transform.position.z);
			Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();
			rb.velocity = transform.TransformDirection (new Vector3 (transform.position.x, transform.position.y, transform.position.z));

		}
	
	}
	public void ShootButtonDown()
	{
		shoot = true;
	}
	public void ShootButtonUp()
	{
		shoot = false;
	}
}
