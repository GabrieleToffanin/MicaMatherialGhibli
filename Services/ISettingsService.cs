using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface ISettingsService
    {
        void SetValue<T>(string key, T value);

        [Pure]
        T GetValue<T>(string key);
    }
}
