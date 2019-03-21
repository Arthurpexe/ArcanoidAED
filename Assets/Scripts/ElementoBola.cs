using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoBola
{
    public ElementoBola proximo;
    public Bola minhaBola;

    public ElementoBola(Bola novaBola)
    {
        minhaBola = novaBola;
        proximo = null;
    }
}
