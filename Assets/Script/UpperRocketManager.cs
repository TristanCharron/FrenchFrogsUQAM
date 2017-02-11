using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRocketManager : MonoBehaviour
{

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			SpawnRocket(Random.Range(-10,10),new Vector2(Random.Range(-70,70),1),Random.Range(100,200));
		}

	}


	[SerializeField]GameObject RocketPref;
	public void SpawnRocket(float x, Vector2 rotation,float speed)
	{
		GameObject rocket = Instantiate (RocketPref, new Vector2 (x, -5), Quaternion.Euler(0,0,rotation.x)) as GameObject;
	//	rocket.AddComponent<Rocket> ();

		rocket.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);

	}
}
