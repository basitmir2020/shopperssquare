namespace Shoppers_Square.IRepositories
{
    public interface IEntityBase
    {
        int Id{get; set;}
        int isDelete { get; set; }
        string Slug { get; set; }
        int isActive { get; set; }
    }
}
