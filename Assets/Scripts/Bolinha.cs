using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other == GameController.singleton.colisorPlataforma)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameController.singleton.bolasPegas += 1;
            GameController.singleton.nBolasGame -= 1;
            Destroy(this.gameObject);
        }
    }
}
