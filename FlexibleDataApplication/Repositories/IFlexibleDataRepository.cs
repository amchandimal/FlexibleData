using FlexibleDataApplication.Entities;

namespace FlexibleDataApplication.Repositories
{
    public interface IFlexibleDataRepository
    {
        public Task<FlexibleData> FindByIdAsync(int id);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<ICollection<FlexibleData>> GetAllAsync();
        public Task<FlexibleData> AddFlexibleDataAsync(FlexibleData data);
        Task<int> SaveChangesAsync();
    }
}
