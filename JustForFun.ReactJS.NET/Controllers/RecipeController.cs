using JustForFun.ReactJS.Data.Repositories;
using JustForFun.ReactJS.NET.Models;
using System.Web.Mvc;
using System.Web.UI;

namespace JustForFun.ReactJS.NET.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeRepository _recipes;

        public RecipeController()
        {
            _recipes = new RecipeRepository();
            _recipes.SetUpSampleData();
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        // GET: Recipes
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id) || !_recipes.GetAll().ContainsKey(id))
            {
                throw new System.Web.HttpException(404, "No recipe found with the specified id.");
            }

            var recipe = (RecipeDetailsModel)_recipes.GetAll()[id];

            if (Request.IsAjaxRequest())
            {
                return Json(recipe, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(recipe);
            }
        }
    }
}