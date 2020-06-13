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