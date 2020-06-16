[System.Serializable]
public class BlocoIndestrutivel : Bloco
{
    public BlocoIndestrutivel(int hp, int linha, int coluna) : base(hp, linha, coluna)
    {
        id.z = 0;
    }

    public override bool tomarDano()
    {
        ToolBox.GetInstance().GetCtrlBolinhas().adicionarBolinha();

        if (ToolBox.GetInstance().GetCtrlListaDeBlocos().GetListaDeBlocos((int)id.x).tamanhoLista() == 1)
            return base.tomarDano();

        return false;
    }
}