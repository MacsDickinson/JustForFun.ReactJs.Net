using System.Collections.Generic;

namespace JustForFun.ReactJS.Data.Domain
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RecipeCategory Category { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Directions { get; set; }
        public int Servings { get; set; }
        public string ImageUrl { get; set; }
    }
}
