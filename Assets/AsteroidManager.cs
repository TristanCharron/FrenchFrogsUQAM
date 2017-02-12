using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

	float speed = 50;
	[SerializeField] GameObject[] asteroids;
	const float minT = 3, maxT = 12;
	const float minScale = 1, MaxScale = 12;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnRandom(Random.Range(minT, maxT)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnRandom(float t)
	{
		yield return new WaitForSeconds(t);
		int random = Random.Range (0,3);
		float randomScale = Random.Range (minScale,MaxScale);
		GameObject asteroid = Instantiate (asteroids[Random.Range(0,asteroids.Length)], transform.position, Quaternion.identity);
		asteroid.transform.SetParent (gameObject.transform,true);
		asteroid.transform.position = ReturnSpawnPos (random);
		asteroid.transform.localScale = new Vector3 (randomScale,randomScale,randomScale);
		asteroid.transform.eulerAngles = new Vector3(0,0,ReturnAngle (random));

		asteroid.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);
		Destroy (asteroid, 80);
		StartCoroutine (SpawnRandom(Random.Range(minT, maxT)));
	}

	Vector3 ReturnSpawnPos(int random)
	{
		Vector3 v = new Vector3(0,0);
	    //random = Random.Range(0,3);
		switch (random) {
		case 0:
		case 2:
			v = new Vector3( transform.GetChild(random).position.x,Random.Range(-6,6), 25);
			break;
		case 1:
			v = new Vector3(Random.Range(-13,13), transform.GetChild(random).position.y, 25);
			break;
	
		}
		return v;
	}

	float ReturnAngle(int random)
	{
		float v = 0;
		switch (random) {
		case 0:

			v = Random.Range(225,315);
			break;
		case 1:
			v = Random.Range(135,225);
			break;

		case 2:
			v = Random.Range(45,135);
			break;
			
		}
		return v;
	}
}
