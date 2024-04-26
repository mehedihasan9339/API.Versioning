namespace API.Versioning.Data
{
    public class AchivementInfo:BaseEntity
    {
        public Guid driverInfoId { get; set; }
        public DriverInfo driverInfo { get; set; }

        public string achivementName { get; set; }
        public string achivementId { get; set; }
        public DateTime date { get; set; }
    }
}
