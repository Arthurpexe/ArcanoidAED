﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverplataforma : MonoBehaviour
{
    public Collider paredeD, paredeE;

    private Rigidbody rbPlataforma;

    void Start()
    {
        rbPlataforma = this.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// mexe a plataforma e deixa o limite de ate onde ela pode ir
    /// </summary>
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * -0.3f;

        transform.Translate(0, x, 0);

        float PosArcanoid = this.transform.position.x;

        Mexer(PosArcanoid);

    }

    /// <summary>
    /// encontra os limites da tela para não deixar o jogador passar delas
    /// </summary>
    /// <param name="PosArcanoid">Recebendo a posição do Arcanoid</param>
    void Mexer(float PosArcanoid)
    {
        float min = -2.4f;
        float max = 2.4f;

        Vector3 pos = transform.position;

        pos.x += PosArcanoid * Time.deltaTime * 0;

        pos.x = Mathf.Clamp(pos.x, min, max);

        transform.position = pos;

    }

}
