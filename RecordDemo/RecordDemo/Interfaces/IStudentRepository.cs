namespace RecordDemo.Interfaces;

public interface IStudentRepository
{
    Task<List<StudentDto>> GetStudentsInfoAsync();
    Task<StudentDto> GetStudentDetailAsync(Guid id);
    Task<StudentDto> AddStudentAsync(CreateStudentDto createStudentDto);
}
