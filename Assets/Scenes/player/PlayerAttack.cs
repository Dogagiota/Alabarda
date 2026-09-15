using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int dano = 10;
    public float distanciaAtaque = 3f;

    // Coloca aqui a Layer dos inimigos
    public LayerMask camadaInimigo;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Atacar()
    {
        Vida vida = GetComponent<Vida>();

        if (vida != null && vida.morto)
        {
            return;
        }

        Vector2 direcao = playerMovement.GetUltimaDirecao();

        Vector2 centroAtaque =
            (Vector2)transform.position + direcao * (distanciaAtaque / 2f);

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(
            centroAtaque,
            distanciaAtaque / 2f,
            camadaInimigo
        );

        Debug.Log("===== ATAQUE =====");
        Debug.Log("Player: " + gameObject.name);
        Debug.Log("Direção: " + direcao);
        Debug.Log("Colliders encontrados: " + inimigos.Length);

        foreach (Collider2D inimigo in inimigos)
        {
            Debug.Log(
                "ACHEI: " + inimigo.name +
                " | Layer: " + LayerMask.LayerToName(inimigo.gameObject.layer)
            );

            Vida vidaInimigo = inimigo.GetComponent<Vida>();

            if (vidaInimigo != null)
            {
                Debug.Log("VIDA PERTENCE A: " + vidaInimigo.gameObject.name);

                vidaInimigo.ReceberDano(dano);
            }
            else
            {
                Debug.Log("Esse objeto não tem Vida.cs");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (playerMovement == null)
            return;

        Vector2 direcao = playerMovement.GetUltimaDirecao();

        Vector2 centro =
            (Vector2)transform.position + direcao * (distanciaAtaque / 2f);

        Gizmos.DrawWireSphere(centro, distanciaAtaque / 2f);
    }
}
