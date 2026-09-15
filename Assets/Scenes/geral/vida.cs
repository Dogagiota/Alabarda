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

        TelaMorte tela = FindAnyObjectByType<TelaMorte>();

        if (tela != null)
        {
            tela.MostrarTelaMorte();
        }

        Time.timeScale = 0f;
    }
}