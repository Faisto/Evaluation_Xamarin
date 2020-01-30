using EvaluationXamarin.APIService.Services;
using EvaluationXamarin.DataAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Command;

namespace EvaluationXamarin.VM.VM
{
    public class PokemonCreateVM : ModelBase
    {
		private Pokemon _pokemon;
		private Command _AddPokemon;

		public Command AddPokemon
		{
			get
			{
				return _AddPokemon ?? new Command(() =>
				{

				});
			}
		}

		private async void Refresh(int id)
		{
			PokemonService service = new PokemonService();
			this.pokemon = await service.Get(id);

		}

		public Pokemon pokemon
		{
			get { return _pokemon; }
			set { _pokemon = value; }
		}

		public PokemonCreateVM()
		{
			this.pokemon = new Pokemon();
			Refresh(1);
		}

	}
}
