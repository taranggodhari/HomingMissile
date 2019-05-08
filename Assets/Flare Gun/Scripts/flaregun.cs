using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class flaregun : MonoBehaviour {
	public Rigidbody2D[] flares;
    public GameObject FireButtonTrigger,FlareText;
    public Text FlaresRoundText;

	public Transform barrelEnd;
    public GameObject muzzleParticles;
	public AudioClip flareShotSound;
	public AudioClip noAmmoSound;	
	public AudioClip reloadSound;	
	public int bulletSpeed = 2000;
	public int maxSpareRounds = 5;
	public int spareRounds = 3;
	public int currentRound = 0;
	bool firebutton = false;


    public static flaregun Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (currentRound > 0)
        {
            if (FlareText.activeInHierarchy == false)
                FlareText.SetActive(true);
            FlaresRoundText.text = "" + flaregun.Instance.currentRound;
            FireButtonTrigger.GetComponent<Animator>().Play("FireActive");
        }
        else
        {
            if (FlareText.activeInHierarchy == true)
                FlareText.SetActive(false);
            FireButtonTrigger.GetComponent<Animator>().Play("FireDeactive");
        }



		if(firebutton == true)
		{
			if (currentRound > 0) {
                Shoot ();
			}
            
		}
	
	}
	
	void Shoot()
	{
			currentRound--;
		if(currentRound <= 0){
			currentRound = 0;
		}

			for (int i = 0; i < 1; i++) {

//			GetComponent<Animation>().CrossFade("Shoot");
			if(PlayerPrefs.GetString("Sound") == "On")
				GetComponent<AudioSource> ().PlayOneShot (flareShotSound);
			
				Rigidbody2D	bulletInstance = Instantiate (flares [Random.Range (0, flares.Length)], barrelEnd.position, barrelEnd.rotation) as Rigidbody2D; //INSTANTIATING THE FLARE PROJECTILE
				Instantiate (muzzleParticles, barrelEnd.position, barrelEnd.rotation);	//INSTANTIATING THE GUN'S MUZZLE SPARKS	

		}
	}
	

	public void FireDown()
	{
		firebutton = true;
	}
	public void FireUp()
	{
		firebutton = false;
	}
}
