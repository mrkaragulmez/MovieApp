using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infrastructure.Database
{
    public class DatabaseProvider
    {
        public DatabaseProvider()
        {
            string dataSource = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory())}\\MovieApp.Infrastructure\\Database\\Film.json");
            Movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(dataSource);
        }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
