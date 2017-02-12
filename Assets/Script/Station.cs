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
		}
			

	}

	void updateText()
	{
		compteur++;
		text.text = compteur.ToString ();
	}
}
