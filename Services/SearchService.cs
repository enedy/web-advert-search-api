﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using WebAdvert.Search.Api.Models;

namespace WebAdvert.Search.Api.Services
{
    public class SearchService : ISearchService
    {
        private readonly IElasticClient _client;
        public SearchService(IElasticClient client)
        {
            _client = client;
        }

        public async Task<List<AdvertType>> Search(string keyword)
        {
            var searchResponse = await _client.SearchAsync<AdvertType>(search => search.
                Query(query => query.
                    Term(field => field.Title, keyword.ToLower())
                ));

            return searchResponse.Hits.Select(hit => hit.Source).ToList();
        }
    }
}
