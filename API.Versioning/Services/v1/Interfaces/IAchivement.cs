using API.Versioning.Models.v1;

namespace API.Versioning.Services.v1.Interfaces
{
    public interface IAchivement
    {
        Task<AchivementInfo> CreateOrUpdateAchivement(AchivementInfo model);
        Task<string> DeleteAchivement(Guid id);
        Task<IEnumerable<AchivementVm>> GetAchivementsByDriverId(Guid id);
    }
}
