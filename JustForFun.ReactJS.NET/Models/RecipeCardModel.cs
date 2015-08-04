using JustForFun.ReactJS.Data.Domain;
using AutoMapper;

namespace JustForFun.ReactJS.NET.Models
{
    public class RecipeCardModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RecipeCategory Category { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        internal Recipe ToDomain()
        {
            return Mapper.DynamicMap<RecipeCardModel, Recipe>(this);
        }

        public static explicit operator RecipeCardModel(Recipe domain)
        {
            Mapper.CreateMap<Recipe, RecipeCardModel>();

            return Mapper.Map<Recipe, RecipeCardModel>(domain);
        }
    }
}