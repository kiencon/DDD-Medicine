using MediatR;
namespace DDD.Shared.Abstract.Command;

public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse> {}

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand { }
