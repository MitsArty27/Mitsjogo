using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 1. o player com movimento e animação
/// 2. os huds com o contador de moedas;o contador de score e as chances
/// </summary>
public class ScriptPlayer2 : MonoBehaviour {
	int Chave;
    [Tooltip("Variável inteira positiva responsável pela velocidade X do player.")]
    [Header("PLAYER")]
    public float veloX = 4f;//
    public float forcaPulo = 660f;//
    public bool estaNoChao;//
    public bool podeAtirar;
    [Header("TIRO")]
    public Transform posicaoTiroDireita;
    public Transform posicaoTiroEsquerda;
    public GameObject balaDireita;
    public GameObject balaEsquerda;
    bool podePuloDuplo; //
    Rigidbody2D playerRb;
    SpriteRenderer playerSR;
    Animator playerAnima;
    ScriptGame scriptGame;


    void Start()
    {
		Chave = 0;
        playerRb = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        playerAnima = GetComponent<Animator>();
        scriptGame = FindObjectOfType<ScriptGame>();
        scriptGame = ScriptGame.instancia;
        scriptGame.ZerarHUDs();
        scriptGame.AtualizarChancePerda();


    }
    void Update() {

        float playerSentido = Input.GetAxisRaw("Horizontal");
        if (playerSentido != 0) {
            Mover(playerSentido);
        }
        else
        {
            Parar();
        }
        if (Input.GetButtonDown("Jump")) {
            Pular();
        }
        if (Input.GetButtonDown("Fire1")) {
            Atirar();
        }
    }
    void Mover(float playerSentido) {
        if (playerSentido < 0) {
            playerSR.flipX = true;
        }
        else if (playerSentido > 0) {
            playerSR.flipX = false;
        }

        float velocidade = veloX * playerSentido;
        playerRb.velocity = new Vector2(velocidade, playerRb.velocity.y);
        if (estaNoChao == true)
            playerAnima.SetInteger("Anima", 1);
    }
    void Parar() {
        playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        if (estaNoChao == true)
            playerAnima.SetInteger("Anima", 0);
    }
    void Pular() {
        if (estaNoChao == true) {
            estaNoChao = false;
            playerRb.AddForce(new Vector2(0, forcaPulo));
            playerAnima.SetInteger("Anima", 2);
            podePuloDuplo = true;
        }
        else
        {
            if (podePuloDuplo == true && estaNoChao == false) {
                playerRb.velocity = Vector2.zero;
                playerRb.AddForce(new Vector2(0, forcaPulo));
                podePuloDuplo = false;
            }
        }
    }

		void Atirar()
		{
			if (Chave > 0)
			{
				if (playerSR.flipX == true) {
					Instantiate (balaEsquerda, posicaoTiroEsquerda.position,
						Quaternion.identity);
				}
				if (playerSR.flipX == false) {
					Instantiate (balaDireita, posicaoTiroDireita.position,
						Quaternion.identity);
				}
			}
		}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Chave")) {
			scriptGame.AtulizarChave ();
			Chave += 1;
			Destroy (other.gameObject);
		}
        if (other.gameObject.CompareTag("Moeda")) {
            scriptGame.AtualizarHUDs();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Fantasma")) {
            gameObject.SetActive(false);
            scriptGame.Reiniciar();
        }

    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Chao")) {
            estaNoChao = true;
        }
        if (other.gameObject.CompareTag("Agua")) {
            gameObject.SetActive(false);
            scriptGame.Reiniciar();
        }
        if (other.gameObject.CompareTag("Passar"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("Passar2"))
        {
            SceneManager.LoadScene(3);
        }
        if (other.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(5);
        }
        
    }
    }
