using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRocketManager : MonoBehaviour
{

	[SerializeField]Transform containerRockets;
	[SerializeField]Transform StartSpawn;
	[SerializeField]Sprite[] rocketSprites;

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			SpawnRocket(Random.Range(-20,20), //x
			            Random.Range(-70,70), //rotation
			            Random.Range(400,600),//speed
			            Random.Range(0,rocketSprites.Length));
		}
	}


	[SerializeField]GameObject RocketPref;
	public void SpawnRocket(float x, float rotZ,float speed,int currentSprite)
	{
		GameObject rocket = Instantiate (RocketPref, new Vector2 (x, StartSpawn.position.y), Quaternion.Euler(0,0, rotZ)) as GameObject;
		rocket.transform.SetParent (containerRockets, true);
		rocket.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = rocketSprites [currentSprite];
		//	rocket.AddComponent<Rocket> ();

		rocket.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);

	}
}
