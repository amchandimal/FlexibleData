using FlexibleDataApplication.Entities;

namespace FlexibleDataApplication.Services
{
    public interface IFlexibleDataService
    {
        public Task<FlexibleData> FindById(int id);
        public Task<bool> DeleteById(int id);
        public Task<ICollection<FlexibleData>> GetAll();
        public Task<ICollection<FlexibleData>> Save(ICollection<FlexibleData> flexibleData);
    }
}
