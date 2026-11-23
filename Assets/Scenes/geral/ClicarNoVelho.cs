
using UnityEngine;

public class ClicarNoVelho : MonoBehaviour
{
    public MonoBehaviour sistemaDialogo;

    void OnMouseDown()
    {
        if (sistemaDialogo == null)
        {
            Debug.LogError("Nenhum sistema de diálogo foi conectado!");
            return;
        }

        // Procura e executa o método IniciarDialogo
        sistemaDialogo.SendMessage(
            "IniciarDialogo",
            SendMessageOptions.RequireReceiver
        );
    }
}
