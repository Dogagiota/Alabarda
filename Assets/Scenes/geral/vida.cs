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
            Morrer();
        }
    }

    void Morrer()
    {
        morto = true;

        if (gameObject.name == "Guilherme")
        {
            TelaWin telaWin = FindAnyObjectByType<TelaWin>();

            if (telaWin != null)
            {
                telaWin.MostrarTelaWin();
            }
        }
        else
        {
            TelaMorte telaMorte = FindAnyObjectByType<TelaMorte>();

            if (telaMorte != null)
            {
                telaMorte.MostrarTelaMorte();
            }
        }

        Time.timeScale = 0f;
    }
}