using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Settings
{
    /// <summary>
    /// Arbitrary class that supports accessing to the database setting from appsettings.json file.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Gets or sets db connectionstring.
        /// </summary>
        public string ConnectionString { get; set; }

    }
}
