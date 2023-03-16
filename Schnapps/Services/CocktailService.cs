using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.Services {
    public class CocktailService {
        private const string _host = "https://www.thecocktaildb.com/api/json";
        private const string _version = "v1";
        private const string _key = "1";
        private const string _fullUrl = $"{_host}/{_version}/{_key}/";
        public ICocktailService CocktailDBSevice { get; }
        public CocktailService() {
            CocktailDBSevice = RestService.For<ICocktailService>(_fullUrl);
        }

    }
}
