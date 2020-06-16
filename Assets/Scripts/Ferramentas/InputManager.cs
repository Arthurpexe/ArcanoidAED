using UnityEngine;

public class InputManager : MonoBehaviour, IObservador<ControladorHUD>
{
    ControladorBolinhas ctrlBolinhas;
    ControladorJogo ctrlJogo;
    bool interromperInputs;

    private void Start()
    {
        ctrlBolinhas = ToolBox.GetInstance().GetCtrlBolinhas();
        ctrlJogo = ToolBox.GetInstance().GetCtrlJogo();
        ToolBox.GetInstance().GetCtrlHUD().inscreverObservador(this);
    }
    private void LateUpdate()
    {
        lerInput();
    }

    void lerInput()
    {
        if (!interromperInputs)
        {
            //plataforma
            ToolBox.GetInstance().GetCtrlPlataforma().Mexer(Input.GetAxis("Horizontal"));

            //Bolinhas
            if (Input.GetMouseButton(0))
            {
                ctrlBolinhas.mudarAngulo(-1);
            }
            if (Input.GetMouseButton(1))
            {
                ctrlBolinhas.mudarAngulo(1);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                ctrlBolinhas.mudarAceleracao(1);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
            {
                ctrlBolinhas.atiraBola();
            }

            //menu
            if (Input.GetKeyDown(KeyCode.P))
            {
                ctrlJogo.pausar();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ctrlJogo.trocarCamera();
            }
        }

        //hacks
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToolBox.GetInstance().GetCtrlListaDeBlocos().criarListaBlocos();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ctrlBolinhas.adicionarBolinha();
        }

        //quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ctrlJogo.Desistir();
        }

        if (Input.GetKeyDown(KeyCode.F1)){
            ctrlJogo.iniciarJogo();
        }
    }


    public void atualizar(ControladorHUD dado)
    {
        interromperInputs = dado.gameOverCanvas.activeSelf;
    }
}