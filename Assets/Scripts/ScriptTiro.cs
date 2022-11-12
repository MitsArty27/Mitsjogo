using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// manipula os alvos colididos pelos tiros do Player
/// </summary>
public class ScriptTiro : MonoBehaviour {
	[Header("TIRO")]
	public float tempoTiro;
	public Vector2 veloTiro;
	Rigidbody2D tiroRb;
	ScriptGame scriptGame;

	void Start () {
		tiroRb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, tempoTiro);
	}

	void Update () {
		tiroRb.velocity = veloTiro;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Fantasma"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		else
		{
			if (other.gameObject.CompareTag("Player") == false)
			{
				Destroy(gameObject);
			}
		}
	}
}

