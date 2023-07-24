using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Repositories;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class GetFlexibleDataListHandler : IRequestHandler<GetFlexibleDataListQuery, List<FlexibleData>>
    {
        private readonly IFlexibleDataRepository flexibleDataRepository;

        public GetFlexibleDataListHandler(IFlexibleDataRepository flexibleDataRepository)
        {
            this.flexibleDataRepository = flexibleDataRepository ?? throw new ArgumentNullException(nameof(flexibleDataRepository));
        }

        public Task<List<FlexibleData>> Handle(GetFlexibleDataListQuery request, CancellationToken cancellationToken)
        {
            return flexibleDataRepository.GetAllAsync();
        }
    }
}
