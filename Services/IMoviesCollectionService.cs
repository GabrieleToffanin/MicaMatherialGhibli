using MicaMatherialGhibli.Helpers;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface IMoviesCollectionService
    {
        [Get("/films")]
        Task<IEnumerable<SingleFilmID>> getAllMoviesID();
    }
}
