using AutoMapper;
using JustForFun.ReactJS.Data.Domain;

namespace JustForFun.ReactJS.NET.Models
{
    public class IngredientModel
    {
        public decimal Quantity { get; set; }
        public string ProduceName { get; set; }

        public static explicit operator IngredientModel(Ingredient domain)
        {
            return Mapper.DynamicMap<Ingredient, IngredientModel>(domain);
        }
    }
}