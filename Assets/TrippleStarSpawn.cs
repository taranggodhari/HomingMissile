using UnityEngine;
using System.Collections;

public class TrippleStarSpawn : MonoBehaviour {

		public GameObject homeScreen;
		public GameObject plane;
		public int numObjects = 1;
		public int angle;
		public GameObject StarPrefab;
		public bool destroy = false;

		void Start()
		{
			//		if (homeScreen.activeInHierarchy == false) 
			{
//				SpawnStar ();
			}
		}

		void Update()
		{
			//		Vector3 center = plane.transform.position;
			
		if (GameObject.Find ("TrippleStar(Clone)") == null )
			SpawnStar ();
		PlayerPrefs.DeleteAll ();

		}	

		public void SpawnStar()
		{
			for (int i = 0; i < numObjects; i++)
			{
				Vector3 center = plane.transform.position;
				int a = i * angle;
				Vector3 pos = RandomCircle(center, Random.Range(-8f,-15f) ,Random.Range(18,30));
				Instantiate(StarPrefab, pos, Quaternion.identity);
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
	IEnumerator SpawnDelayer()
	{
		yield return new WaitForSeconds (5);
		SpawnStar ();
	}
		
	}
