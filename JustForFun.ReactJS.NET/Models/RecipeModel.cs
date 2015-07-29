using JustForFun.ReactJS.Data.Domain;
using System.Collections.Generic;
using AutoMapper;

namespace JustForFun.ReactJS.NET.Models
{
    public class RecipeModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RecipeCategory Category { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public List<string> Directions { get; set; }
        public int Servings { get; set; }
        public string ImageUrl { get; set; }

        internal Recipe ToDomain()
        {
            return Mapper.DynamicMap<RecipeModel, Recipe>(this);
        }

        public static explicit operator RecipeModel(Recipe domain)
        {
            Mapper.CreateMap<Recipe, RecipeModel>();
            Mapper.CreateMap<Ingredient, IngredientModel>();

            return Mapper.Map<Recipe, RecipeModel>(domain);
        }
    }
}