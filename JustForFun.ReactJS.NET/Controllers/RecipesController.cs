using JustForFun.ReactJS.Data.Repositories;
using JustForFun.ReactJS.NET.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace JustForFun.ReactJS.NET.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeRepository _recipes;

        public RecipesController()
        {
            _recipes = new RecipeRepository();
            _recipes.SetUpSampleData();
        }

        // GET: Recipes
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View(_recipes.GetAll().Select(x => (RecipeCardModel)x.Value));
            }

            if (!_recipes.GetAll().ContainsKey(id))
            {
                throw new HttpException(404, "No recipe found with the specified id.");
            }

            var recipe = (RecipeCardModel)_recipes.GetAll()[id];
            return View("RecipeDetails", recipe);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult All()
        {
            var all = _recipes.GetAll().Select(x => (RecipeCardModel)x.Value);
            return Json(all, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRecipe(RecipeCardModel recipe)
        {
            _recipes.Add(recipe.ToDomain());
            return Content("Success :)");
        }
    }
}