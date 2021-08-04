using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Business.CCS
{
    public abstract class LoggerProvider : IDisposable, ILoggerProvider, ISupportExternalScope
	{
		readonly ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();
		protected IDisposable SettingsChangeToken;
		IExternalScopeProvider _scopeProvider;

		public void Dispose()
		{
			SettingsChangeToken?.Dispose();
			SettingsChangeToken = null;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return _loggers.GetOrAdd(categoryName, (category) => new FileLogger(this, category));
		}
		public void SetScopeProvider(IExternalScopeProvider scopeProvider)
		{
			_scopeProvider = scopeProvider;
		}


		public abstract bool IsEnabled(LogLevel logLevel);
		public abstract void WriteLog(LogEntry info);


		internal IExternalScopeProvider ScopeProvider => _scopeProvider ?? (_scopeProvider = new LoggerExternalScopeProvider());

		void ISupportExternalScope.SetScopeProvider(IExternalScopeProvider scopeProvider)
		{
			_scopeProvider = scopeProvider;
		}

	}
}
