using System.Diagnostics.Contracts;

namespace MicaMatherialGhibli.Services
{
    public interface ISettingsService
    {
        void SetValue<T>(string key, T value);

        [Pure]
        T GetValue<T>(string key);
    }
}
