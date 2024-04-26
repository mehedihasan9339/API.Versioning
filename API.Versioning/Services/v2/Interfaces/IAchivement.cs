using API.Versioning.Models.v2;

namespace API.Versioning.Services.v2.Interfaces
{
    public interface IAchivement
    {
        Task<AchivementInfo> CreateOrUpdateAchivement(AchivementInfo model);
        Task<string> DeleteAchivement(Guid id);
        Task<IEnumerable<AchivementVm>> GetAchivementsByDriverId(Guid id);
    }
}
