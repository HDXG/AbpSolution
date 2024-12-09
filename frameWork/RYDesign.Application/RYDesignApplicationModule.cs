using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RYDesign.Application
{
    [DependsOn(new Type[] { 
        typeof(AbpDddApplicationModule)
    })]
    public class RYDesignApplicationModule:AbpModule
    {

    }
}
