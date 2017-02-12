using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

	TextMesh text;
	int compteur;

	void Start()
	{
		text = transform.GetChild (0).GetComponent<TextMesh> ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.CompareTag ("rocket")) {
			Destroy(col.gameObject);
			updateText ();
			GameEffect.FlashSpriteLerp (gameObject, new Color32(150,255,255,255), .2f);
		}
			

	}

	void updateText()
	{
		compteur++;
		text.text = compteur.ToString ();
	}
}
