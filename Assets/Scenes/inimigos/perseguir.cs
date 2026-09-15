using UnityEngine;

public class Perseguir : MonoBehaviour
{
    public float velocidade = 4f;
    public float distanciaAtaque = 2f;
    public float delayAtaque = 1.5f;
    public int danoAtaque = 10;
    public int danoContato = 5;

    private Rigidbody2D rb;
    private Animator animator;
    private GameObject corpo_p;
    private bool tocandoPlayer;
    private float proximoAtaque;
    private Vector2 direcaoAtual = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        corpo_p = GameObject.FindWithTag("corpo_p");
    }

    void FixedUpdate()
    {
        if (corpo_p == null)
        {
            rb.linearVelocity = Vector2.zero;
            direcaoAtual = Vector2.zero;

            if (animator != null)
                animator.SetFloat("speed", 0);

            return;
        }

        float distancia = Vector2.Distance(
            transform.position,
            corpo_p.transform.position
        );

        Vector2 direcao =
            (corpo_p.transform.position - transform.position).normalized;

        direcaoAtual = direcao;

        rb.linearVelocity = direcao * velocidade;

        if (animator != null)
        {
            animator.SetFloat("horizontal", direcao.x);
            animator.SetFloat("vertical", direcao.y);
            animator.SetFloat("speed", rb.linearVelocity.sqrMagnitude);
        }

        if (distancia < distanciaAtaque)
        {
            if (Time.time >= proximoAtaque)
            {
                proximoAtaque = Time.time + delayAtaque;

                if (animator != null)
                    animator.SetTrigger("attack");

                Collider2D[] alvos = Physics2D.OverlapCircleAll(
                    transform.position,
                    distanciaAtaque
                );

                foreach (Collider2D alvo in alvos)
                {
                    if (alvo.CompareTag("corpo_p"))
                    {
                        Vida vida = alvo.GetComponent<Vida>();

                        if (vida != null)
                            vida.ReceberDano(danoAtaque);
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
        {
            tocandoPlayer = true;

            Vida vida = collision.gameObject.GetComponent<Vida>();

            if (vida != null)
                vida.ReceberDano(danoContato);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("corpo_p"))
            tocandoPlayer = false;
    }

    public bool EstaSeMovendo()
    {
        return rb.linearVelocity != Vector2.zero;
    }

    public bool EstaBatendoNoPlayer()
    {
        return tocandoPlayer;
    }

    public Vector2 GetDirecao()
    {
        return direcaoAtual;
    }

    public Vector2 GetVelocidade()
    {
        return rb.linearVelocity;
    }
}