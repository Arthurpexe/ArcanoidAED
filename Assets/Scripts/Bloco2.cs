﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco2 : MonoBehaviour
{
    public int vida;
    public Material materialBloco;
    public Bloco myBloco;

    private void Update()
    {
        if(vida <2)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
