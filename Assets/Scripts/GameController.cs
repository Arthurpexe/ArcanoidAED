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
    public GameObject gameOverCanvas, menuCanvas, ortoCam, treeDCam;
    public Text numeroDeBolas;
    public float cooldown, tempocooldown;
    public Image cooldownIcon;
    public AudioSource semBola;

    private Vector3 aceleracao;
    private Vector3 bolaPos;
    private Bola bolaX;
    private Quaternion quaternionZero = new Quaternion(0, 0, 0, 0);


    public GameObject audios;


    public Bola CriaBola()
    {
        Bola novaBola = new Bola();
        nBolasFilaTotal += 1;
        nBolasFilaAtual += 1;
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
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gameOverCanvas.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    if(Time.timeScale == 1)
        //    {
        //        Time.timeScale = 0;
        //        menuCanvas.SetActive(true);
        //    }
        //    if(menuCanvas.activeInHierarchy)
        //    {
        //        Time.timeScale = 1;
        //        menuCanvas.SetActive(false);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space) && cooldown >= 1)
        {
             bolaX = filaDeBolas.Desenfileira();
            if (bolaX != null)
            {
                aceleracao.x = Random.Range(-400, 400);
                aceleracao.y = 400;
                bolaPos = this.transform.position;
                Instantiate(bolaX.bola, bolaPos, quaternionZero).GetComponent<Rigidbody>().AddForce(aceleracao, ForceMode.Acceleration);
                nBolasGame += 1;
                nBolasFilaAtual -= 1;
                cooldown -= 1;
            }
            else
            {
                semBola.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            filaDeBolas.Enfileira(CriaBola());
        }

        if (Input.GetKeyDown(KeyCode.F))
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (cooldown < 1)
        {
            cooldown += tempocooldown;
            cooldownIcon.fillAmount = cooldown;
        }
    }
}
