using UnityEngine;

public class TelaWin : MonoBehaviour
{
    public GameObject vcGanhou_0;
    public GameObject vcGanhou_1;

    private SpriteRenderer spriteRenderer0;
    private SpriteRenderer spriteRenderer1;

    void Start()
    {
        spriteRenderer0 = vcGanhou_0.GetComponent<SpriteRenderer>();
        spriteRenderer1 = vcGanhou_1.GetComponent<SpriteRenderer>();

        spriteRenderer0.enabled = false;
        spriteRenderer1.enabled = false;
    }

    public void MostrarTelaWin()
    {
        spriteRenderer0.enabled = true;
        spriteRenderer1.enabled = true;

        Time.timeScale = 0f;
    }
}