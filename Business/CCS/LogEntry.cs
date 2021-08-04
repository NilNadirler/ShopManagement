using Microsoft.Extensions.Logging;
using System;

namespace Business.CCS
{
    public class LogEntry
	{
		public DateTime Time { get; set; }
		public LogLevel Level { get; set; }
		public EventId EventId { get; set; }
		public string Text { get; set; }
		public Exception Exception { get; set; }
	}
}
