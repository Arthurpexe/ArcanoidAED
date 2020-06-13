using System.Collections.Generic;
using UnityEngine;

public class ControladorPlataforma : MonoBehaviour, ISujeito<ControladorPlataforma>
{
    public float slow;

    public GameObject bolaFixa;

    List<IObservador<ControladorPlataforma>> observadores;

    private void Start()
    {
        observadores = new List<IObservador<ControladorPlataforma>>();
        inscreverObservador(ToolBox.GetInstance().GetCtrlBolinhas());
        inscreverObservador(ToolBox.GetInstance().GetCtrlPontuacao());
    }

    /// <summary>
    /// Move a plataforma e encontra os limites da tela para não deixar o jogador passar delas
    /// </summary>
    /// <param name="input">O input de qual direção a plataforma vai se mexer</param>
    public void Mexer(float input)
    {
        transform.Translate(0, input * slow, 0);

        float min = -2.4f;
        float max = 2.4f;

        Vector3 pos = transform.position;

        pos.x += pos.x * Time.timeScale * 0;

        pos.x = Mathf.Clamp(pos.x, min, max);

        transform.position = pos;
    }

    public void pegarBolinha()
    {
        ToolBox.GetInstance().GetCtrlBolinhas().adicionarBolinha();
        notificarObservadores();
    }


    public void inscreverObservador(IObservador<ControladorPlataforma> obs)
    {
        observadores.Add(obs);
    }

    public void desinscreverObservador(IObservador<ControladorPlataforma> obs)
    {
        observadores.Add(obs);
    }

    public void notificarObservadores()
    {
        foreach(IObservador<ControladorPlataforma> obs in observadores)
        {
            obs.atualizar(this);
        }
    }
}