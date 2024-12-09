using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
namespace RYDesign.AspNetCore
{
    [DependsOn(new Type[] { 
        typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreMvcModule)
    })]
    public class RYDesignAspNetCoreModule:AbpModule
    {

    }
}
