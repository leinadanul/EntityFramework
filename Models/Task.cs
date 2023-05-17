namespace projectef.Model;

public class Task
{
    public Guid TaskId {get;set;}

    public Guid CategoryId {get;set;}

    public string Title {get;set;}

    public string Description {get;set;}

    public Priority TaskPrority {get;set;}

    public DateTime DateCreation {get;set;}

    public virtual Category Category {get;set;}

}

public enum Priority

{
    Low, 
    Medium,
    High
}