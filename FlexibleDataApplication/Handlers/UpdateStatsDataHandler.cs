using FlexibleDataApplication.Commands;
using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Services;
using MediatR;

namespace FlexibleDataApplication.Handlers
{
    public class UpdateStatsDataHandler : IRequestHandler<UpdateStatsDataCommand>
    {
        private readonly IStatisticsBackgroundService statisticsService;

        public UpdateStatsDataHandler(IStatisticsBackgroundService statisticsService)
        {
            this.statisticsService = statisticsService ?? throw new ArgumentNullException(nameof(statisticsService));
        }

        public Task Handle(UpdateStatsDataCommand request, CancellationToken cancellationToken)
        {
           statisticsService.UpdateStats(request.Dict);
           return Task.CompletedTask;
        }
    }
}
