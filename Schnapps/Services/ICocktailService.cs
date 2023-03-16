using Refit;
using Schnapps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.Services {
    public interface ICocktailService {
        [Get("/search.php?f={letter}")]
        Task<CocktailDBObject> GetDrinksByLetter(char letter);

        [Get("/filter.php?c={category}")]
        Task<CocktailDBObject> GetCocktailsByCategoryAsync(string category);

        [Get("/filter.php?a={alcoholic}")]
        Task<CocktailDBObject> GetCocktailsByAlcoholicAsync(string alcoholic);

        [Get("/filter.php?i={ingredient}")]
        Task<CocktailDBObject> GetCocktailsByIngredientAsync(string ingredient);

        [Get("/lookup.php?i={drinkId}")]
        Task<CocktailDBObject> GetCocktailByIdAsync(string drinkId);

        [Get("/random.php")]
        Task<CocktailDBObject> GetRandomCocktailAsync();
        [Get("/search.php?s={name}")]
        Task<CocktailDBObject> SearchCocktailByNameAsync(string name);
        [Get("/list.php?i=list")]
        Task<CocktailDBObject> GetAllIngredientsAsync();
    }
}
