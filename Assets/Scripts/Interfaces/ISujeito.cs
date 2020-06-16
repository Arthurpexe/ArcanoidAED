public interface ISujeito<out T>
{
    void inscreverObservador(IObservador<T> obs);
    void desinscreverObservador(IObservador<T> obs);
    void notificarObservadores();
}