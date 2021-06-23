using System.Collections.Generic;
using System.Threading.Tasks;
using WebAdvert.Search.Api.Models;

namespace WebAdvert.Search.Api.Services
{
    public interface ISearchService
    {
        Task<List<AdvertType>> Search(string keyword);
    }
}
