using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.Services
{
    // PATTERN: Facade
    // Using facades for our services allow us a simplified use of certain key functions like database access, file saving, external services through API etc
    // By providing a simple interface over said functionality
    // This allows for benefits including but not limited to looser coupling of said functionality from other parts of a system, "hiding" (unnecessary)
    // complexity by abstraction, apart from the more obvious benefits of a centralized handling like making the code easier to maintain and easier to change
    // (protects clients (callers) from changes in subsystem functionality)
    
    /**
     * Provides simplified interface for basic save and load operations on data
     */
    internal interface IFileService
    {
    }
}
