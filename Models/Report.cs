#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Address { get; set; } = String.Empty;
        public ReportType Type { get; set; }
        public string Comment { get; set; } = String.Empty;
        public string ImageURL { get; set; } = String.Empty;     
    }
}