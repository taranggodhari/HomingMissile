using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class homingMissile : MonoBehaviour {
	private GameObject Tracker;
	private Vector3 v_diff;
	private float atan2;
	public float speed = 3;
	public float rotatingSpeed = 20;
	GameObject target;
	public float explosionTimer = 1.0f;

	public GameObject explosion;
	public GameObject selfexplosion;

	public GameObject protection;
    public GameObject heliRotater;
	PlaneController myPlaneController;
	ScoreManager  myScoreManager ;
	public bool destroyer;
	UiHandler myUIHandler;

	Rigidbody2D myRigidbody;
	void Start () {
		myUIHandler = (UiHandler)GameObject.FindObjectOfType (typeof(UiHandler));
		Tracker = GameObject.Find ("MissileTracker");
		target = GameObject.FindGameObjectWithTag ("Player");
		protection = GameObject.Find ("Protector");
        heliRotater = GameObject.Find("heliRotater");
		myRigidbody = GetComponent<Rigidbody2D>();
		myPlaneController = (PlaneController)GameObject.FindObjectOfType(typeof(PlaneController));
		myScoreManager  = (ScoreManager )GameObject.FindObjectOfType(typeof(ScoreManager ));

	}

	void Update()
	{
		StartCoroutine (SelfDestruct ());

		Vector3 v3Screen = Camera.main.WorldToViewportPoint(transform.position);
		if (v3Screen.x > -0.01f && v3Screen.x < 1.01f && v3Screen.y > -0.01f && v3Screen.y < 1.01f)
		{
			
			Tracker.GetComponent<SpriteRenderer> ().enabled = false;
		}
		else
		{

			Tracker.GetComponent<SpriteRenderer> ().enabled = true;
			//Rotate towards the enemy

			v_diff = (transform.position - Tracker.transform.position);

			atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);

			Tracker.transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg - 90);
			//Move Towards the target

			Tracker.transform.position = Vector3.MoveTowards (Tracker.transform.position, transform.position, 1000);
			//Clamp to the screen view

			Vector3 pos = Camera.main.WorldToViewportPoint (Tracker.transform.position);

			pos.x = Mathf.Clamp01 (pos.x);

			pos.y = Mathf.Clamp01 (pos.y);

			Tracker.transform.position = Camera.main.ViewportToWorldPoint (pos);

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameObject.Find ("Plane") != null) {
			Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;
			pointToTarget.Normalize ();

			float value = Vector3.Cross (pointToTarget, transform.right).z;

//		if (value > 0)
//			myRigidbody.angularVelocity = rotatingSpeed;
//		else if (value < 0)
//			myRigidbody.angularVelocity = -rotatingSpeed;
//		else
//			rotatingSpeed = 0;
			myRigidbody.angularVelocity = rotatingSpeed * value;

			myRigidbody.velocity = transform.right * speed;
		}
	}
	void  OnTriggerEnter2D(Collider2D other)
	{
		

		
		if (other.tag == "Enemy" && myUIHandler.gameover == false) 
		{
			GameObject.Find ("DestroySound").GetComponent<ClickSound> ().Audioplay ();
			Destroy (this.gameObject);
			GameObject myExplosion = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
			Destroy (myExplosion, 1f);
			myScoreManager.AddMissileScore (10);
		}
		else if ((other.name == "Plane" && other.name != "Protector") || (other.name == "Plane" && other.tag == "Enemy"))
        {
			GameObject.Find ("DestroySound").GetComponent<ClickSound> ().Audioplay ();
			GameObject Exploded = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
			Destroy (Exploded, 1f);
            myPlaneController.speed = 0;
            other.GetComponent<SpriteRenderer> ().enabled = false;
			other.GetComponent<TrailRenderer> ().enabled = false;
			other.GetComponent<BoxCollider2D> ().enabled = false;
            if (heliRotater.GetComponent<SpriteRenderer>().enabled == true)
                heliRotater.GetComponent<SpriteRenderer>().enabled = false; 
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.GetComponent<SpriteRenderer> ().enabled = false;
			this.GetComponent<TrailRenderer> ().enabled = false;
            
			Handheld.Vibrate ();
            flaregun.Instance.currentRound = 0;
			StartCoroutine (ExplodWaiter ());

		} 
		else if (other.name == "Protector") 
		{	
			GameObject.Find ("DestroySound").GetComponent<ClickSound> ().Audioplay ();
			Destroy (this.gameObject);
			other.GetComponent<SpriteRenderer> ().enabled = false;
//			other.GetComponent<Rigidbody2D> ().enabled = false;
			other.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject Exploded = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
			Destroy (Exploded, 1f);


		}
		else if (other.tag == "Bullet") 
		{
				GameObject.Find ("DestroySound").GetComponent<ClickSound> ().Audioplay ();
				Destroy (this.gameObject);
				Destroy (other.gameObject);	
				GameObject myExplosion = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
				Destroy (myExplosion, 1f);
				myScoreManager.AddMissileScore (10);
		}
		else 
		{
			print ("Unknown Collider Detected");
		}
	


	}
	void OnTriggerExit2D(Collider2D other)
	{
		destroyer = false;
	}

	IEnumerator ExplodWaiter ()
	{
		
		yield return new WaitForSeconds (1);
		myUIHandler.gameover = true;
	
	}
	IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds (15);
		Destroy (gameObject,1f);
		GameObject Exploded = Instantiate (selfexplosion, transform.position, transform.rotation) as GameObject;
		Destroy (Exploded, 1f);
	}





}