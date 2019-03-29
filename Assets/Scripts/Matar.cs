using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameController.singleton.nBolasGame -= 1;
    }
}
