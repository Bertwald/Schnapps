using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PATTERN: Facade (ish)
// Using facades for our services allow us a simplified use of certain key functions like database access, file saving, external services through API etc
// By providing a simple interface over said functionality. In this instance we get a really simple rest service through refit
// This allows for benefits including but not limited to looser coupling of said functionality from other parts of a system, "hiding" (unnecessary)
// complexity by abstraction, apart from the more obvious benefits of a centralized handling like making the code easier to maintain and easier to change
// (protects clients (callers) from changes in subsystem functionality)


// class not needed as of new refactor, will be removed after grading
namespace Schnapps.Services {
    public class CocktailService {
        #region Fields
        private const string _host = "https://www.thecocktaildb.com/api/json";
        private const string _version = "v1";
        private const string _key = "1";
        private const string _fullUrl = $"{_host}/{_version}/{_key}/";
        #endregion
        #region Properties
        public ICocktailService CocktailDBSevice { get; }
        #endregion
        #region Constructors
        public CocktailService() {
            CocktailDBSevice = RestService.For<ICocktailService>(_fullUrl);
        }
        #endregion
    }
}
