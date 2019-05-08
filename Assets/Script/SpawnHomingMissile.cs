using UnityEngine;
using System.Collections;

public class SpawnHomingMissile : MonoBehaviour 
{
	PlaneController Plane;

	float x =0;
	float y = 0;
	public float maxDistance,minDistance;
	public GameObject missile;
	void Start () 
	{
		Plane = (PlaneController)GameObject.FindObjectOfType(typeof(PlaneController));
	}


	void Update () 
	{
//			player X position
		if (Plane.transform.position.x < 0) {
			float PlayerX = Plane.transform.position.x * -1;
			x = Random.Range (PlayerX + minDistance, PlayerX + maxDistance) * -1;
		} 
		else 
		{
			float PlayerX = Plane.transform.position.x ;
			x = Random.Range (PlayerX + minDistance, PlayerX + maxDistance);
		}
//		player Y position
		if (Plane.transform.position.y < 0) {
			float PlayerY = Plane.transform.position.y * -1;
			x = Random.Range (PlayerY + minDistance, PlayerY + maxDistance) * -1;
		} 
		else 
		{
			float PlayerY = Plane.transform.position.y;
			x = Random.Range (PlayerY + minDistance, PlayerY + maxDistance);
		} 

		Instantiate (missile, new Vector3 (x, y, 0), Quaternion.identity);

	}
}
