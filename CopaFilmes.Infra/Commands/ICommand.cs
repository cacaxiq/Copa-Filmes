using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Infra.Commands
{
	public interface ICommand
	{
		bool Valid();
	}
}
