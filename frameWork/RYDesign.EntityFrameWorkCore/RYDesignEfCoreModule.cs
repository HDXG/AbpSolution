using RYDesign.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RYDesign.EntityFrameWorkCore
{
    [DependsOn(new Type[] { 
        typeof(AbpEntityFrameworkCoreModule),
        typeof(RYDesignDomainModule)
    })]
    public class RYDesignEfCoreModule:AbpModule
    {

    }
}
