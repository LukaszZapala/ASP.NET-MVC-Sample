using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormsSample.Models
{
    public enum CatType
    {
        Dachowiec, Rufowiec, Pers, Rosyjski
    }

    public class CatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CatType Type { get; set; }
    }
}