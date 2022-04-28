using MicaMatherialGhibli.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface IApiServices
    {
        Task<IEnumerable<Movie>> LoadAllMoviesAsync();
        Task<IEnumerable<People>> LoadCurrentMoviePeopleAsync(Movie movie);

    }
}
