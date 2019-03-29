using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeBlocos
{
    public ElementoBloco primeiro, ultimo;
    public int nDaLista;

    public ListaDeBlocos(int numeroDaLista)
    {
        nDaLista = numeroDaLista;
        ElementoBloco aux = new ElementoBloco(null);
        primeiro = aux;
        ultimo = aux;
    }

    public void Alistar(Bloco novoBloco)
    {
        ElementoBloco novoElemento = new ElementoBloco(novoBloco);
        ultimo.proximo = novoElemento;
        ultimo = novoElemento;
    }

    //public Bloco Desalistar()
    //{
    //    ElementoBloco auxRetorno = primeiro.proximo;
    //    if (vazio())
    //    {
    //        return null;
    //    }
    //    else
    //    {

    //    }
    //}

    public bool vazio()
    {
        if (ultimo == primeiro)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
