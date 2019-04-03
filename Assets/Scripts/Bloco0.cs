using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameController.singleton.filaDeBolas.Enfileira(GameController.singleton.CriaBola());
    }
}
