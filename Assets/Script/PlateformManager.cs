using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		
			if (hit.collider != null)
			{
				ShakePlatform(hit.collider.gameObject);
				Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
			}
		}
	}
	void ShakePlatform(GameObject obj)
	{
		obj.transform.eulerAngles = new Vector3
			(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + Random.Range(-10,10));
		obj.transform.localPosition = new Vector2
			(obj.transform.localPosition.x + Random.Range (-0.1f, 0.1f), obj.transform.localPosition.y + Random.Range (-0.1f, -0.01f));
	}
}
