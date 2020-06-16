using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorHUD : MonoBehaviour, ISujeito<ControladorHUD>, IObservador<ControladorBolinhas>
{
    public GameObject menuCanvas, gameOverCanvas;
    public Text numeroDeBolas;
    public Image cooldownIcon;
    public Text pontuacao;
    public Image barraAceleracaoBola;

    List<IObservador<ControladorHUD>> observadores;

    public void abrirPainelMenu()
    {
        abrirPainel(menuCanvas);
    }
    public void abrirPainelGameOver()
    {
        abrirPainel(gameOverCanvas);
    }
    void abrirPainel(GameObject painel)
    {
        painel.SetActive(!painel.activeSelf);

        notificarObservadores();
    }


    public void inscreverObservador(IObservador<ControladorHUD> obs)
    {
        if(observadores == null)
            observadores = new List<IObservador<ControladorHUD>>();
        else
            observadores.Add(obs);
    }

    public void desinscreverObservador(IObservador<ControladorHUD> obs)
    {
        observadores.Remove(obs);
    }

    public void notificarObservadores()
    {
        foreach(IObservador<ControladorHUD> obs in observadores)
        {
            obs.atualizar(this);
        }
    }


    public void atualizar(ControladorBolinhas dado)
    {
        numeroDeBolas.text = dado.GetNBolasFilaAtual().ToString();
        cooldownIcon.fillAmount = dado.GetCooldown() / dado.GetCooldownMax();
        barraAceleracaoBola.fillAmount = (dado.GetDirecaoTiro().y - dado.velocidadeInicial) / dado.velocidadeInicial * 2;
    }


    public void atualizar(ControladorPontuacao dado)
    {
        pontuacao.text = dado.GetPontuacao().ToString();
    }
}