using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T> // Toda vez que tiver T, o código vai substituir pelo item, 
                                    //podendo ser serie, etc.
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}