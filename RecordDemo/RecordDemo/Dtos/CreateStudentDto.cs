namespace RecordDemo.Dtos;

public record CreateStudentDto(
    string Name,
    Gender Gender,
    int Age,
    string HomeAddress,
    string Rating,
    List<CreateCourseDto> Courses);
