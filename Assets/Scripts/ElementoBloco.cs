using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoBloco
{
    public ElementoBloco proximo;
    public Bloco meuBloco;

    public ElementoBloco(Bloco novoBloco)
    {
        meuBloco = novoBloco;
        proximo = null;
    }
}
