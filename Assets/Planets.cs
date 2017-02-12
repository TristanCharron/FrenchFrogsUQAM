using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {

    [SerializeField]
	float speed = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y + speed * Time.deltaTime, transform.eulerAngles.z);
		
	}
}
