using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaDeBolinhas
{
    public ElementoBola primeiro, ultimo;

    public FilaDeBolinhas()
    {
        ElementoBola aux = new ElementoBola(null);
        primeiro = aux;
        ultimo = aux;
    }

    public void Enfileira(Bola novaBola)
    {
        ElementoBola novoElemento = new ElementoBola(novaBola);
        ultimo.proximo = novoElemento;
        ultimo = novoElemento;
    }

    public Bola Desenfileira()
    {
        ElementoBola auxRetorno = primeiro.proximo;
        if (vazio())
        {
            return null;
        }
        else
        {
            primeiro.proximo = auxRetorno.proximo;
            auxRetorno.proximo = null;
            if(auxRetorno == ultimo)
            {
                ultimo = primeiro;
            }
            return auxRetorno.minhaBola;
        }
    }

    public bool vazio()
    {
        if(ultimo == primeiro)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
