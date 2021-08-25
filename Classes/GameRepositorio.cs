using System;
using System.Collections.Generic;
using cadastro_GameFlix.Interfaces;

namespace cadastro_GameFlix
{
    public class GameRepositorio : IRepositorio<Game>
    {
        private List<Game> listaGame = new List<Game>();
		public void Atualiza(int id, Game objeto)
		{
			listaGame[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaGame[id].Excluir();
		}

		public void Insere(Game objeto)
		{
			listaGame.Add(objeto);
		}

		public List<Game> Lista()
		{
			return listaGame;
		}

		public int ProximoId()
		{
			return listaGame.Count;
		}

		public Game RetornaPorId(int id)
		{
			return listaGame[id];
		}
    }
}