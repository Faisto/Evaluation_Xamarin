using EvaluationXamarin.DataAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationXamarin.APIService.Services
{
    public class PokemonService
    {
        private readonly string _Enpoint;

        public PokemonService()
        {
            _Enpoint = "https://pokeapi.co/api/v2";
        }

        public async Task<List<Pokemon>> GetAll(int offset = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"{_Enpoint}/pokemon/?offset={offset}");

                if (message.IsSuccessStatusCode)
                {
                    HttpContent content = message.Content;
                    string stringContent = await content.ReadAsStringAsync();

                    var parsed = JObject.Parse(stringContent);

                    var list = parsed.SelectToken("results");
                    stringContent = list.ToString(Formatting.None);

                    List<Pokemon> listPokemon = JsonConvert.DeserializeObject<List<Pokemon>>(stringContent);
                    return listPokemon;
                }

                return new List<Pokemon>();

            }
        }

        public async Task<Pokemon> Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"{_Enpoint}/pokemon/{id}");
                HttpResponseMessage message1 = await client.GetAsync($"{_Enpoint}/pokemon-species/{id}");

                if (message.IsSuccessStatusCode && message1.IsSuccessStatusCode)
                {
                    HttpContent content = message.Content;
                    string stringContent = await content.ReadAsStringAsync();

                    HttpContent content1 = message1.Content;
                    string stringContent1 = await content1.ReadAsStringAsync();

                    var parsed1 = JObject.Parse(stringContent1);

                    var parsed = JObject.Parse(stringContent);

                    #region Type1

                    var Types = parsed.SelectToken("types");
                    var type = Types.First.SelectToken("type");
                    var nameT = type.SelectToken("name");
                    string NameT1 = nameT.ToString(Newtonsoft.Json.Formatting.None);
                    #endregion

                    #region Type2

                    string NameT2 = "Nothing";

                    if (Types.Last.SelectToken("type") != null)
                    {
                        type = Types.Last.SelectToken("type");
                        var nameT2 = type.SelectToken("name");
                        NameT2 = nameT2.ToString(Newtonsoft.Json.Formatting.None);
                        NameT2 = JsonConvert.DeserializeObject<string>(NameT2);
                    }

                    #endregion

                    #region Name

                    var Forms = parsed.SelectToken("forms");
                    var name = Forms.First.SelectToken("name");
                    string Name = name.ToString(Newtonsoft.Json.Formatting.None);
                    #endregion

                    #region Image

                    var Sprits = parsed.SelectToken("sprites");
                    var back = Sprits.SelectToken("back_default");
                    var front = Sprits.SelectToken("front_default");
                    string BackUrl = back.ToString(Formatting.None);
                    string FrontUrl = front.ToString(Formatting.None);
                    #endregion  

                    #region Stat

                    var StatList = parsed.SelectToken("stats");
                    Dictionary<string, string> Statistics = new Dictionary<string, string>();
                    foreach (var item in StatList)
                    {

                        var Statdet = item.SelectToken("stat");
                        var StatName = Statdet.SelectToken("name");
                        var StatInt = item.SelectToken("base_stat");

                        string statname = StatName.ToString();
                        string statInt = StatInt.ToString(Formatting.None);
                        Statistics.Add(statname, statInt);

                    }

                    #endregion

                    #region Description

                    var description = parsed1.SelectToken("flavor_text_entries");
                    var Description = description[5].SelectToken("flavor_text");
                    string desc = Description.ToString(Formatting.None);                    

                    #endregion

                    Pokemon pokemon = new Pokemon()
                    {
                        Url = $"{_Enpoint}/pokemon/{id}",
                        Name = JsonConvert.DeserializeObject<string>(Name),
                        Type1 = JsonConvert.DeserializeObject<string>(NameT1),
                        Back = JsonConvert.DeserializeObject<string>(BackUrl),
                        Front = JsonConvert.DeserializeObject<string>(FrontUrl),
                        Type2 = NameT2,
                        Stat = Statistics,
                        Description = JsonConvert.DeserializeObject<string>(desc)


                    };

                    //Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(stringContent);
                    return pokemon;
                }

                return new Pokemon();

            }

        }
    }
}
