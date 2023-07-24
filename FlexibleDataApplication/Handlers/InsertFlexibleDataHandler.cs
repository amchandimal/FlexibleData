using FlexibleDataApplication.Commands;
using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class InsertFlexibleDataHandler : IRequestHandler<InsertFlexibleDataCommand, FlexibleData>
    {
        private readonly IFlexibleDataRepository flexibleDataRepository;

        public InsertFlexibleDataHandler(IFlexibleDataRepository flexibleDataRepository)
        {
            this.flexibleDataRepository = flexibleDataRepository ?? throw new ArgumentNullException(nameof(flexibleDataRepository));
        }

        public Task<FlexibleData> Handle(InsertFlexibleDataCommand request, CancellationToken cancellationToken)
        {
            return flexibleDataRepository.AddFlexibleDataAsync(request.Data);
        }
    }
}
