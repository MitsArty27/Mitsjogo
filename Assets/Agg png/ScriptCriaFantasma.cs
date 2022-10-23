using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCriaFantasma : MonoBehaviour {

	[Header("FANTASMA")]
	public GameObject fantasma;
	public float veloTaxa; // tempo em seg. para criar um novo Fantasma
	float tempoNovoFantasma = 0f;
	// Update is called once per frame
	void Update () {
		// verifica se pode criar um Fantasma
		if (Time.time > tempoNovoFantasma)
		{
			// sim, antes prepara um novo tempo de espera
			tempoNovoFantasma = Time.time + veloTaxa;
			// instancia (cria) um Fantasma depois de passar o tempo de tempoNovoFantasma
			Instantiate(fantasma, transform.position, fantasma.transform.rotation);
		}
	}
}