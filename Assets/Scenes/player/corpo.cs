using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movimento;
    private Vector2 ultimaDirecao = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vida vida = GetComponent<Vida>();

        if (vida != null && vida.morto)
        {
            movimento = Vector2.zero;
            return;
        }

        movimento = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movimento.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movimento.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movimento.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movimento.x += 1;

        movimento.Normalize();

        if (movimento != Vector2.zero)
        {
            if (movimento.y != 0)
            {
                ultimaDirecao = new Vector2(0, movimento.y);
            }
            else
            {
                ultimaDirecao = new Vector2(movimento.x, 0);
            }
        }

        animator.SetFloat("horizontal", movimento.x);
        animator.SetFloat("vertical", movimento.y);
        animator.SetFloat("speed", movimento.sqrMagnitude);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            animator.SetTrigger("attack");

            PlayerAttack ataque = GetComponent<PlayerAttack>();

            if (ataque != null)
            {
                ataque.Atacar();
            }
        }
    }

    void FixedUpdate()
    {
        Vida vida = GetComponent<Vida>();

        if (vida != null && vida.morto)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = movimento * velocidade;
    }

    public Vector2 GetUltimaDirecao()
    {
        return ultimaDirecao;
    }
}