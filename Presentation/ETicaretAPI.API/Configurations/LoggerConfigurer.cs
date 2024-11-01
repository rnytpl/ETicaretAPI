using ETicaretAPI.API.Configurations.ColumnWriters;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;


namespace ETicaretAPI.API.Configurations
{
    public class LoggerConfigurer
    {

        readonly IConfiguration _configuration;

        public LoggerConfigurer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Logger configureLogger()
        {

            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.text")
                .WriteTo.PostgreSQL(
                    _configuration?.GetConnectionString("PostgreSQL"),
                    "logs",
                    needAutoCreateTable: true,
                    columnOptions: new Dictionary<string, ColumnWriterBase>
                    {
                        {"message", new RenderedMessageColumnWriter() },
                        {"message_template", new MessageTemplateColumnWriter() },
                        {"level", new LevelColumnWriter() },
                        {"time_stamp", new TimestampColumnWriter() },
                        {"exception", new ExceptionColumnWriter() },
                        {"log_event", new LogEventSerializedColumnWriter() },
                        {"user_name", new UsernameColumnWriter()}
                    }
                )
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();

            return log;

        }

    }
}
