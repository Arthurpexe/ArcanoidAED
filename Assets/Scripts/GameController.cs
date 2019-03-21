using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController singleton;
    public GameObject bolinha;
    public GameObject plataforma;
    public FilaDeBolinhas filaDeBolas = new FilaDeBolinhas();
    public Collider colisorPlataforma, colisorMorte;
    public int NBolasFilaTotal, NBolasFilaAtual,NBolasGame;
    public Vector3 aceleracao;
    public GameObject OrtoCam;
    public GameObject TDCam;

    private Vector3 bolaPos;
    private Bola bolaX;
    private Quaternion quaternionZero = new Quaternion(0, 0, 0, 0);
    private Transform instanciadorDeBolinhas;


    public Bola CriaBola()
    {
        Bola novaBola = new Bola(NBolasFilaTotal += 1);
        NBolasFilaAtual += 1;
        novaBola.bola = bolinha;
        novaBola.rbBola = bolinha.GetComponent<Rigidbody>();
        return novaBola;
    }

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        instanciadorDeBolinhas = this.GetComponentInChildren<Transform>();
        filaDeBolas.Enfileira(CriaBola());
    }

    void Update()
    {
        
        //if(instanciadorDeBolinhas.childCount == 0)
        //{
        //    //Game Over
        //}

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
             bolaX = filaDeBolas.Desenfileira();
            if (bolaX != null)
            {
                bolaPos = this.transform.position;
                Instantiate(bolaX.bola, bolaPos, quaternionZero, instanciadorDeBolinhas).GetComponent<Rigidbody>().AddForce(aceleracao, ForceMode.Acceleration);
                NBolasGame += 1;
                NBolasFilaAtual -= 1;
            }
            else
            {
                /*toca um som de erro*/
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            filaDeBolas.Enfileira(CriaBola());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OrtoCam.activeSelf == true)
            {
                TDCam.SetActive(true);
                OrtoCam.SetActive(false);
            }
            else
            {
                TDCam.SetActive(false);
                OrtoCam.SetActive(true);
            }
        }
    }
}
