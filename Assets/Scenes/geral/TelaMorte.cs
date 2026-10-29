
using UnityEngine;

public class TelaMorte : MonoBehaviour
{
    public GameObject vcmorreu_0;
    public GameObject botaoReiniciar;
    public GameObject botaomMenu;

    void Start()
    {
        vcmorreu_0.SetActive(false);
        botaoReiniciar.SetActive(false);
        botaomMenu.SetActive(false);
    }

    public void MostrarTelaMorte()
    {
        vcmorreu_0.SetActive(true);
        botaoReiniciar.SetActive(true);
        botaomMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
