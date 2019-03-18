using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float velocidade;
    private Rigidbody rb;
    public GameObject bola;
    public Vector3 bolaPos;
    public Collider colisorPlataforma;

    private Quaternion bolaQua = new Quaternion(0,0,0,0);
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.velocity == Vector3.zero)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(velocidade, velocidade, 0, ForceMode.Acceleration);
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(bola, bolaPos,bolaQua);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other = colisorPlataforma)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
