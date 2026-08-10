using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimento * velocidade;
    }
}