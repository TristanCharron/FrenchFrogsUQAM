using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
	bool inControl = true;
	Rigidbody2D rigid;
	void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 15);
	}
	void Update()
	{
		if(inControl)
			RotateToVelocity ();
	}
	public void RotateToVelocity() 
	{ 
		Vector2 dir = rigid.velocity;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("rocket"))
		{
			Destroy (gameObject, .5f);
			inControl = false;
		}
		else if(col.gameObject.CompareTag("planet"))
		     Destroy(gameObject);
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "planet") 
		{
			float distance = GameMath.DistanceXY (gameObject, col.gameObject) * 2;
			rigid.AddForce(
				new Vector2(Mathf.Lerp(0,col.transform.position.x - gameObject.transform.position.x, distance),
			            Mathf.Lerp(0,col.transform.position.y - gameObject.transform.position.y, distance)));

				}
	}
}
