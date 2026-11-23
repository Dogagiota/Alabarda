
using UnityEngine;

public class ControleInfo : MonoBehaviour
{
    public GameObject[] abas;

    void Start()
    {
        // Fecha todas as abas inicialmente
        foreach (GameObject aba in abas)
        {
            aba.SetActive(false);
        }
    }

    public void Alternar(int indice)
    {
        // Verifica se a aba selecionada já está aberta
        bool estaAberta = abas[indice].activeSelf;

        // Fecha todas as abas
        foreach (GameObject aba in abas)
        {
            aba.SetActive(false);
        }

        // Abre somente se ela estava fechada
        if (!estaAberta)
        {
            abas[indice].SetActive(true);
        }
    }
}
