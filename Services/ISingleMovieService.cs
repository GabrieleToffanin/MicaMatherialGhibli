using MicaMatherialGhibli.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface ISingleMovieService
    {
        [Get("/films/{id}")]
        Task<Movie> LoadMoviesAsync(string id);
    }
}
