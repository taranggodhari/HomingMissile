using UnityEngine;
using System.Collections;

public class LookingAtPlayer : MonoBehaviour 
{
	
	Transform Source;
	Transform Destination;
	public float speed ;
	private float startTime;
	private float journeyLength;
	bool SourceFound , DestinationFound;
	void Start() 
	{
		Source = gameObject.transform;
		
		if(GameObject.FindWithTag("Player"))
		{
			Destination = GameObject.FindWithTag("Player").transform;
			DestinationFound = true;
			transform.LookAt(Destination);
		}
		
		startTime = Time.time;
		if(DestinationFound)
			journeyLength = Vector3.Distance(Source.position, Destination.position);
	}
	void Update() 
	{
		if(Destination && transform.position.x > GameObject.FindWithTag("Player").transform.position.x)
		{
			SmoothRotate();
			SmoothLerp();
		}
		print (transform.rotation.x);
	}
	
	void SmoothLerp()
	{
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if(Destination && Source)
			transform.position = Vector3.Lerp(Source.position, Destination.position, fracJourney);
	}
	
	void SmoothRotate() 
	{
		
		Vector3 relativePos = Destination.position ;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z);
	}
}
