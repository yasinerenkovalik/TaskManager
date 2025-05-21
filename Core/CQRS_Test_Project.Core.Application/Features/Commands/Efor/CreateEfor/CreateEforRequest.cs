using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.Efor.CreateEfor;

public class CreateEforRequest:IRequest<CreateEforResponse>
{
    public Guid UserId { get; set; }
    public Guid SubTaskId { get; set; }
    public double EforHour { get; set; }
}