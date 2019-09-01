using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonTest.Application.Queries
{
    public interface ISuggestionQueries
    {
        Task<IEnumerable<string>> GetSuggestions(string input);
    }
}
