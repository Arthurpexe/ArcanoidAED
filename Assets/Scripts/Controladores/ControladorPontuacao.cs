public class ControladorPontuacao : IObservador<ControladorPlataforma>
{
    int pontuacao;

    public void pontuar(int pontos)
    {
        pontuacao += pontos;
        ToolBox.GetInstance().GetCtrlHUD().atualizar(this);//gambiarra
        //notificarObservadores();
    }
    public void zerarPontuacao()
    {
        pontuacao = 0;
        ToolBox.GetInstance().GetCtrlHUD().atualizar(this);//gambiarra
    }


    public void atualizar(ControladorPlataforma dado)
    {
        pontuar(8);
    }


    public int GetPontuacao() { return pontuacao; }
}