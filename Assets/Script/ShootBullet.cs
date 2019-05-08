using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
	public float speed = 10;
	bool shooter ;
	GameObject bullet;
//	Transform target;
	void Start()
	{

		bullet = Resources.Load ("FlaresBullet") as GameObject;
	
	}

	void Update ()
	{


//		// distance moved since last frame:
//		float amtToMove = speed * Time.deltaTime;
//		// translate projectile in its forward direction:
//		transform.Translate	(Vector3.forward * amtToMove);


		
		if (shooter == true)
		{
			
			if (GameObject.Find ("FlaresBullet(Clone)") == null)  
				{
//				Rigidbody2D instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody2D;
//				instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0));



//				rb.velocity = (GameObject.FindGameObjectWithTag("Enemy").transform.position - transform.position).normalized * speed;

//				GameObject projectile = Instantiate (bullet)as GameObject;
//				projectile.transform.position = new Vector3 (Random.Range(-3,3), transform.position.y, transform.position.z);
//				instantiatedProjectile.velocity = transform.TransformDirection (Vector2.up);
//				transform.rotation = Quaternion.Euler(0,0,0);

				GameObject projectile = Instantiate (bullet, transform.position, transform.rotation ) as GameObject;

//				Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();

//				rb.AddForce(transform.forward * speed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE

//				rb.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0)); 


//				GameObject projectile = Instantiate (bullet)as GameObject;
//				projectile.transform.position = new Vector3 (Random.Range(-3,3), transform.position.y, transform.position.z);
//				Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();
//				rb.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0)); 

//				rb.velocity = transform.TransformDirection (new Vector3 (transform.position.x, transform.position.y, transform.position.z));



			}
			}

	}
	public void onFireDown()
	{
		print ("shooter = true");
		shooter = true;
	}
	public void onFireUp()
	{
		print ("shooter = false");

		shooter = false;
	}


}
