using API.Versioning.Models.v1;

namespace API.Versioning.Services.v1.Interfaces
{
    public interface IDriver
    {
        Task<DriverInfo> CreateOrUpdateDriver(DriverInfo model);
        Task<string> DeleteDriver(Guid id);
        Task<IEnumerable<DriverInfo>> GetAllDrivers();
        Task<DriverInfoVm> GetDriverById(Guid id);
    }
}
