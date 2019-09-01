using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzonTest.Application.Queries;

namespace OzonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestController : ControllerBase
    {
        private ISuggestionQueries _suggestionQueries;

        public SuggestController(ISuggestionQueries suggestionQueries)
        {
            _suggestionQueries = suggestionQueries ?? throw new ArgumentNullException(nameof(suggestionQueries));
        }
               
        [HttpGet]
        public async Task<IEnumerable<string>> Suggest(string input)
        {
            return await _suggestionQueries.GetSuggestions(input);
        }       
    }
}
