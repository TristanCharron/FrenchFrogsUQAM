using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRocketManager : MonoBehaviour
{

	[SerializeField]Transform containerRockets;
	[SerializeField]Transform StartSpawn;
	[SerializeField]Sprite[] rocketSprites;
	[SerializeField]GameObject[] rocketFire;
	[SerializeField]Color[] rocketColor;
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
		GameObject Fire = Instantiate (rocketFire [currentSprite], rocket.transform.localPosition, Quaternion.identity) as GameObject;
		rocket.GetComponent<Rocket> ().SetColorDeathAnim (rocketColor [currentSprite]);
		Fire.transform.SetParent (rocket.transform, true);
		Fire.transform.localEulerAngles = new Vector3(0,270,90);
		Fire.transform.localPosition = new Vector3(0,0,0);

		//	rocket.AddComponent<Rocket> ();

		rocket.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector2.up * speed);

	}
}
