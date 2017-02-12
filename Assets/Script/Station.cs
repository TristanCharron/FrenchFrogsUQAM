using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

	TextMesh text;
	ParticleSystem particle;
	int compteur;

	void Start()
	{
		text = transform.GetChild (0).GetComponent<TextMesh> ();
		particle  = transform.GetChild (1).GetComponent<ParticleSystem> ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.CompareTag ("rocket")) {
			col.gameObject.GetComponent<Rocket>().DeathRocket();
			updateText ();
			GameEffect.FlashSpriteLerp (gameObject, new Color32(150,255,255,255), .2f);
			particle.Play();
		}
			

	}

	void updateText()
	{
		compteur++;
		text.text = compteur.ToString ();
		GameEffect.FlashSpriteLerp (gameObject, new Color32(150,255,255,255), .2f);

	}
}
