using AutoMapper;
using JustForFun.ReactJS.Data.Domain;
using System.Collections.Generic;

namespace JustForFun.ReactJS.NET.Models
{
    public class RecipeDetailsModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public IList<IngredientModel> Ingredients { get; set; }
        public IList<string> Directions { get; set; }
        public int Servings { get; set; }
        public string ImageUrl { get; set; }

        internal Recipe ToDomain()
        {
            return Mapper.DynamicMap<RecipeDetailsModel, Recipe>(this);
        }

        public static explicit operator RecipeDetailsModel(Recipe domain)
        {
            Mapper.CreateMap<Recipe, RecipeDetailsModel>();
            Mapper.CreateMap<Ingredient, IngredientModel>();

            return Mapper.Map<Recipe, RecipeDetailsModel>(domain);
        }
    }
}