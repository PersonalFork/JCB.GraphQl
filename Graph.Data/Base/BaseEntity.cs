using Graph.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Graph.Data.Base
{
    public class BaseEntity<TId> : IEntity<TId>
    {
        [Key]
        public TId Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}