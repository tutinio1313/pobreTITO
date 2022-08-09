#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class Report
    {
        public int id { get; set; }
        public string location { get; set; }
        public ReportType.reportType type { get; set; }
        public string comment { get; set; }
        public string imageURL { get; set; }
    }
}