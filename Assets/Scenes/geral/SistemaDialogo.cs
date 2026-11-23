
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SistemaDialogo : MonoBehaviour
{
    public TMP_Text textoFala;
    public TMP_Text nomePersonagem;
    public Button botaoAvancar;

    public GameObject elementosDialogo;

    [TextArea(2, 5)]
    public string[] falas;

    private int falaAtual = 0;
    private bool dialogoAtivo = false;

    void Awake()
    {
        Time.timeScale = 1f;

        elementosDialogo.SetActive(false);

        botaoAvancar.onClick.RemoveListener(AvancarFala);
        botaoAvancar.onClick.AddListener(AvancarFala);
    }

    public void IniciarDialogo()
    {
        if (dialogoAtivo) return;

        if (falas == null || falas.Length == 0)
        {
            Debug.LogError("Nenhuma fala cadastrada!");
            return;
        }

        falaAtual = 0;
        dialogoAtivo = true;

        // Pausa o jogo
        Time.timeScale = 0f;

        // Mostra os elementos do diálogo
        elementosDialogo.SetActive(true);

        MostrarFala();

        Debug.Log("DIÁLOGO ABERTO!");
    }

    void MostrarFala()
    {
        textoFala.text = falas[falaAtual];
    }

    public void AvancarFala()
    {
        if (!dialogoAtivo) return;

        falaAtual++;

        if (falaAtual >= falas.Length)
        {
            EncerrarDialogo();
            return;
        }

        MostrarFala();
    }

    void EncerrarDialogo()
    {
        dialogoAtivo = false;

        // Fecha os elementos do diálogo
        elementosDialogo.SetActive(false);

        // Retoma o jogo
        Time.timeScale = 1f;

        Debug.Log("DIÁLOGO ENCERRADO!");
    }
}
