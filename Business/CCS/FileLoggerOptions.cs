using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace Business.CCS
{
    public class FileLoggerOptions
	{
		public LogLevel LogLevel { get; set; } = LogLevel.Information;

		private string _outputFolder = null;
		public string OutputFolder
		{
			get
			{
				if (string.IsNullOrEmpty(_outputFolder))
				{
					_outputFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName) ?? "";
				}
				return _outputFolder;
			}
			set => _outputFolder = value;
		}

		/// <summary>
		/// File name template
		/// {0} : File counter(0:new - )
		/// </summary>
		public string FileName { get; set; } = "{0:d2}.log";

		/// <summary>
		/// Maximum size of single log file.
		/// </summary>
		public int MaxFileSize { get; set; } = 512 * 1024;

		/// <summary>
		/// Maximum number of log files to retain.
		/// </summary>
		public int RetainFileCount { get; set; } = 10;

		/// <summary>
		/// 
		/// </summary>
		public bool LocalTime { get; set; }

		public FileLoggerOptions()
		{
		}
	}
}
