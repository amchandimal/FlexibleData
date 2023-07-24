using FlexibleDataApplication.Entities;
using MediatR;

namespace FlexibleDataApplication.Queries
{
    public record GetFlexibleDataListQuery():IRequest<List<FlexibleData>>;
    public record GetFlexibleDataByIdQuery(int Id) : IRequest<FlexibleData>;
    public record GetStatsListQuery() : IRequest<List<Statistics>>;
    public record GetStatsByIDQuery(string Key) : IRequest<Statistics>;
}
