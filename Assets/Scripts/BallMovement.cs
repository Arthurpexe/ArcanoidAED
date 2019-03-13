using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float velocidade;
    public Rigidbody rb;
    public GameObject bola;
    public Vector3 bolaPos;
    private Quaternion bolaQua = new Quaternion(0,0,0,0);

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(velocidade, velocidade, 0, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(bola, bolaPos,bolaQua);
            
        }
    }

}
