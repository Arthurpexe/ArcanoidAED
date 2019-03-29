using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Desistir()
    {
        Application.Quit();
    }
    public void JogarNovamente()
    {
        GameController.singleton.filaDeBolas.Enfileira(GameController.singleton.CriaBola());
    }
}
