using System.Collections.Generic;
using EPlayersMVC.Models;

namespace EPlayersMVC.Views.Interfaces
{
    public interface IJogador
    {
         void Criar (Jogador j);

         List<Jogador> LerTodos();

         void Alterar(Jogador j);

         void Deletar(int id);
    }
}