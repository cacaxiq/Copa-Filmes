using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Infra.Commands
{
	public interface ICommandHandler<T> where T : ICommand
	{
		ICommandResult Handle(T command);
	}
}
