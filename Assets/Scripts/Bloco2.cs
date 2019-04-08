using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco2 : MonoBehaviour
{
    public int vida;
    public int tipoBloco;
    public Material materialBloco;
    public Bloco blocoDesalistado;


    private void Update()
    {
        if (vida == 1)
        {
            //Instantiate(bloco1, this.transform.position, this.transform.rotation);
            //Destroy(this.gameObject);
            materialBloco.SetColor(tipoBloco, Color.yellow);
        }
        if(vida <= 0)
        {
            blocoDesalistado = CriaListaDeBlocos.singleton.listaDeBlocos.Desalistar(tipoBloco);
            if (blocoDesalistado.tipoDoBloco == tipoBloco)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vida -= 1;
    }
}
