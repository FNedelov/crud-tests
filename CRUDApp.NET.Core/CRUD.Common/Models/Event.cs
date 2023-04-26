namespace CRUD.Common.Models;

public partial class Event
{
    public int Id { get; set; }

    public int Type { get; set; }

    public string UserName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}