using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {


	public GameObject homeScreen;
	public GameObject plane;
	public int numObjects = 3;
	public GameObject StarPrefab;
	public bool destroy = false;

	void Start()
	{
//		if (homeScreen.activeInHierarchy == false) 
			{
			SpawnStar ();
		}
	}

	void Update()
	{
//		Vector3 center = plane.transform.position;
		if (GameObject.Find ("Star(Clone)") == null)
			SpawnStar ();
		
	}	

	public void SpawnStar()
	{
		for (int i = 0; i < numObjects; i++)
		{
			Vector3 center = plane.transform.position;
		
            //Vector3 pos = RandomCircle(center, Random.Range(-8f,-15f) ,Random.Range(18,30));
            Vector3 pos = RandomCircle(center, Random.Range(- 8f, -15f), Random.Range(-70, 70));
			Instantiate(StarPrefab, pos, Quaternion.identity);
		}
	}


	Vector3 RandomCircle(Vector3 center, float radius,int a)
	{
		float ang = a;
        print(ang);
        Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}
	IEnumerator StarSpawner()
	{
		yield return new WaitForSeconds (10);	
		SpawnStar ();
	}
}