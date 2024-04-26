using API.Versioning.Models.v1;
using API.Versioning.Services.v1.Interfaces;

namespace API.Versioning.Services.v1
{
    public class DriverService : IDriver
    {
        private readonly databaseContext _context;

        public DriverService(databaseContext context)
        {
            _context = context;
        }

        public async Task<DriverInfo> CreateOrUpdateDriver(DriverInfo model)
        {
            // Check if the driver already exists in the database
            var existingDriver = await _context.DriverInfos.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (existingDriver == null)
            {
                // If the driver doesn't exist, create a new one
                _context.DriverInfos.Add(model);
            }
            else
            {
                // If the driver exists, update its properties with the new values
                _context.Entry(existingDriver).CurrentValues.SetValues(model);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return model;
        }


        public async Task<string> DeleteDriver(Guid id)
        {
            var driverToDelete = await _context.DriverInfos.FindAsync(id);
            if (driverToDelete != null)
            {
                _context.DriverInfos.Remove(driverToDelete);
                await _context.SaveChangesAsync();

                return "deleted";
            }
            else
            {
                return "not exist";
            }
        }


        public async Task<IEnumerable<DriverInfo>> GetAllDrivers()
        {
            return await _context.DriverInfos.ToListAsync();
        }

        public async Task<DriverInfoVm> GetDriverById(Guid id)
        {
            return await _context.DriverInfos
                .Where(x => x.Id == id)
                .Select(x => new DriverInfoVm
                {
                    driverName = x.driverName,
                    phone = x.phone,
                    email = x.email,
                    licenseNo = x.licenseNo
                })
                .FirstOrDefaultAsync();
        }
    }
}
