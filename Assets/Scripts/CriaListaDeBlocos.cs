using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaListaDeBlocos : MonoBehaviour
{
    public static CriaListaDeBlocos singleton;
    public float nListaOriginal;
    public GameObject bloco0, bloco1, bloco2;
    public ListaDeBlocos listaDeBlocos;
    public int quantidadeDeBlocos;

    private Quaternion quaternion90 = new Quaternion(0, 0, 7071068, 7071068);

    public bool Desalistou(int tipoDoBloco, float nListaBloco)
    {
        if(nListaBloco == nListaOriginal)
        {
            listaDeBlocos.Desalistar(tipoDoBloco);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TaVazia()
    {
        if (listaDeBlocos.vazio())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        listaDeBlocos = new ListaDeBlocos(nListaOriginal);
    }

    private void Update()
    {
        quantidadeDeBlocos = listaDeBlocos.QuantosBlocos();

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            int sorte0 = Random.Range(0, 6);

            for(int i = 0; i < 6; i++)
            {
                
                int sorte = Random.Range(1, 3);

                if (sorte0 == i)
                {
                    Bloco novoBloco = new Bloco(0);
                    novoBloco.tipoDoBloco = 0;
                    Instantiate(bloco0, new Vector3(i - 2.5f, nListaOriginal, 0), quaternion90, this.gameObject.transform);
                    listaDeBlocos.Alistar(novoBloco);
                }
                else
                {
                    if (sorte == 1)
                    {
                        Bloco novoBloco = new Bloco(1);
                        Instantiate(bloco1, new Vector3(i - 2.5f, nListaOriginal, 0), quaternion90, this.gameObject.transform);
                        listaDeBlocos.Alistar(novoBloco);
                    }
                    if (sorte == 2) 
                    {
                        Bloco novoBloco = new Bloco(2);
                        Instantiate(bloco2, new Vector3(i - 2.5f, nListaOriginal, 0), quaternion90, this.gameObject.transform);
                        listaDeBlocos.Alistar(novoBloco);
                    }
                }
            }
        }
        
    }
}
