
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarBatalha : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
