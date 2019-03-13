using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel
{
    public Vector2 pos;
    public int tipo;//blocos simples,duros,indestrutiveis
    public int cont;//qts bolas
}

public class Elemento
{
    public Pixel pixel;
    public Elemento proximo;
    public Elemento(Pixel p)
    {
        this.pixel = p;
        this.proximo = null;
    }
}

public class Fila
{
    public Elemento pimeiro, ultimo;
}
