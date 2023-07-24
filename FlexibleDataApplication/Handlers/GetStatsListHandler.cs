using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Repositories;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class GetStatsListHandler : IRequestHandler<GetStatsListQuery, List<Statistics>>
    {
        private readonly IStatisticsDataRepository statisticsDataRepository;

        public GetStatsListHandler(IStatisticsDataRepository statisticsDataRepository)
        {
            this.statisticsDataRepository = statisticsDataRepository ?? throw new ArgumentNullException(nameof(statisticsDataRepository));
        }

        public Task<List<Statistics>> Handle(GetStatsListQuery request, CancellationToken cancellationToken)
        {
            return statisticsDataRepository.GetAllAsync();
        }
    }
}
