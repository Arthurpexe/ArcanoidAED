using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject,1);
        //Diminuir a pontuação de NBolaGame em 1
    }
}
