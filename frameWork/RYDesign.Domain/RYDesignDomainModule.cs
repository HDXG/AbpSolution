using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RYDesign.Domain
{
    [DependsOn(new Type[] { 
        typeof(AbpDddDomainModule)
    })]
    public class RYDesignDomainModule:AbpModule
    {

    }
}
