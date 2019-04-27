namespace LoggignService.LoggerAPI.Models
{
    public class LoggingModel
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public string ServiceName { get; set; }
        public string LongDate { get; set; }
        public string Logger { get; set; }
        public string Exception { get; set; }
    }
}
