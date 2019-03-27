using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverplataforma : MonoBehaviour {

    public float velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;

        transform.Translate(x, 0, 0);

        var PosArcanoid = transform.position;

        Mexer(PosArcanoid);

    }

    void Mexer(Vector2 PosArcanoid)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        Vector2 pos = transform.position;

        pos += PosArcanoid * velocidade * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        transform.position = pos;
    }

}
