using JustForFun.ReactJS.Data.Domain;
using System.Collections.Generic;

namespace JustForFun.ReactJS.Data.Repositories
{
    public class RecipeRepository
    {
        private IDictionary<string, Recipe> _recipies;

        public RecipeRepository()
        {
            _recipies = new Dictionary<string, Recipe>();
        }

        public void SetUpSampleData()
        {
            var produceRepository = new ProduceRepository();
            produceRepository.SetupSampleData();

            Add(new Recipe
                {
                    Id = "kid-friendly-green-juice-recipe",
                    Name = "Kid-Approved Green Power Juice",
                    Category = RecipeCategory.Juice,
                    Servings = 1,
                    ImageUrl = "http://www.rebootwithjoe.com/wp-content/uploads/2015/07/Kid-Approved-Green-Juice2.jpg",
                    Intro = "Want to help your kids reach for more veggie-based juices? Make this sweet but veggie-heavy juice and your child will be asking for more.",
                    Description = @"Want to help your kids reach for more veggie-based juice?  Besides the visual appeal of color and container, the more they participate the more likely they are to want to share in the fun and deliciousness.  I actually enjoy grocery shopping and trips to the farmer’s market with my kids.  I know this may be bit hard to believe…what busy mom doesn’t want to just get in and out of the store quickly?! But I find that having them help make choices at the store can make a big difference in the choices they make at home, friends houses and dining out.  Plus, as they get older, helping me carry groceries or quickly running back to grab an item I forgot can make them much more of a help than a hindrance on errands.  And I selfishly just love spending time with my boys so while they’re still willing to hang out with me, I’ll take whatever I can get!

If this juice isn’t sweet enough for your youngster, titrate the flavor gradually for long term results.  Start by adding a bit of honey, another green apple, a red apple, a pear or some fresh pineapple.  Even diluting with maple or coconut water may be appealing. For kids, healthy eating is a marathon not a sprint so even if their juice has more fruits to start, don’t worry, that can change over time. Plus, fruits still have many antioxidants and other important nutrients for their health.

This juice has plenty of Vitamin C-rich cruciferous vegetables that help to support a healthy liver, like cabbage, which may be better tolerated as juice vs eating.  There are also anti-inflammatory, heart healthy, skin enhancing and metabolism supportive properties native to the fruits and veggies found in our Green Power-Smash Juice.",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Produce = produceRepository.Get("Mint"), Quantity = 1.0m },
                        new Ingredient { Produce = produceRepository.Get("Lime"), Quantity = 1.0m },
                        new Ingredient { Produce = produceRepository.Get("Green Apple"), Quantity = 1.0m },
                        new Ingredient { Produce = produceRepository.Get("Cucumber"), Quantity = 1.0m },
                        new Ingredient { Produce = produceRepository.Get("Head of Green Cabbage"), Quantity = .25m }
                    },
                    Directions = new List<string>
                    {
                        "Wash and prepare all produce well.",
                        "Peel lime and core apple.",
                        "Wrap mint around cucumber to produce more yield from the mint.",
                        @"Add all ingredients through juicer and enjoy.<b>Tip:</b> Your child may enjoy it a little colder so feel free to add it over ice!"
                    }
                });
            Add(new Recipe
            {
                Id = "kickin-it-with-kale-juice-recipe",
                Name = "Kickin’ it with Kale Juice",
                Category = RecipeCategory.Juice,
                Servings = 1,
                ImageUrl = "http://www.rebootwithjoe.com/wp-content/uploads/2015/06/Kickin-it-with-Kale-420.jpg",
                Intro = "Kick back, relax, and drink in this juice that's full of green goodness like anti-inflammatories and cancer-fighting properties you're sure to love.",
                Description = @"Kick back, relax, and drink in this juice that’s full of green goodness that you’re sure to love. Broccoli and kale, both members of the cabbage (Brassica) family, offer immense health benefits in the prevention of cancer, particularly breast, prostate and colon, and helps to enhance the function of the liver (your body’s fat burner!). The sweet pear packs in a high dose of soluble fiber and sweetens this juice right up. Enjoy!",
                Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Produce = produceRepository.Get("Pear"), Quantity = 2.0m },
                        new Ingredient { Produce = produceRepository.Get("Broccoli"), Quantity = .5m },
                        new Ingredient { Produce = produceRepository.Get("Kale"), Quantity = 4.0m },
                        new Ingredient { Produce = produceRepository.Get("Celery"), Quantity = 2.0m },
                        new Ingredient { Produce = produceRepository.Get("Lime"), Quantity = 1.0m },
                        new Ingredient { Produce = produceRepository.Get("Ginger"), Quantity = 1.0m }
                    },
                Directions = new List<string>
                    {
                        "Wash all produce well.",
                        "Peel the lime.",
                        "Add all ingredients through juicer and enjoy!"
                    }
            });
        }

        public IDictionary<string, Recipe> GetAll()
        {
            return _recipies;
        }

        public void Add(Recipe recipe)
        {
            _recipies.Add(recipe.Id, recipe);
        }
        public void Remove(string id)
        {
            _recipies.Remove(id);
        }

        public void Update(Recipe recipe)
        {
            _recipies.Remove(recipe.Id);
            _recipies.Add(recipe.Id, recipe);
        }
    }
}
