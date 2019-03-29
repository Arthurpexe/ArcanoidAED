using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController singleton;
    public GameObject bolinha, plataforma, bolaFixa;
    public FilaDeBolinhas filaDeBolas = new FilaDeBolinhas();
    public Collider colisorMorte, colisorPlataforma;
    public int nBolasFilaTotal = 0, nBolasFilaAtual = 0, nBolasGame = 0, bolasPegas = 0;
    public Vector3 aceleracao;
    public GameObject GameOverCanvas, ortoCam, treeDCam;
    public Text numeroDeBolas;

    private Vector3 bolaPos;
    private Bola bolaX;
    private Quaternion quaternionZero = new Quaternion(0, 0, 0, 0);
    private Transform instanciadorDeBolinhas;


    public Bola CriaBola()
    {
        Bola novaBola = new Bola();
        nBolasFilaTotal += 1;
        nBolasFilaAtual += 1;
        novaBola.bola = bolinha;
        novaBola.rbBola = bolinha.GetComponent<Rigidbody>();
        return novaBola;
    }

    public ListaDeBlocos CriaLista(int nDaLista)
    {
        ListaDeBlocos novaListaDBlocos = new ListaDeBlocos(nDaLista);
        //como fazer elas spawnarem em linhas verticais diferentes e verificar se a linha esta vazia ou não. talvez criando uma lista pra cada linha vertical, caso ela esteja vazia cria os 6 blocos.
        int posicaoAleatoria = Random.Range(1, 6);
        
        for(int i = 0; i < 6; i++)
        {
            if(i == posicaoAleatoria)
            {
                Bloco novoBloco = new Bloco();
                GameObject novoBlocoObj = novoBloco.TipoDoBloco(0);
                float x = 0;
                Vector3 bPos = new Vector3(x, 0, 0);

                switch (posicaoAleatoria)
                {
                    case 1:
                        x = -2.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 2:
                        x = -1.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 3:
                        x = -0.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 4:
                        x = 0.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 5:
                        x = 1.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 6:
                        x = 2.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                }

                novaListaDBlocos.Alistar(novoBloco);
            }
            else
            {
                int blocoAleatorio = Random.Range(1, 2);
                Bloco novoBloco = new Bloco();
                GameObject novoBlocoObj = novoBloco.TipoDoBloco(blocoAleatorio);
                float x = 0;
                Vector3 bPos = new Vector3(x, 0, 0);

                switch (posicaoAleatoria)
                {
                    case 1:
                        x = -2.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 2:
                        x = -1.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 3:
                        x = -0.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 4:
                        x = 0.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 5:
                        x = 1.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                    case 6:
                        x = 2.5f;
                        Instantiate<GameObject>(novoBlocoObj, bPos, quaternionZero);
                        break;
                }

                novaListaDBlocos.Alistar(novoBloco);
            }
        }
        
        return novaListaDBlocos;
    }

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        instanciadorDeBolinhas = this.GetComponentInChildren<Transform>();
        filaDeBolas.Enfileira(CriaBola());
        colisorPlataforma = plataforma.GetComponent<Collider>();
    }

    void Update()
    {
        numeroDeBolas.text = nBolasFilaAtual.ToString();

        if (bolasPegas > 0)
        {
            filaDeBolas.Enfileira(CriaBola());
            bolasPegas -= 1;
        }

        if (nBolasFilaAtual == 0)
        {
            bolaFixa.SetActive(false);
        }
        else
        {
            bolaFixa.SetActive(true);
        }

        if (nBolasGame == 0 && nBolasFilaAtual == 0)
        {
            Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            GameOverCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
             bolaX = filaDeBolas.Desenfileira();
            if (bolaX != null)
            {
                bolaPos = this.transform.position;
                Instantiate(bolaX.bola, bolaPos, quaternionZero, instanciadorDeBolinhas).GetComponent<Rigidbody>().AddForce(aceleracao, ForceMode.Acceleration);
                nBolasGame += 1;
                nBolasFilaAtual -= 1;
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
            if (ortoCam.activeSelf == true)
            {
                treeDCam.SetActive(true);
                ortoCam.SetActive(false);
            }
            else
            {
                treeDCam.SetActive(false);
                ortoCam.SetActive(true);
            }
        }
    }
}
