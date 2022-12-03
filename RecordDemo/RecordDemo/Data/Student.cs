namespace RecordDemo.Data;

public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string HomeAddress { get; set; }
    public string Rating { get; set; }

    public ICollection<Course> Courses { get; set; }
}
