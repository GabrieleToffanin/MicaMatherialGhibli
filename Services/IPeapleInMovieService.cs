using MicaMatherialGhibli.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface IPeapleInMovieService
    {
        [Get("/people")]
        Task<IEnumerable<People>> FindAllPeople();
    }
}
