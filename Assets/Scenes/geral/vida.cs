using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    public bool morto = false;

    void Start()
    {
        vidaAtual = vidaMaxima;
        morto = false;
    }

    public void ReceberDano(int dano)
    {
        if (morto)
            return;

        vidaAtual -= dano;

        Debug.Log(gameObject.name + " recebeu " + dano + " de dano");

        if (vidaAtual <= 0)
        {
            Debug.Log(gameObject.name + " morreu");
            Morrer(gameObject.name);
        }
    }

    void Morrer(string nome)
    {
        morto = true;
        Debug.Log(nome);
        if (nome == "corpo_p")
        {
             TelaMorte telaMorte = FindAnyObjectByType<TelaMorte>();

            if (telaMorte != null)
            {
                telaMorte.MostrarTelaMorte();
            }
        }
        else
        {
           
            TelaWin telaWin = FindAnyObjectByType<TelaWin>();

            if (telaWin != null)
            {
                telaWin.MostrarTelaWin();
            }
        }

        Time.timeScale = 0f;
    }
}