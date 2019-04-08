using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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


    public Bloco DesalistarConteudo(Bloco bloco)
    {
        ElementoBloco aux = primeiro.proximo;
        while (aux.proximo != null && aux.proximo.meuBloco.Equals(bloco))
        {
            aux = aux.proximo;
        }

        if(aux.proximo == null)
        {
            return null;
        }
        else
        {
            ElementoBloco auxRetorno = aux.proximo;
            aux.proximo = auxRetorno.proximo;
            if (auxRetorno == ultimo)
                ultimo = aux;
            else
                auxRetorno.proximo = null;

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
    public void QuantosBlocos()
    {
        ElementoBloco aux = primeiro.proximo;
        int quantidade = 0;
        while(aux.proximo != null)
        {
            aux = aux.proximo;
            quantidade += 1;
        }
        Debug.Log(quantidade);
    }
}
