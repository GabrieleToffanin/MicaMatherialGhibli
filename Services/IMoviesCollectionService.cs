using MicaMatherialGhibli.Helpers;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface IMoviesCollectionService
    {
        [Get("/films")]
        Task<IEnumerable<SingleFilmID>> getAllMoviesID();
    }
}
