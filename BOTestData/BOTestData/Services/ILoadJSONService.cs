using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOTestData.Services
{
    public interface ILoadJSONService<T> where T : class
    {
        Task<IEnumerable<T>> LoadJson();
        Task<T> LoadLookupJson();
    }
}
