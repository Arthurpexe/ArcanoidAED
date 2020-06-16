using UnityEngine;

public class Bloco
{
    protected int hp;
    protected int hpMax;
    protected Vector3 id;
    protected int pontos;
    protected Color cor = Color.white;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hp">Quantidade de hits nescessarios para quebrar o bloco. (hp = -1 significa que é indestrutivel)</param>
    /// <param name="linha"></param>
    /// <param name="coluna"></param>
    public Bloco(int hp, int linha, int coluna)
    {
        this.hp = hpMax = hp;
        id = new Vector3(linha, coluna, 1);
    }

    /// <summary>
    /// diminui o HP do bloco em 1
    /// </summary>
    /// <returns>se o HP do bloco chegar a 0, retorna true</returns>
    public virtual bool tomarDano()
    {
        if (hp > 0)
        {
            hp--;
            if (hp == 0)
            {
                return true;
            }
        }
        return false;
    }
    public int myHP() { return hp; }
    public int myHPMax() { return hpMax; }
    public Vector3 myID() { return id; }
    public int GetPontos()
    {
        if (pontos == 0)
        {
            switch (id.z)
            {
                case 0:
                    pontos = 50;
                    break;
                case 1:
                    pontos = hpMax * 2 + 4;
                    break;
                default:
                    Debug.LogWarning("ID do bloco " + id + " não configurado");
                    break;
            }
        }
        return pontos;
    }
    public Color GetCor()
    {
        float ncor = (float)hp / hpMax;

        switch (id.z)
        {
            case 0:
                cor = new Color(ncor, ncor, 0);
                break;
            case 1:
                cor = new Color(0, 0, ncor);
                break;
            default:
                Debug.LogWarning("ID do bloco " + id + " não configurado");
                break;
        }
        return cor;
    }
}