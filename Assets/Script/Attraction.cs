using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class Attraction : MonoBehaviour 
{
	[SerializeField]bool isAttracting;
	[SerializeField]float G = 2;
	public Vector2 Attract(GameObject Rocket)
	{
		float distance = GameMath.DistanceXY (Rocket, gameObject) * G;
		
		Vector2 v;
		if (isAttracting)
			v = new Vector2 (
				Mathf.Lerp (0, gameObject.transform.position.x - Rocket.transform.position.x, distance),
				Mathf.Lerp (0, gameObject.transform.position.y - Rocket.transform.position.y, distance));
		else
			v = new Vector2(
				Mathf.Lerp(0,Rocket.transform.position.x - gameObject.transform.position.x, distance),
				Mathf.Lerp(0,Rocket.transform.position.y - gameObject.transform.position.y, distance));

		return v;
	}
}
