namespace RecordDemo.Mappers;

public class RecordDemoRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Course, CourseDto>()
            .Map(dest => dest.CourseId, src => src.Id);

        config.ForType<Student, StudentDto>()
            .Map(dest => dest.StudentId, src => src.Id)
            .Map(dest => dest.StudentName, src => src.Name);
    }
}
