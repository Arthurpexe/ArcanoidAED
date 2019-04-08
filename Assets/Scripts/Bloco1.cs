using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco1 : MonoBehaviour
{
    public int vida;
    public int tipoBloco;
    public AudioSource ruidoMorte;
    Bloco blocoDesalistado;
    public Bloco myBloco;
    

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        vida -= 1;
        ruidoMorte.Play();
    }
}
