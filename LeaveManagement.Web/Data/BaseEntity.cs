namespace LeaveManagement.Web.Data;

//abstract - it cannot stay by its own
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
