using UnityEngine;

public class TelaMorte : MonoBehaviour
{
    public GameObject vcmorreu_0;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = vcmorreu_0.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void MostrarTelaMorte()
    {
        spriteRenderer.enabled = true;
        Time.timeScale = 0f;
    }
}