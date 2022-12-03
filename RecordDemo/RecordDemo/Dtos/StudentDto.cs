namespace RecordDemo.Dtos;

public record StudentDto(Guid StudentId, string StudentName, [property: JsonIgnore] Gender Gender, List<CourseDto> Courses);
