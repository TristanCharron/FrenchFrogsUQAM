using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
	[SerializeField]float maxSpeed = 25f;
	[SerializeField]GameObject deathAnim;
	float realMaxSpeed;
	Color deathanimColor;
	bool inControl = true;
	Rigidbody2D rigid;
	void Start()
	{
		realMaxSpeed = maxSpeed * 2;
		rigid = GetComponent<Rigidbody2D> ();
		StartCoroutine(DelayDeath(15f,false));
	}
	void Update()
	{
		if(inControl)
			RotateToVelocity ();

		/*
		if (rigid.velocity.x + rigid.velocity.y > realMaxSpeed)
		{
			rigid.velocity = new Vector2(
				(rigid.velocity.x > maxSpeed)? maxSpeed: rigid.velocity.x,
				(rigid.velocity.y > maxSpeed)? maxSpeed: rigid.velocity.y);
		}*/
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
			StartCoroutine(DelayDeath(.5f,true));
			inControl = false;
		} else if (col.gameObject.CompareTag ("planet"))
		{
			GameEffect.Shake(Camera.main.gameObject,.1f,.2f);
			//GameEffect.FreezeFrame(.05f);
			DeathRocket();
		}


			

	}
	public void SetColorDeathAnim(Color color)
	{
		deathanimColor = color;
	}
	IEnumerator DelayDeath(float t,bool stopEmmit)
	{
		if(stopEmmit)
			transform.GetChild(1).GetComponent<ParticleSystem> ().Stop ();
		yield return new WaitForSeconds (t);
		DeathRocket ();
	}
	public void DeathRocket()
	{
		//fade system
		Transform particle = gameObject.transform.GetChild (1);
		particle.SetParent (transform.parent, true);
		particle.GetComponent<ParticleSystem> ().Stop ();
		particle.gameObject.AddComponent<DelayDeath> ().delay = 1;
	
		GameObject death = Instantiate (deathAnim, gameObject.transform.position, Quaternion.identity) as GameObject;
		death.transform.SetParent (gameObject.transform.parent);
		death.gameObject.AddComponent<DelayDeath> ().delay = 1;
		death.transform.eulerAngles = new Vector2 (-90, 0);

		death.GetComponent<ParticleSystem>().startColor = deathanimColor;

		Destroy (gameObject);
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("planet") || col.gameObject.CompareTag("station"))
		{
			rigid.AddForce(col.GetComponent<Attraction>().Attract(gameObject));
		}
	}
}
