using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {

	// a cena desejada é indicada através do parâmetro cenaNome
    // escrever 
	public void CarregarCena (string cenaNome) {
        SceneManager.LoadScene(cenaNome);
	}
}
