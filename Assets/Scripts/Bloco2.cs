using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco2 : MonoBehaviour
{
    public int vida;
    public GameObject bloco1;
    public float nLista;
    public int tipoBloco;

    public Bloco2(Bloco meuBloco)
    {
        nLista = meuBloco.nDaLista;
    }

    private void Update()
    {
        if (vida == 1)
        {
            Instantiate(bloco1, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vida -= 1;
    }
}
