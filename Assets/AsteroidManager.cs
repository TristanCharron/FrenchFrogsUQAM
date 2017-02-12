using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

	float speed = 50;
	[SerializeField] GameObject[] asteroids;
	const float minT = 10, maxT = 20;


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
		GameObject asteroid = Instantiate (asteroids[Random.Range(0,asteroids.Length)], transform.position, Quaternion.identity);
		asteroid.transform.position = ReturnSpawnPos (random);
		asteroid.transform.eulerAngles = new Vector3(0,0,ReturnAngle (random));
		asteroid.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);

		StartCoroutine (SpawnRandom(Random.Range(minT, maxT)));
	}

	Vector2 ReturnSpawnPos(int random)
	{
		Vector2 v = new Vector2(0,0);
	    //random = Random.Range(0,3);
		switch (random) {
		case 0:
		case 2:
			v = new Vector2( transform.GetChild(random).position.x,Random.Range(-6,6));
			break;
		case 1:
			v = new Vector2(Random.Range(-13,13), transform.GetChild(random).position.y);
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
