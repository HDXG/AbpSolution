using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace RYDesign.EntityFrameWorkCore.EfCore
{
    public abstract class RYDesignContext<TDbContext>(DbContextOptions<TDbContext> options) : AbpDbContext<TDbContext>(options),IRYDesignContext
        where TDbContext : DbContext, IRYDesignContext
    {

    }
}
