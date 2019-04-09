using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListaDeBlocos
{
    public ElementoBloco primeiro, ultimo;
    public float nDaLista;
    public int quantidadeBlocos;

    public ListaDeBlocos(float numeroDaLista)
    {
        nDaLista = numeroDaLista;
        ElementoBloco aux = new ElementoBloco(null);
        primeiro = ultimo = aux;
    }

    public void Alistar(Bloco novoBloco)
    {
        ElementoBloco novoElemento = new ElementoBloco(novoBloco);
        ultimo.proximo = novoElemento;
        ultimo = novoElemento;
        
    }

    public Bloco DesalistarConteudo(Bloco bloco)
    {
        ElementoBloco aux = primeiro;
        ElementoBloco auxRetorno;

        if (last())
        {
            auxRetorno = aux.proximo;
            ultimo = aux;
            aux.proximo = null;
            Debug.Log("desalistei o ultimo bloco");
            return auxRetorno.meuBloco;
        }
        else
        {
            while (aux.proximo != null && aux.proximo.meuBloco.Equals(bloco))
            {
                aux = aux.proximo;
            }

            if (aux.proximo == null)
            {
                Debug.Log("desalistei nada");
                return null;
            }
            else
            {
                auxRetorno = aux.proximo;
                aux.proximo = auxRetorno.proximo;
                auxRetorno.proximo = null;
                Debug.Log("desalistei o bloco");
                return auxRetorno.meuBloco;
            }
        }
    }

    public bool last()
    {
        ElementoBloco aux = primeiro;
        if (aux.proximo == ultimo)
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

        while(aux != null)
        {
            aux = aux.proximo;
            quantidade += 1;
        }
        quantidadeBlocos = quantidade;
    }
}
