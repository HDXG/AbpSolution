using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RYDesign.Application.Contracts
{
    [DependsOn(new Type[] { 
        typeof(AbpDddApplicationContractsModule)
    })]
    public class RYDesignApplicationContractsModule:AbpModule
    {

    }
}
