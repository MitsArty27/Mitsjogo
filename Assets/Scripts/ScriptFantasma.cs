using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFantasma : MonoBehaviour {

	[Header("INFOS")]
	public float distanciaPlayerFantasma;
	public float veloFantasma;
	private Transform playerPos;

	GameObject player;

	void Start ()
	{
		player = GameObject.Find("Player");
		playerPos = player.GetComponent<Transform>();
	} // fim do método Start()

	void Update ()
	{
		// o transform é do Fantasma - aonde o ScriptFantasma esta ligado
		float distanciaAtual = Vector2.Distance(transform.position,
			playerPos.position);
		if (distanciaAtual < distanciaPlayerFantasma)
		{
			transform.position = Vector2.MoveTowards(transform.position,
				playerPos.position,
				veloFantasma * Time.deltaTime);
		}
	}// fim do método Update()
}