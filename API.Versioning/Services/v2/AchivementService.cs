using API.Versioning.Models.v2;
using API.Versioning.Services.v2.Interfaces;

namespace API.Versioning.Services.v2
{
    public class AchivementService: IAchivement
    {
        private readonly databaseContext _context;

        public AchivementService(databaseContext context)
        {
            _context = context;
        }

        public async Task<AchivementInfo> CreateOrUpdateAchivement(AchivementInfo model)
        {
            var existingAchivement = await _context.AchivementInfos.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (existingAchivement == null)
            {
                _context.AchivementInfos.Add(model);
            }
            else
            {
                _context.Entry(existingAchivement).CurrentValues.SetValues(model);
            }

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<string> DeleteAchivement(Guid id)
        {
            var achivementToDelete = await _context.AchivementInfos.FindAsync(id);
            if (achivementToDelete != null)
            {
                _context.AchivementInfos.Remove(achivementToDelete);
                await _context.SaveChangesAsync();

                return "deleted";
            }
            else
            {
                return "not exist";
            }
        }

        public async Task<IEnumerable<AchivementVm>> GetAchivementsByDriverId(Guid id)
        {
            return await _context.AchivementInfos.Where(x => x.driverInfoId == id).Select(x => new AchivementVm
            {
                Id = x.Id,
                achivementName = x.achivementName,
                achivementId = x.achivementId,
                date = x.date
            }).AsNoTracking().ToListAsync();
        }
    }
}
