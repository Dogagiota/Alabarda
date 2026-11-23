
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizBoss : MonoBehaviour
{
    public GameObject painelQuiz;
    public TMP_Text textoPergunta;
    public Button[] botoesResposta;
    public TMP_Text[] textosRespostas;

    public GameObject telaWin;

    private int perguntaAtual = 0;

    private string[] perguntas =
    {
        "Pergunta 1: Qual conflito histórico foi encerrado pela Batalha de Castillon?",
        "Pergunta 2: Qual território foi retomado pelos franceses após a vitória em Castillon?",
        "Pergunta 3: Qual foi o principal fator que contribuiu para a vitória francesa na Batalha de Castillon, em 1453?"
    };

    private string[,] respostas =
    {
        { "Guerra dos Cem Anos", "Guerra de Vinte Anos", "Guerra de Sucessão", "Guerra hispano-germânica" },
        { "Normandia", "Gasconha", "Borgonha", "Bretanha" },
        { "A superioridade naval francesa", "O uso da artilharia francesa", "A assinatura e um tratado de paz", "A rendição voluntária dos ingleses" }
    };

    private int[] respostasCorretas = { 0, 1, 1 };

    void Start()
    {
        painelQuiz.SetActive(false);
        telaWin.SetActive(false);
    }
    public void IniciarQuiz()
    {
        perguntaAtual = 0;
        painelQuiz.SetActive(true);
        MostrarPergunta();
    }

    void MostrarPergunta()
    {
        textoPergunta.text = perguntas[perguntaAtual];

        for (int i = 0; i < 4; i++)
        {
            textosRespostas[i].text = respostas[perguntaAtual, i];

            int indice = i;

            botoesResposta[i].onClick.RemoveAllListeners();
            botoesResposta[i].onClick.AddListener(
                () => VerificarResposta(indice)
            );
        }
    }

    void VerificarResposta(int resposta)
    {
        if (resposta == respostasCorretas[perguntaAtual])
        {
            Debug.Log("ACERTOU! Pergunta " + (perguntaAtual + 1) +
                      ": " + respostas[perguntaAtual, resposta]);

            perguntaAtual++;

            if (perguntaAtual >= perguntas.Length)
            {
                Debug.Log("PARABÉNS! Acertou todas as perguntas!");
                painelQuiz.SetActive(false);
                telaWin.SetActive(true);
            }
            else
            {
                MostrarPergunta();
            }
        }
        else
        {
            Debug.Log("ERROU! Pergunta " + (perguntaAtual + 1));
            Debug.Log("Resposta escolhida: " + respostas[perguntaAtual, resposta]);
            Debug.Log("Resposta correta: " + respostas[perguntaAtual, respostasCorretas[perguntaAtual]]);

            Debug.Log("O jogador errou e a Boss Fight será reiniciada!");

            Time.timeScale = 1f;

            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
