	using UnityEngine;
	using System.Collections;
	

	public class PlaneController : MonoBehaviour

	{
	
		public float speed ,rotationSpeed;
		public VirtualJoystick myJoystick;
		public GameObject JoystickController;
		public GameObject LeftRightController;
		public GameObject FireButtonTrigger;

		//transform
		Transform myTrans;
		//object position and rotation
		Vector3 myPos, myRot;
		float angle;	
		bool isMove;
		public bool turnLeft;
		public bool turnRight;
	 	public GameObject Protector;
		private float atan2;
		public float trackingSpeed;
		private float rotater = 90;
		ScoreManager myScoreManager;
		flaregun myFlareGun;
        

	public GameObject StarParticle;

		

	void Start ()
			{
			myFlareGun = (flaregun)GameObject.FindObjectOfType (typeof(flaregun));
			myScoreManager = (ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager));
			myTrans = transform;
			myPos = myTrans.position;
			myRot = myTrans.rotation.eulerAngles ;
			StarParticle.GetComponent<ParticleSystem> ().enableEmission = false;

//		myTrans.rotation = Quaternion.Euler (0, 0, -90);

	}



	void FixedUpdate ()
	{		
		

//			myTrans.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
//			converting the object euler angle's magnitude from Degree to Radians    
			angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;

		if (LeftRightController.activeInHierarchy == true) {
//			rotate object Right & Left (KeybordInput and Ui Button Input)
			if (Input.GetKey (KeyCode.D) || turnLeft == true)
				myRot.z -= rotationSpeed;
		
			if (Input.GetKey (KeyCode.A) || turnRight == true)
				myRot.z += rotationSpeed;
		}
//		float temp = Input.acceleration.z;
////		print (temp);
//		transform.Translate(0,0,temp);
	
			//			myRot.z -= rotationSpeed;





		myPos.x += (Mathf.Cos (angle) * speed ) * Time.deltaTime;
		myPos.y += (Mathf.Sin (angle) * speed ) * Time.deltaTime;

//		Apply
		myTrans.position = myPos ;

		if(LeftRightController.activeInHierarchy == true)
			myTrans.rotation = Quaternion.Euler (myRot);

	



		if (JoystickController.activeInHierarchy == true) 
		{
			atan2 = (Mathf.Atan2 (myJoystick.InputDirection.y , myJoystick.InputDirection.x) * Mathf.Rad2Deg);
//		Mathf.Lerp (myJoystick.InputDirection.x, myJoystick.InputDirection.y, Time.time);
			myTrans.rotation = Quaternion.Slerp (myTrans.rotation, Quaternion.Euler (0, 0, (atan2 - rotater ))	, (rotationSpeed) *Time.deltaTime); 
		
//		Movement with virtual joystick
			if (myJoystick.InputDirection != Vector3.zero) 
			{
				rotater = 0; 
				myRot.z = (atan2) * rotationSpeed;
			}

		}
		}

	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shield") 
		{
			GameObject.Find ("ShieldSound").GetComponent<ClickSound> ().Audioplay ();

			StartCoroutine (DelayProtection());
			Destroy (other.gameObject, 0.02f);
		}

		if (other.tag == "Booster") 
		{
			GameObject.Find ("SpeedUpSound").GetComponent<ClickSound> ().Audioplay ();
			Destroy (other.gameObject, 0.02f);
			StartCoroutine (SpeedBoostTime ());

		}
		if (other.tag == "Stars") 
		{
			Destroy (other.gameObject, 0.02f);
			GameObject.Find ("CoinSound").GetComponent<ClickSound> ().Audioplay ();
			myScoreManager.AddStarScore (10);
			StartCoroutine (SparklesDelay());
		}
		if (other.tag == "Flares") 
		{
			Destroy (other.gameObject, 0.02f);
			myFlareGun.currentRound = 40;
            //FireButtonTrigger.SetActive (true);
            //FireButtonTrigger.GetComponent<Animator> ().Play ("FireActive");
			GameObject.Find ("FlareSound").GetComponent<ClickSound> ().Audioplay ();


		}
	}


	//	UiLeftButton
	public void leftButtonDown()
	{
		turnLeft = true;
	}
	public void leftButtonUp()
	{
		turnLeft = false;
	}

	//	UiRightButton
	public void rightButtonDown()
	{
		turnRight = true;
	}
	public void rightButtonUp()
	{
		turnRight = false;
	}

	IEnumerator SpeedBoostTime()
	{
		speed *= 2f;
		yield return new WaitForSeconds (10);
		speed /= 2f;
	}
	IEnumerator DelayProtection()
	{

		Protector.GetComponent<SpriteRenderer> ().enabled = true;
		Protector.GetComponent<CircleCollider2D> ().enabled = true;
				yield return new WaitForSeconds (15);
		Protector.GetComponent<SpriteRenderer> ().enabled = false;
		Protector.GetComponent<CircleCollider2D> ().enabled = false;
	}
	IEnumerator SparklesDelay()
	{
		StarParticle.GetComponent<ParticleSystem> ().enableEmission = true;
		yield return new WaitForSeconds (0.2f);
		StarParticle.GetComponent<ParticleSystem> ().enableEmission = false;
        yield return null;
	}

}