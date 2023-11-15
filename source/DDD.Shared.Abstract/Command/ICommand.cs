using MediatR;

namespace DDD.Shared.Abstract.Command;

public interface ICommand<out TResponse> : IRequest<TResponse> { }
public interface ICommand : IRequest { }
