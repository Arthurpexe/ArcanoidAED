public interface IObservador<in T>
{
    void atualizar(T dado);
}