using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco1 : MonoBehaviour
{
    public int vida;
    public float nLista;
    public int tipoBloco;
    public AudioSource ruidoMorte;
    Bloco blocoDesalistado;

    public Bloco1(Bloco meuBloco)
    {
        nLista = meuBloco.nDaLista;
    }

    private void Update()
    {
        if(vida == 0)
        {
            blocoDesalistado = CriaListaDeBlocos.singleton.listaDeBlocos.Desalistar(tipoBloco);
            if (blocoDesalistado != null)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vida -= 1;
        ruidoMorte.Play();
    }
}
