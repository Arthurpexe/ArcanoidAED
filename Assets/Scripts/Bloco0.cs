using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco0 : MonoBehaviour
{
    private void Update()
    {
        if (CriaListaDeBlocos.singleton.listaDeBlocos.vazio())
        {
            CriaListaDeBlocos.singleton.listaDeBlocos.LocalizaBloco(0);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameController.singleton.filaDeBolas.Enfileira(GameController.singleton.CriaBola());
    }
}
