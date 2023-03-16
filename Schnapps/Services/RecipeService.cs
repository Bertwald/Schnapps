using Schnapps.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Schnapps.Services
{
    // Variant made with only the course materials
    // For a simplified refactor with better syntax, using "refit", see ICocktailservice and CocktailService
    internal class RecipeService
    {
        private readonly HttpClient _client = new();
        private const string _host = "https://www.thecocktaildb.com/api/json";
        private const string _version = "v1";
        private const string _key = "1";
        private const string _fullUrl = $"{_host}/{_version}/{_key}/";
        private readonly JsonSerializerOptions _serializeOptions = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public RecipeService() {
            var url = new Uri(_fullUrl);
            _client.BaseAddress = url;
        }
        public async Task<CocktailDBObject> GetDrinksByLetter(char letter) {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"search.php?f={letter}");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response, _serializeOptions);
            }
            return obj;
        }
        public async Task<CocktailDBObject> GetDrinksById(string id) {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"search.php?i={id}");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response, _serializeOptions);
            }
            return obj;
        }
        public async Task<CocktailDBObject> SearchForDrink(string name) {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"search.php?s={name}");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response , _serializeOptions);
            }
            return obj;
        }
        public async Task<CocktailDBObject> GetRandom() {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"random.php");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response, _serializeOptions);
            }
            return obj;
        }
        public async Task<CocktailDBObject> GetByIngredient(string ingredient) {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"filter.php?i={ingredient}");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response, _serializeOptions);
            }
            return obj;
        }
        public async Task<CocktailDBObject> GetByAlcoholic(bool containsAlcohol) {
            CocktailDBObject obj = null;
            HttpResponseMessage message = await _client.GetAsync($"filter.php?a={(containsAlcohol?"Alcoholic":"Non_Alcoholic")}");
            if (message.IsSuccessStatusCode) {
                string response = await message.Content.ReadAsStringAsync();
                obj = JsonSerializer.Deserialize<CocktailDBObject>(response, _serializeOptions);
            }
            return obj;
        }
    }
}
