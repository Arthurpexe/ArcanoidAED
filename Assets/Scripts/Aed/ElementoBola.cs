public class ElementoBola
{
    public ElementoBola proximo;
    public Bolinha minhaBola;

    public ElementoBola(Bolinha novaBola)
    {
        minhaBola = novaBola;
        proximo = null;
    }
}