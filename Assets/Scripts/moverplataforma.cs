using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverplataforma : MonoBehaviour
{
    public float velocidade;


    void Start()
    {

    }

    /// <summary>
    /// mexe a plataforma e deixa o limite de ate onde ela pode ir
    /// </summary>
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * -10.0f;

        transform.Translate(0, x, 0);

        var PosArcanoid = transform.position;

        Mexer(PosArcanoid);

    }

    /// <summary>
    /// encontra os limites da tela para não deixar o jogador passar delas
    /// </summary>
    /// <param name="PosArcanoid"></param>
    void Mexer(Vector2 PosArcanoid)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.600f;
        min.x = min.x + 0.600f;

        Vector2 pos = transform.position;

        pos += PosArcanoid * velocidade * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        transform.position = pos;
    }
}
