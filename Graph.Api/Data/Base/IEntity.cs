namespace Graph.Api.Data
{
    public interface IEntity<TId>
    {
        TId? Id { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}