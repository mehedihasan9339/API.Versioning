namespace API.Versioning.Data
{
    public class DriverInfo:BaseEntity
    {
        public string driverName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string licenseNo { get; set; }
    }
}
