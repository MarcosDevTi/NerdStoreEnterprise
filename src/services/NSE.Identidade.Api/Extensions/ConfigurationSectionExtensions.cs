using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.Identidade.Api.Extensions
{
    public static class ConfigurationSectionExtensions
    {
        public static T GetSection<T>(this IConfiguration config, IServiceCollection services)
            where T : class
        {
            var appSettingsSection = config.GetSection(nameof(T));
            services.Configure<T>(appSettingsSection);

            return appSettingsSection.Get<T>();
        }
    }
}
