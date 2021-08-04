using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger
	{
		private readonly LoggerProvider _loggerProvider;
		private string _category;

		public FileLogger(LoggerProvider provider, string category)
		{
			_loggerProvider = provider;
			_category = category;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel)) return;
			var entry = new LogEntry
			{
				Time = DateTime.UtcNow,
				Level = logLevel,
				EventId = eventId,
				Exception = exception
			};
			entry.Text = formatter != null ? formatter(state, exception) : state.ToString();
			if (exception != null)
			{
				entry.Text += "\n" + exception.GetType() + ": " + MakeExceptionStrings(exception) + ReplaceStackTracePath(exception.StackTrace);
			}

			_loggerProvider.WriteLog(entry);
		}
		public bool IsEnabled(LogLevel logLevel)
		{
			return _loggerProvider.IsEnabled(logLevel);
		}
		public IDisposable BeginScope<TState>(TState state)
		{
			return _loggerProvider.ScopeProvider.Push(state);
		}

		private static string MakeExceptionStrings(Exception exp)
		{
			var builder = new StringBuilder();
			var e = exp;
			while (e != null)
			{
				builder.AppendLine(e.Message);
				e = e.InnerException;
			}
			return builder.ToString();
		}
		private static string ReplaceStackTracePath(string trace)
		{
			if (string.IsNullOrEmpty(trace)) return "";
			var path = trace.Split('\n');
			var retVal = "";
			foreach (var s in path)
			{
				if (s.IndexOf('\\') >= 0)
				{
					retVal += s.Substring(0, s.LastIndexOf(')') + 2);
					retVal += s.Substring(s.LastIndexOf('\\'));
					retVal += "\n";
				}
				else
				{
					retVal += s + "\n";
				}
			}

			return retVal.TrimEnd('\n');
		}

	}
}
