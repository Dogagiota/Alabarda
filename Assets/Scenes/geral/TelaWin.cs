
using UnityEngine;

public class TelaWin : MonoBehaviour
{
    public GameObject telawin;
    public GameObject botaomMenu;

    void Start()
    {
        telawin.SetActive(false);
        botaomMenu.SetActive(false);
    }

    public void MostrarTelaWin()
    {
        telawin.SetActive(true);
        botaomMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void EsconderTelaWin()
    {
        telawin.SetActive(false);
        botaomMenu.SetActive(false);
    }
}
