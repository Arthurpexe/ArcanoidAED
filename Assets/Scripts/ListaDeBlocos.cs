using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeBlocos
{
    public ElementoBloco primeiro, ultimo;
    public float nDaLista;

    public ListaDeBlocos(float numeroDaLista)
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

    public Bloco Desalistar(int tipoDoBloco)
    {
        ElementoBloco aux = primeiro;
        if (vazio())
        {
            return null;
        }
        else
        {
            for(int i = 0; i < 6; i++)
            {
                if (aux.proximo.meuBloco.tipoDoBloco == tipoDoBloco)
                {
                    ElementoBloco auxRetorno = aux.proximo;
                    if (auxRetorno == ultimo)
                    {
                        aux = ultimo;
                        aux.proximo = null;
                        return auxRetorno.meuBloco;
                    }
                    else
                    {
                        aux.proximo = auxRetorno.proximo;
                        auxRetorno.proximo = null;
                        return auxRetorno.meuBloco;
                    }
                }
                else
                {
                    aux = aux.proximo;
                }
            }
            return null;
        }
    }

    public bool vazio()
    {
        ElementoBloco aux = primeiro.proximo;
        if (aux.proximo == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int QuantosBlocos()
    {
        ElementoBloco aux = primeiro;
        int quantidade = 0;
        while(aux.proximo != null)
        {
            aux = aux.proximo;
            quantidade += 1;
        }
         return quantidade;
    }
}
