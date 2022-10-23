using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScriptGame : MonoBehaviour {
	// variáveis estáticas dos HUDs
	// os valores são mantidos mesmo com a troca da cena
	[Header("TEXT")]
	public Text textMoeda;
	public Text textScoreTotal;
	[Header("IMAGE")]
	public Image imageChance1;
	public Image imageChance2;
	public Image imageChance3;
	public Image Chave;


	[Header("SPRITE")]

	public Sprite spriteChance;
	public Sprite spritePerda;
	public Sprite SpriteChaveOff;
	public Sprite SpriteChaveOn;
	public static int moeda;
	public static int scoreAux;
	public static int scoreTotal;
	public static int chance = 3;
	public static ScriptGame instancia;
	// este método ocorre antes de qq atividade do game, bem antes do Start()
	// nele isntanciamos um objeto ScriptGame para ser utilizado em outros Scripts
	private void Awake()
	{
		if (instancia == null)
		{
			instancia = this;
		}
	}
	// inicializa os HUDs da cena
	public void ZerarHUDs()
	{
		textMoeda.text = " X " + moeda;
		textScoreTotal.text = "Score : " + scoreTotal;
	}
	public void Reiniciar()
	{
		// espera 1 segundo e depois reinicia o jogo
		Invoke("ReiniciarJogo", 1.0f);
	}
	public void ReiniciarJogo()
	{
		chance += -1; // retira uma chance do Player
		if (chance == 0) // verifica se esgotou o num. de chances
		{
			// sim, reinicia todas as variáveis de controle
			moeda = 0;
			scoreAux = 0;
			scoreTotal = 0;
			chance = 3;
			// sim, recarrega a primeira cena
			SceneManager.LoadScene(4); // volta para a CenaMenu
		}
		else
		{
			// não, volta para o início da atual cena - CenaLevel2
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	public void AtualizarChancePerda()
	{
		if (chance == 3) // verifica se game está no início
		{
			// sim, acerta os corações para vermelho
			imageChance1.sprite = spriteChance;
			imageChance2.sprite = spriteChance;
			imageChance3.sprite = spriteChance;
		}
		if (chance == 2) // verifica se perdeu a primeira chance
		{
			// sim, acerta o primeiro coração para branco
			imageChance1.sprite = spritePerda;
		}
		if (chance == 1) // verifica se perdeu a segunda chance
		{
			// sim, acerta os corações, primeiro e segundo, para branco
			imageChance1.sprite = spritePerda;
			imageChance2.sprite = spritePerda;
		}
	}


	public void AtualizarHUDs()
	{
		// o Player colidiu com a Moeda
		moeda += 1; // aumenta de uma unidade o contador de Moedas
		scoreAux += 1;// aumenta de uma unidade o contador de Score
		if (scoreAux == 2) // verifica se pode pontuar o Score
		{
			// sim, aumenta o Score Total de + 10
			scoreTotal += 10; // valor escolhido de +10
			scoreAux = 0; // reinicia o Score Auxiliar
		}
		// atualiza os HUDs no PanelHUD
		textMoeda.text = " X " + moeda; // atualiza o HUD
		textScoreTotal.text = "Score : " + scoreTotal;
	}
	public void AtulizarChave()
	{
		Chave.sprite = SpriteChaveOn;

	}
}