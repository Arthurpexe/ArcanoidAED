using UnityEngine;

public class ListaDeBlocos
{
    public ElementoBloco primeiro, ultimo;

    public ListaDeBlocos()
    {
        ElementoBloco aux = new ElementoBloco(null);
        primeiro = ultimo = aux;
    }

    public void Alistar(Bloco novoBloco)
    {
        ElementoBloco novoElemento = new ElementoBloco(novoBloco);
        ultimo.proximo = novoElemento;
        ultimo = novoElemento;
    }

    public Bloco DesalistarConteudo(int pos)
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
            while (aux.proximo.meuBloco.myID().y != pos)
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
                return auxRetorno.meuBloco;
            }
        }
    }

    public Bloco procurarConteudo(int pos)
    {
        ElementoBloco aux = primeiro;

        if (last())
        {
            Debug.Log("esse é o ultimo bloco");
            return aux.proximo.meuBloco;
        }
        else
        {
            while (aux.proximo.meuBloco.myID().y != pos)
            {
                aux = aux.proximo;
            }

            if (aux.proximo == null)
            {
                Debug.Log("não achei nada");
                return null;
            }
            else
            {
                return aux.proximo.meuBloco;
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

    public int tamanhoLista()
    {
        ElementoBloco aux = primeiro;
        int cont = 0;
        while(aux.proximo != null)
        {
            aux = aux.proximo;
            cont++;
        }
        return cont;
    }

    public Bloco[] imprimir()
    {
        ElementoBloco aux = primeiro;
        Bloco[] auxRet = new Bloco[tamanhoLista()];
        for(int i = 0; i < auxRet.Length; i++)
        {
            aux = aux.proximo;
            auxRet[i] = aux.meuBloco;
        }
        return auxRet;
    }
}