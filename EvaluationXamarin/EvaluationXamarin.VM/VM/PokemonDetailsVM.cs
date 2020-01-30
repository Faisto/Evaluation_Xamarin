using EvaluationXamarin.APIService.Services;
using EvaluationXamarin.DataAPI.Models;
using SQLite.Net.Platform.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationXamarin.VM.VM
{
    public class PokemonDetailsVM : ModelBase
    {
        private Pokemon _pokemon;
        public string ID = "1";
        public Pokemon pokemon
        {
            get { return _pokemon; }
            set { _pokemon = value; RaisePropertyChanged(); }
        }

        private async void Refresh(int id)
        {
            PokemonService service = new PokemonService();
            this.pokemon = await service.Get(id);
           
        }        

        public PokemonDetailsVM()
        {
            this.pokemon = new Pokemon();
            Refresh(int.Parse(this.ID));

            SQLiteConnection.CreateFile("PokemonDB");

            SQLiteConnection connection = new SQLiteConnection("PokemonDB");
            connection.Open();


        }

    }
}
