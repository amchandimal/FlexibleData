using FlexibleDataApplication.Entities;

namespace FlexibleDataApplication.Repositories
{
    public interface IFlexibleDataRepository
    {
        Task<FlexibleData> FindByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<ICollection<FlexibleData>> GetAllAsync();
        Task<FlexibleData> AddFlexibleDataAsync(FlexibleData data);
        Task<int> SaveChangesAsync();
    }
}
