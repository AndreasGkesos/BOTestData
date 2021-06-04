using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BOTestData.Services
{
    public class LoadJSONService<T> : ILoadJSONService<T> where T : class
    {
        public async Task<IEnumerable<T>> LoadJson()
        {
            var genericName = typeof(T).Name;
            string path = Directory.GetCurrentDirectory();

            using StreamReader r = new StreamReader($"{path}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}{genericName}.json");
            string json = await r.ReadToEndAsync();

            List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
            return items;
        }
    }
}
