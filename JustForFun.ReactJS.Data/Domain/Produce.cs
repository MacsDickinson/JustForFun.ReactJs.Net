using System.Collections.Generic;

namespace JustForFun.ReactJS.Data.Domain
{
    public class Produce
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Measurement { get; set; }
        public List<Produce> Substitutions { get; set; }
    }
}