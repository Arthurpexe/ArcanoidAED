using System.Collections.Generic;
using UnityEngine;

public class ControladorBolinhas : MonoBehaviour, ISujeito<ControladorBolinhas>, IObservador<Bolinha>, IObservador<ControladorPlataforma>
{
    public GameObject bolaFixa;
    public Bolinha bola;
    FilaDeBolinhas filaDeBolas = new FilaDeBolinhas();
    public int nBolasFilaTotal = 0, nBolasFilaAtual = 0, nBolasGame = 0;
    float cooldown;
    float cooldownMax = 1;

    public float velocidadeInicial = 500;
    Vector3 direcaoTiro;
    const float fatorMult = 1.5f;

    public AudioSource semBola;//audio manager
    public GameObject audios;//

    List<IObservador<ControladorBolinhas>> observadores;

    public Bolinha CriaBola()
    {
        nBolasFilaTotal++;
        nBolasFilaAtual++;
        notificarObservadores();
        return Instantiate(bola);
    }
    public void adicionarBolinha()
    {
        filaDeBolas.Enfileira(CriaBola());
    }

    public void iniciarJogo()
    {
        cooldown = cooldownMax;
        adicionarBolinha();
        adicionarBolinha();
        adicionarBolinha();
    }
    public void atiraBola()
    {
        if (bolaFixa.activeSelf)
        {
            Bolinha bolaux = filaDeBolas.Desenfileira();
            if (bolaux != null)
            {
                bolaux.transform.position = this.transform.position;//set position
                bolaux.gameObject.SetActive(true);

                bolaux.GetComponent<Rigidbody>().AddForce(direcaoTiro, ForceMode.Acceleration);//Shoot it

                nBolasGame++;
                nBolasFilaAtual--;
                cooldown -= cooldownMax;
            }
            else
            {
                semBola.Play();//controlador de audio
            }
        }

        direcaoTiro.y = velocidadeInicial;
    }

    public void mudarAngulo(float angulo)
    {
        angulo = ((angulo * 2) * direcaoTiro.y * Time.deltaTime) + direcaoTiro.x;
        direcaoTiro.x = Mathf.Clamp(angulo, -direcaoTiro.y, direcaoTiro.y);//lgc

        bolaFixa.transform.localEulerAngles = new Vector3(0, 0, (-direcaoTiro.x / direcaoTiro.y) * 45);//gfx
    }
    public void mudarAceleracao(float aceleracao)
    {
        aceleracao = ((aceleracao / 2) * direcaoTiro.y * Time.deltaTime) + direcaoTiro.y;
        direcaoTiro.y = Mathf.Clamp(aceleracao, velocidadeInicial, velocidadeInicial * fatorMult);
        notificarObservadores();
    }

    void Start()
    {
        inscreverObservador(ToolBox.GetInstance().GetCtrlHUD());
        inscreverObservador(ToolBox.GetInstance().GetCtrlJogo());

        cooldown = cooldownMax;
        direcaoTiro = new Vector3(0, velocidadeInicial, 0);
    }
    void Update()
    {
        if (nBolasFilaAtual == 0 || cooldown < cooldownMax)
        {
            bolaFixa.SetActive(false);
        }
        else
        {
            bolaFixa.SetActive(true);
        }

        if (cooldown < cooldownMax)
        {
            cooldown += Time.deltaTime;

            notificarObservadores();
        }
    }


    public void inscreverObservador(IObservador<ControladorBolinhas> obs)
    {
        if (observadores == null)
            observadores = new List<IObservador<ControladorBolinhas>>();

        observadores.Add(obs);
    }
    public void desinscreverObservador(IObservador<ControladorBolinhas> obs)
    {
        observadores.Remove(obs);
    }
    public void notificarObservadores()
    {
        foreach (IObservador<ControladorBolinhas> obs in observadores)
        {
            obs.atualizar(this);
        }
    }


    public void atualizar(Bolinha dado)
    {
        nBolasGame--;
        notificarObservadores();
    }


    public void atualizar(ControladorPlataforma dado)
    {
        nBolasFilaTotal--;
    }


    public float GetCooldownMax() { return cooldownMax; }
    public float GetCooldown() { return cooldown; }
    public int GetNBolasFilaAtual() { return nBolasFilaAtual; }
    public int GetNBolasFilaTotal() { return nBolasFilaTotal; }
    public int GetNBolasGame() { return nBolasGame; }
    public Vector3 GetDirecaoTiro() { return direcaoTiro; }
    public float GetFatorMult() { return fatorMult; }
}