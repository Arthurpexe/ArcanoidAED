using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinhas : MonoBehaviour
{
    public struct bolinha
    {
        public Rigidbody brb;
        public GameObject bgo;
        public int numDaBola;
    }

    void Start()
    {
        bolinha bolinha;
        bolinha.brb = GetComponent<Rigidbody>();
        bolinha.bgo = this.gameObject;
        
    }

    void Update()
    {
        
    }
}
