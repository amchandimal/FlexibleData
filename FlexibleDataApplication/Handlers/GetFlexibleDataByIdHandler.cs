using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Repositories;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class GetFlexibleDataByIdHandler : IRequestHandler<GetFlexibleDataByIdQuery, FlexibleData>
    {
        private readonly IFlexibleDataRepository flexibleDataRepository;

        public GetFlexibleDataByIdHandler(IFlexibleDataRepository flexibleDataRepository)
        {
            this.flexibleDataRepository = flexibleDataRepository ?? throw new ArgumentNullException(nameof(flexibleDataRepository));
        }

        public Task<FlexibleData> Handle(GetFlexibleDataByIdQuery request, CancellationToken cancellationToken)
        {

            return flexibleDataRepository.FindByIdAsync(request.Id);
        }
    }
}
