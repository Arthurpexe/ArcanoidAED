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
        int posBloco = LocalizaBloco(tipoDoBloco);

        for(int i = 0; i <= posBloco - 1; i++)
        {
            aux = aux.proximo;
        }

        ElementoBloco auxRetorno = aux.proximo; 

        if (auxRetorno == ultimo)
        {
            aux.proximo = null;
            aux = ultimo;
            return auxRetorno.meuBloco;
        }
        else
        {
            aux.proximo = auxRetorno.proximo;
            return auxRetorno.meuBloco;
        }
    }

    public int LocalizaBloco(int tipoDoBloco)
    {
        ElementoBloco aux = primeiro;
        int i;

        for(i = 0; i <= 6 && aux.meuBloco.tipoDoBloco != tipoDoBloco; i++)
        {
            aux = aux.proximo;
        }

        return i;
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
