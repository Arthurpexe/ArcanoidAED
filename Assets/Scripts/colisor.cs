using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisor : MonoBehaviour {

    /// <summary>
    /// Colisor para destruir a bola
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
