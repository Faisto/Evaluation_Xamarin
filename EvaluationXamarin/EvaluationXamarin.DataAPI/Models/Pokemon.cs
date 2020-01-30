using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationXamarin.DataAPI.Models
{
    public class Pokemon
    {
        private string _Name;
        private double _Height;
        private string _Url;
        private string _Type;
        private string _Type2;
        private string _Back;
        private string _Front;
        private Dictionary<string, string> _Stats;
        private string _Description;

        [Column("Description")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        
        [Column("Stat")]
        public Dictionary<string, string> Stat
        {
            get { return _Stats; }
            set { _Stats = value; }
        }

        [Column("Front_image")]
        public string Front
        {
            get { return _Front; }
            set { _Front = value; }
        }

        [Column("Back_image")]
        public string Back
        {
            get { return _Back; }
            set { _Back = value; }
        }

        [Column("Type2")]
        public string Type2
        {
            get { return _Type2; }
            set { _Type2 = value; }
        }

        [Column("Type1")]
        public string Type1
        {
            get { return _Type; }
            set { _Type = value; }
        }
        [Column("URL")]
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        [Column("Height")]
        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        [Column("Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [Column("ID")]
        public int ID
        {
            get
            {
                string temp = Url.Replace("https://pokeapi.co/api/v2/pokemon/", string.Empty);
                return int.Parse(temp.Replace("/", string.Empty));
            }

        }
    }
}
