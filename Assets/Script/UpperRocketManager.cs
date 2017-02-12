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
			            new Vector2(Random.Range(-70,70),1), //rotation
			            Random.Range(400,600),//speed
			            Random.Range(0,rocketSprites.Length));
		}
	}


	[SerializeField]GameObject RocketPref;
	public void SpawnRocket(float x, Vector2 rotation,float speed,int currentSprite)
	{
		GameObject rocket = Instantiate (RocketPref, new Vector2 (x, StartSpawn.position.y), Quaternion.Euler(0,0,rotation.x)) as GameObject;
		rocket.transform.SetParent (containerRockets, true);
		rocket.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = rocketSprites [currentSprite];
		//	rocket.AddComponent<Rocket> ();

		rocket.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);

	}
}
