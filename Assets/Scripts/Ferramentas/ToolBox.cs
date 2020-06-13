using UnityEngine;
public class ToolBox
{
    static ToolBox instance;

    ControladorBolinhas ctrlBolinhas;
    ControladorHUD ctrlHUD;
    ControladorJogo ctrlJogo;
    ControladorListaDeBlocos ctrlListaDeBlocos;
    ControladorPlataforma ctrlPlataforma;
    ControladorPontuacao ctrlPontuacao;

    ToolBox()
    {
        ctrlBolinhas = Object.FindObjectOfType<ControladorBolinhas>();
        ctrlHUD = Object.FindObjectOfType<ControladorHUD>();
        ctrlJogo = Object.FindObjectOfType<ControladorJogo>();
        ctrlListaDeBlocos = Object.FindObjectOfType<ControladorListaDeBlocos>();
        ctrlPlataforma = Object.FindObjectOfType<ControladorPlataforma>();
        ctrlPontuacao = new ControladorPontuacao();
    }

    public static ToolBox GetInstance()
    {
        if (instance == null)
        {
            instance = new ToolBox();
        }
        return instance;
    }
    public ControladorBolinhas GetCtrlBolinhas() { return ctrlBolinhas; }
    public ControladorHUD GetCtrlHUD() { return ctrlHUD; }
    public ControladorJogo GetCtrlJogo() { return ctrlJogo; }
    public ControladorListaDeBlocos GetCtrlListaDeBlocos() { return ctrlListaDeBlocos; }
    public ControladorPlataforma GetCtrlPlataforma() { return ctrlPlataforma; }
    public ControladorPontuacao GetCtrlPontuacao() { return ctrlPontuacao; }
}