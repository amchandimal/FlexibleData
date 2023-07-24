using MediatR;

namespace FlexibleDataApplication.Commands
{
    public record UpdateStatsDataCommand(Dictionary<string, string> Dict):IRequest;
}
