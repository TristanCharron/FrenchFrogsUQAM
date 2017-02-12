using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation3D : MonoBehaviour {
	[SerializeField]Vector3 speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.eulerAngles = new Vector3
			(
			transform.eulerAngles.x + speed.x * Time.deltaTime,
			transform.eulerAngles.y + speed.y * Time.deltaTime,
			transform.eulerAngles.z  + speed.z * Time.deltaTime
			);
	}
}
