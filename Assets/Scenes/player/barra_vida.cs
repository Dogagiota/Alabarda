using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider slider;
    public Vida vidaJogador;

    void Start()
    {
        slider.maxValue = vidaJogador.vidaMaxima;
        slider.value = vidaJogador.vidaAtual;
    }

    void Update()
    {
        slider.value = vidaJogador.vidaAtual;
    }
}