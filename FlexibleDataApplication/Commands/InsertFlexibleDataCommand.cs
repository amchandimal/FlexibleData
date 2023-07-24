using FlexibleDataApplication.Entities;
using MediatR;

namespace FlexibleDataApplication.Commands
{
    public record InsertFlexibleDataCommand(FlexibleData Data):IRequest<FlexibleData>;
}
