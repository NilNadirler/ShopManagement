using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Business.CCS
{
    public class FileLoggerOptionsSetup : ConfigureFromConfigurationOptions<FileLoggerOptions>
	{
		/// <summary>
		/// Constructor that takes the IConfiguration instance to bind against.
		/// </summary>
		public FileLoggerOptionsSetup(ILoggerProviderConfiguration<FileLoggerProvider> providerConfiguration)
			: base(providerConfiguration.Configuration)
		{
		}
	}
}
