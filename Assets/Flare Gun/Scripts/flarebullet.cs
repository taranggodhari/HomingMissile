using UnityEngine;
using System.Collections;

public class flarebullet : MonoBehaviour {
			

	private Light flarelight;
	private AudioSource flaresound;
	private ParticleRenderer smokepParSystem;
	private bool myCoroutine;
	private float smooth = 2.4f;
	public 	float flareTimer = 9;
	public AudioClip flareBurningSound;

	// Use this for initialization
	void Start () {
		StartCoroutine("flareLightoff");
		if(PlayerPrefs.GetString("Sound") == "On")
		GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
		
		flarelight = GetComponent<Light>();
		flaresound = GetComponent<AudioSource>();
		smokepParSystem = GetComponent<ParticleRenderer>();

		Destroy(gameObject,flareTimer + 1f);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
//		transform.position = new Vector3 (transform.position.x, transform.position.y);
		rb.AddForce (transform.up * 5f * Time.deltaTime, ForceMode2D.Impulse); 
		if (myCoroutine == true)
			
		{
			flarelight.intensity = Random.Range(0.5f,1.0f);
			
		}else
			
		{
			flarelight.intensity =  Mathf.Lerp(flarelight.intensity,0f,Time.deltaTime * smooth);
			flarelight.range =  Mathf.Lerp(flarelight.range,0f,Time.deltaTime * smooth);			
			flaresound.volume = Mathf.Lerp(flaresound.volume,0f,Time.deltaTime * smooth);
			smokepParSystem.maxParticleSize = Mathf.Lerp(smokepParSystem.maxParticleSize,0f,Time.deltaTime * 5);       //switched to legacy


		}

			
	}
	
	IEnumerator flareLightoff()
	{
		myCoroutine = true;
		yield return new WaitForSeconds(flareTimer);
		myCoroutine = false;

	}
}
