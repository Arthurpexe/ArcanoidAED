using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco
{
    public GameObject blocoI, bloco1, bloco2;

    public Bloco()
    {
    }

    public GameObject TipoDoBloco(int tipoDoBloco)
    {
        switch (tipoDoBloco)
        {
            case 0:
                return blocoI;
            case 1:
                return bloco1;
            case 2:
                return bloco2;
            default:
                return null;
        }
    }
}
