using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Repositories;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class GetStatsByIdHandler : IRequestHandler<GetStatsByIDQuery, Statistics>
    {
        private readonly IStatisticsDataRepository statisticsDataRepository;

        public GetStatsByIdHandler(IStatisticsDataRepository statisticsDataRepository)
        {
            this.statisticsDataRepository = statisticsDataRepository ?? throw new ArgumentNullException(nameof(statisticsDataRepository));
        }

        public Task<Statistics> Handle(GetStatsByIDQuery request, CancellationToken cancellationToken)
        {
            return statisticsDataRepository.FindByIdAsync(request.Key);
        }
    }
}
