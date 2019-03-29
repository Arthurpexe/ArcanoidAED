using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancaBola : MonoBehaviour
{
    public Rigidbody rb;
    public int velocidade;
    public CapsuleCollider colisorPlataforma;
    public bool grudado;

    //inicio o vetor com 10 posições
    int[] vetor = new int[10];
    //variável inteira onde ficará
    //o valor gerado pelo random
    int aux = 0;
    //instância do random
    Random rnd = new Random();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// precionando espaço, lança a bola em um angulo aleatório
    /// </summary>
    void Update()
    {
      /*  if (rb.velocity = 0)
        {*/


            if (Input.GetKeyDown(KeyCode.Space) && grudado)
            {
                int numero = Random.Range(0, 500);
                velocidade = Random.Range(0, 500);
                rb.AddForce(numero, velocidade, 0, ForceMode.Acceleration);
            }
       /// }
    }

    /// <summary>
    /// Colisor da plataforma
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(CapsuleCollider other)
    {
        grudado = false;
        if (other.tag.Equals("Player"))
            grudado = true;
        if (other = colisorPlataforma)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
