
using UnityEngine;

public class IniciarDialogoAutomatico : MonoBehaviour
{
    public SistemaDialogo sistemaDialogo;

    void Start()
    {
        if (sistemaDialogo != null)
        {
            sistemaDialogo.IniciarDialogo();
        }
        else
        {
            Debug.LogError("SistemaDialogo não conectado!");
        }
    }
}
