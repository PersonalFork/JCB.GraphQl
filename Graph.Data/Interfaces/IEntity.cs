namespace Graph.Data.Interfaces
{
    public interface IEntity<TId>
    {
        TId? Id { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}