using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour, ISujeito<Bolinha>
{
    List<IObservador<Bolinha>> observadores;

    private void Start()
    {
        observadores = new List<IObservador<Bolinha>>();
        inscreverObservador(ToolBox.GetInstance().GetCtrlBolinhas());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("plataforma"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<ControladorPlataforma>().pegarBolinha();
            notificarObservadores();
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("bloco"))
        {
            ToolBox.GetInstance().GetCtrlListaDeBlocos().colidirBloco(other.gameObject);
            //GameController.singleton.audios.transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
        else if (other.CompareTag("chao"))
        {
            notificarObservadores();
            Destroy(this.gameObject);
        }
    }


    public void inscreverObservador(IObservador<Bolinha> obs)
    {
        observadores.Add(obs);
    }
    public void desinscreverObservador(IObservador<Bolinha> obs)
    {
        observadores.Remove(obs);
    }
    public void notificarObservadores()
    {
        foreach(IObservador<Bolinha> obs in observadores)
        {
            obs.atualizar(this);
        }
    }
}