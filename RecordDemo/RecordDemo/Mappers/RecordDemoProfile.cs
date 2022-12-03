namespace RecordDemo.Mappers;

public class RecordDemoProfile : Profile
{
    public RecordDemoProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForCtorParam("CourseId", opt => opt.MapFrom(src => src.Id));

        CreateMap<Student, StudentDto>()
            .ForCtorParam("StudentId", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("StudentName", opt => opt.MapFrom(src => src.Name));

        CreateMap<CreateCourseDto, Course>();
        CreateMap<CreateStudentDto, Student>();
    }
}
