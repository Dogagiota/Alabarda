using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Aplicar(Vector2 direcao, float forca)
    {
        rb.AddForce(
            direcao.normalized * forca,
            ForceMode2D.Impulse
        );
    }
}