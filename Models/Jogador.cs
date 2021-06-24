using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Views.Interfaces;

namespace EPlayersMVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }  

        public string Email { get; set; }

        public string Senha { get; set; } 

        private const string CAMINHO = "Database/Jogador.csv";


        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string PrepararLinhas(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

         public void Criar(Jogador j)
        {
            string[] linha = {PrepararLinhas(j)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            //1;Nome do jogador;...
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                //1
                //Nome do jogador
                //Etc..

                Jogador novoJogador = new Jogador();
                novoJogador.IdJogador = Int32.Parse(linha[0]);
                novoJogador.Nome = linha[1];
                novoJogador.IdEquipe = Int32.Parse(linha[2]);
                novoJogador.Email = linha[3];
                novoJogador.Senha = linha[4];

                jogadores.Add(novoJogador);
            }

            return jogadores;
        }
         public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(PrepararLinhas(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }
    }
}