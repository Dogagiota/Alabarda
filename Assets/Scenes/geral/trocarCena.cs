
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string nomeCena;

    public void IrParaCena()
    {
        Debug.Log("Trocando para a cena: " + nomeCena);

        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCena);
    }
}
