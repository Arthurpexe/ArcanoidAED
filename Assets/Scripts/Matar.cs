using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matar : MonoBehaviour
{
    public AudioSource bolaMorte;
    private void OnTriggerEnter(Collider other)
    {
        bolaMorte.Play();
        Destroy(other.gameObject);
        GameController.singleton.nBolasGame -= 1;
    }
}
