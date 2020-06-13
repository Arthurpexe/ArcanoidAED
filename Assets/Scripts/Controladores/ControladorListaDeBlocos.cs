using UnityEngine;

public class ControladorListaDeBlocos : MonoBehaviour
{
    public GameObject bloco;
    public Material materialBlocoBase;
    Transform[] linhas;
    ListaDeBlocos[] listas;
    public int hpMaxBlocosComuns;
    int nListas;

    ControladorPontuacao ctrlPontuacao;

    static Quaternion quaternion90 = new Quaternion(0, 0, 7071068, 7071068);

    private void Start()
    {
        ctrlPontuacao = ToolBox.GetInstance().GetCtrlPontuacao();
        nListas = transform.childCount;
        linhas = new Transform[nListas];
        listas = new ListaDeBlocos[nListas];
        for (int i = 0; i < nListas; i++)
        {
            linhas[i] = transform.GetChild(i);
            listas[i] = new ListaDeBlocos();
        }
    }

    public void criarListaBlocos()
    {
        for (int i = 0; i < nListas; i++)
        {
            int sorteI = Random.Range(0, 6);

            for (int j = 0; j < 6; j++)
            {
                Bloco newBloco;
                int sorte = Random.Range(1, hpMaxBlocosComuns + 1);

                GameObject newBlocoGO = Instantiate(bloco, new Vector3(j - 2.5f, i, 0), quaternion90, linhas[i]);
                newBlocoGO.GetComponent<MeshRenderer>().material = new Material(materialBlocoBase);

                if (sorteI == j)
                {
                    newBloco = new BlocoIndestrutivel(1, i, j);
                    newBlocoGO.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0);
                }
                else
                {
                    newBloco = new Bloco(sorte, i, j);
                    newBlocoGO.GetComponent<MeshRenderer>().material.color = new Color(0, 0, (float)newBloco.myHP() / hpMaxBlocosComuns);
                }
                listas[i].Alistar(newBloco);
            }
        }
    }

    public void colidirBloco(GameObject bloco)
    {
        int linha = (int)bloco.GetComponentInParent<Transform>().position.y;
        int coluna = (int)bloco.transform.localPosition.x;

        Bloco colidido = listas[linha].procurarConteudo(coluna);

        if (colidido.tomarDano())
        {
            listas[linha].DesalistarConteudo(coluna);

            ctrlPontuacao.pontuar(colidido.GetPontos());

            Destroy(bloco);
            //som de destruir bloco
        }
        else
        {
            bloco.GetComponent<MeshRenderer>().material.color = colidido.GetCor();

            ctrlPontuacao.pontuar(1);
        }
    }

    public ListaDeBlocos GetListaDeBlocos(int linha) { return listas[linha]; }
}