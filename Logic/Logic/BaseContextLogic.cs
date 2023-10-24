using Data;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Logic
{
    public abstract class BaseContextLogic
    {
        protected readonly ServiceContext _serviceContext;
        protected BaseContextLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
    }
}