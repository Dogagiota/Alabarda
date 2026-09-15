using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError(
                "Knockback: o objeto " + gameObject.name +
                " não possui Rigidbody2D!"
            );
        }
    }

    public void Aplicar(Vector2 direcao, float forca)
    {
        if (rb == null)
            return;

        rb.AddForce(
            direcao.normalized * forca,
            ForceMode2D.Impulse
        );
    }
}