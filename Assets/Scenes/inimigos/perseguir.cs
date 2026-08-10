using UnityEngine;

public class Perseguir : MonoBehaviour
{
    public float velocidade = 4f;

    private Rigidbody2D rb;
    private GameObject corpo_p;
    private bool tocandoPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        corpo_p = GameObject.FindWithTag("corpo_p");
    }

    void FixedUpdate()
    {
        if (corpo_p == null)
            return;

        if (tocandoPlayer)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direcao =
            (corpo_p.transform.position - transform.position).normalized;

        rb.linearVelocity = direcao * velocidade;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
        {
            tocandoPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
        {
            tocandoPlayer = false;
        }
    }
}