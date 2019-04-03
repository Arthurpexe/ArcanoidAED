using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
