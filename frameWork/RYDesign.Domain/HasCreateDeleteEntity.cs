using Volo.Abp.Domain.Entities;

namespace RYDesign.Domain
{
    public class HasCreateDeleteEntity<TKey> : Entity<TKey>
    {
        /// <summary>
        /// 删除状态判断
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public HasCreateDeleteEntity(TKey key) : base(key)
        {

        }
    }
}
