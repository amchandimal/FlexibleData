using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using FlexibleDataApplication.Services.Util;

namespace FlexibleDataApplication.Services
{
    public class FlexibleDataService : IFlexibleDataService
    {
        private readonly IFlexibleDataRepository flexibleDataRepository;

        public FlexibleDataService(IFlexibleDataRepository flexibleDataRepository)
        {
            this.flexibleDataRepository = flexibleDataRepository ?? throw new ArgumentNullException(nameof(flexibleDataRepository));
        }

        public async Task<bool> DeleteById(int id)
        {
            return await flexibleDataRepository.DeleteByIdAsync(id);
        }

        public async Task<FlexibleData> FindById(int id)
        {
            return await flexibleDataRepository.FindByIdAsync(id);
        }

        public async Task<ICollection<FlexibleData>> GetAll()
        {
            return await flexibleDataRepository.GetAllAsync();
        }

        public async Task<ICollection<FlexibleData>> Save(ICollection<FlexibleData> flexibleData)
        {
            foreach (var item in flexibleData)
            {
                await flexibleDataRepository.AddFlexibleDataAsync(item);
            }
            return flexibleData;
        }
    }
}
