using UnityEngine;
using System.Collections;

public class ShieldSpawn : MonoBehaviour {


	public GameObject homeScreen;
	public GameObject plane;
	public int numObjects = 3;
	public int angle;
	public GameObject ShieldPrefab;
	public bool destroy = false;
	bool isSpawning;
	public float minTime, maxTime;

	void Start()
	{
		//		if (homeScreen.activeInHierarchy == false) 

	}

	void Update()
	{
		if (!isSpawning && GameObject.Find ("Shield(Clone)") == null) 
		{
			isSpawning = true;
			StartCoroutine (DelayTimer (Random.Range(minTime,maxTime)));
		}
	}

	public void SpawnShield()
	{
		for (int i = 0; i < numObjects; i++)
		{
			Vector3 center = plane.transform.position;
			int a = i * angle;
			Vector3 pos = RandomCircle(center, Random.Range(-30f,-15f) ,Random.Range(-45,45));
			Instantiate(ShieldPrefab, pos, Quaternion.identity);
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
		SpawnShield();
		isSpawning = false;
	}
}

