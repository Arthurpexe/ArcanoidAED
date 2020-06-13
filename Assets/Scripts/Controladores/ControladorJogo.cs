using UnityEngine;

public class ControladorJogo : MonoBehaviour, IObservador<ControladorBolinhas>, IObservador<ControladorHUD>
{
    public GameObject ortoCam, treeDCam;
    ControladorHUD ctrlHUD;

    bool jogoIniciado;

    public void iniciarJogo()//botao
    {
        ToolBox.GetInstance().GetCtrlPontuacao().zerarPontuacao();
        ToolBox.GetInstance().GetCtrlBolinhas().iniciarJogo();
        jogoIniciado = true;
    }
    public void gameOver()//botao
    {
        ctrlHUD.abrirPainelGameOver();
        jogoIniciado = false;
    }
    public void Desistir()//botao
    {
        Application.Quit();
    }
    public void pausar()
    {
        ctrlHUD.abrirPainelMenu();
    }
    public void trocarCamera()
    {
        ortoCam.SetActive(!ortoCam.activeSelf);
        treeDCam.SetActive(!treeDCam.activeSelf);
    }
    bool pararTempo(bool t)
    {
        if (t)
            Time.timeScale = 0.01f;
        else
            Time.timeScale = 1;
        return t;
    }


    private void Start()
    {
        ctrlHUD = ToolBox.GetInstance().GetCtrlHUD();
        //caregar ultima pontuação mais alta
    }


    public void atualizar(ControladorBolinhas dado)
    {
        if (dado.GetNBolasFilaAtual() == 0 && dado.GetNBolasGame() == 0 && jogoIniciado)
        {
            gameOver();
        }
    }


    public void atualizar(ControladorHUD dado)
    {
        if (!pararTempo(dado.gameOverCanvas.activeSelf))
            pararTempo(dado.menuCanvas.activeSelf);
    }
}