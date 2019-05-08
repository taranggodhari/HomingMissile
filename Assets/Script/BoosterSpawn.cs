using UnityEngine;
using System.Collections;

public class BoosterSpawn : MonoBehaviour {


	public GameObject plane;
	public int numObjects = 1;
	public int angle;
	public GameObject BoosterPrefab;
	public bool destroy = false;
	bool isSpawning = false;
//	Timer myTimer;
	public float minTime, maxTime;
	void Start()
	{
//		myTimer = (Timer)GameObject.FindObjectOfType (typeof(Timer));
//		InvokeRepeating ("SpawnBooster", 5, 3);
	}

	void Update()
	{
		if (!isSpawning && GameObject.Find ("SpeedBoost(Clone)") == null) 
		{
			isSpawning = true;
			StartCoroutine (DelayTimer (Random.Range(minTime,maxTime)));
		}
	}

	public void SpawnBooster()
	{
		for (int i = 0; i < numObjects; i++)
		{
			Vector3 center = plane.transform.position;
			int a = i * angle;
            Vector3 pos = RandomCircle(center, Random.Range(-10f, -15f), Random.Range(-45, 45));
			Instantiate(BoosterPrefab, pos, Quaternion.identity);
		}
	}


	Vector3 RandomCircle(Vector3 center, float radius,int a)
	{
		float ang = a;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}
	IEnumerator DelayTimer(float seconds)
	{

			yield return new WaitForSeconds (seconds);
				SpawnBooster();
			isSpawning = false;
	}
}

