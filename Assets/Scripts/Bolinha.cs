using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    CriaListaDeBlocos lista;
    private void OnTriggerEnter(Collider other)
    {
        if(other == GameController.singleton.colisorPlataforma)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameController.singleton.bolasPegas += 1;
            GameController.singleton.nBolasGame -= 1;
            Destroy(this.gameObject);
        }
        else if(other.tag == "bloco0")
        {
            lista = other.GetComponentInParent<CriaListaDeBlocos>();

            if (lista.listaDeBlocos.vazio())
            {
                lista.listaDeBlocos.DesalistarConteudo(other.GetComponent<Bloco0>().myBloco);
                lista.listaDeBlocos.QuantosBlocos();
                GameController.singleton.audios.transform.GetChild(2).GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
            }

        }
        else if(other.tag =="bloco1")
        {
            lista = other.GetComponentInParent<CriaListaDeBlocos>();

            lista.listaDeBlocos.DesalistarConteudo(other.GetComponent<Bloco1>().myBloco);
            lista.listaDeBlocos.QuantosBlocos();
            GameController.singleton.audios.transform.GetChild(2).GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
        else if(other.tag =="bloco2")
        {
            lista = other.GetComponentInParent<CriaListaDeBlocos>();

           if (other.GetComponent<Bloco2>().vida == 1)
           {
                lista.listaDeBlocos.DesalistarConteudo(other.GetComponent<Bloco2>().myBloco);
                lista.listaDeBlocos.QuantosBlocos();
                GameController.singleton.audios.transform.GetChild(2).GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
           }
           else if(other.GetComponent<Bloco2>().vida >1)
           {
                other.GetComponent<Bloco2>().vida -= 1;
           }
        }
    }
}
