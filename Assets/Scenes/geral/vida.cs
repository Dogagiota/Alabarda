using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    private Rigidbody2D rb;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;

        Debug.Log(gameObject.name + " recebeu " + dano + " de dano");

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu");

        Destroy(gameObject);
    }
}