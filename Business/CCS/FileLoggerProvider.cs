using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Text;

namespace Business.CCS
{
    [Microsoft.Extensions.Logging.ProviderAlias("File")]
	public class FileLoggerProvider : LoggerProvider
	{
		internal FileLoggerOptions Settings { get; private set; }

		private string _currentFile;

		private void Initialize()
		{
			_currentFile = Path.Combine(Settings.OutputFolder, string.Format(Settings.FileName, 0));
		}

		public override bool IsEnabled(LogLevel logLevel)
		{
			return logLevel != LogLevel.None && Settings.LogLevel != LogLevel.None && logLevel >= Settings.LogLevel;
		}

		public override void WriteLog(LogEntry log)
		{
			try
			{
				using (var writer = new StreamWriter(_currentFile, true, Encoding.UTF8))
				{
					var time = Settings.LocalTime ? log.Time.ToLocalTime() : log.Time;
					writer.WriteLine($"[{log.Level.ToString()[0]}] {time:yyyy/MM/dd HH:mm:ss.fff} : {log.Text}");
				}
			}
			catch
			{
			}
			#region Backup
			try
			{
				var info = new FileInfo(_currentFile);
				if (info.Length < Settings.MaxFileSize) return;
				var index = Settings.RetainFileCount - 1;
				var fileName = Path.Combine(Settings.OutputFolder, string.Format(Settings.FileName, index));
				File.Delete(fileName);
				for (; index > 0; index--)
				{
					var original = Path.Combine(Settings.OutputFolder, string.Format(Settings.FileName, index - 1));
					if (File.Exists(original)) File.Move(original, fileName);
					fileName = original;
				}
			}
			catch
			{
			}
			#endregion
		}

		public FileLoggerProvider(IOptionsMonitor<FileLoggerOptions> settings)
			: this(settings.CurrentValue)
		{
			SettingsChangeToken = settings.OnChange(s =>
			{
				this.Settings = s;
				Initialize();
			});
		}

		public FileLoggerProvider(FileLoggerOptions settings)
		{
			this.Settings = settings;
			Initialize();
		}

	}
}
