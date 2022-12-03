namespace RecordDemo.Data;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string TeacherName { get; set; }
    public int Duration { get; set; }

    public ICollection<Student> Students { get; set; }
}
