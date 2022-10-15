#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class Report
    {
        public string id { get; set; } = String.Empty;
        public string idUser {get; set;} = String.Empty;
        public string address { get; set; } = String.Empty;
        public ReportType.reportType type { get; set; }
        public string comment { get; set; } = String.Empty;
        public string imageURL { get; set; } = String.Empty;
    }
}