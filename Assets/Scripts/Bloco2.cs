using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco2 : MonoBehaviour
{
    public int vida = 2;

    private void Update()
    {
        if (vida == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        vida -= 1;
    }
}
