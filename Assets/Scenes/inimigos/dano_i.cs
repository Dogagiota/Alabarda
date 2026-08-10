using UnityEngine;

public class dano_i : MonoBehaviour
{
    public int dano = 10;
    public float intervaloDano = 2f;

    private bool tocandoPlayer;
    private float proximoDano;
    private Vida vidaPlayer;

    void Update()
    {
        if (tocandoPlayer &&
            vidaPlayer != null &&
            Time.time >= proximoDano)
        {
            vidaPlayer.ReceberDano(dano);

            Knockback knockbackPlayer =
                vidaPlayer.GetComponent<Knockback>();

            if (knockbackPlayer != null)
            {
                Vector2 direcao =
                    (vidaPlayer.transform.position - transform.position).normalized;

                knockbackPlayer.Aplicar(direcao, 5f);
            }

            proximoDano = Time.time + intervaloDano;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
        {
            tocandoPlayer = true;
            vidaPlayer = collision.gameObject.GetComponent<Vida>();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
        {
            tocandoPlayer = false;
            vidaPlayer = null;
        }
    }
}