using UnityEngine;
using System.Collections;

public class MissileSpawn : MonoBehaviour {
	public GameObject homeScreen;
	public GameObject hazard;
	float XspawnValues;
	float YspawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
//		Vector3	spawnValues = this.gameObject.transform.position;
//		XspawnValues = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(1.0f,3.0f), 0, 0.0f)).x;;
//		YspawnValues = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(1.0f,3.0f), 0.0f)).y;;
//		if (homeScreen.activeInHierarchy == false)
		{
			StartCoroutine (SpawnWaves ());
		}
	}
	void Update()
	{
		XspawnValues = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-6.0f,6.1f), 0, 0.0f)).x;;
		YspawnValues = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(-4.0f,4.1f), 0.0f)).y;;
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
			//	Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0);
				Quaternion spawnRotation = Quaternion.identity;

				  Instantiate (hazard, new Vector3(XspawnValues,YspawnValues,0), spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}