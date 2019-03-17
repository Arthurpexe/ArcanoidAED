using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * -150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * -150.0f;

        transform.Translate(0, 0, z);
        transform.Translate(x, 0, 0);

    }
}
