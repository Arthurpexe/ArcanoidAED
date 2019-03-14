using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float velocidade, delay = 0;
    public Rigidbody rb;
    public GameObject bola;
    public Vector3 bolaPos, velBol;
    public BoxCollider colisorPlataforma;

    private Quaternion bolaQua = new Quaternion(0,0,0,0);
    private Vector3 bolaParada = new Vector3(0, 0, 0);
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velBol = rb.velocity;
        if(velBol == bolaParada)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                  //rb.isKinematic = false;
                rb.AddForce(velocidade, velocidade, 0, ForceMode.Acceleration);          
                //rb.detectCollisions = true;
              
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(bola, bolaPos,bolaQua);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //rb.isKinematic = true;
        //rb.detectCollisions = false;
        rb.velocity = Vector3.zero;


    }
    private void OnTriggerExit(Collider other)
    {
        //colisorPlataforma.enabled = true;


    }
}
