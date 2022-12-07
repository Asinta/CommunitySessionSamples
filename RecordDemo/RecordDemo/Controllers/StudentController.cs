namespace RecordDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDto>>> GetStudentsInfo()
    {
        return await _studentRepository.GetStudentsInfoAsync();
    }
    
    [HttpGet("{id:guid}", Name = "GetSingleStudent")]
    public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
    {
        var student = await _studentRepository.GetStudentDetailAsync(id);
        Console.WriteLine($"{student.Gender}, {student.StudentName}");

        return student;
    }
    
    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] CreateStudentDto createStudentDto)
    {
        var student = await _studentRepository.AddStudentAsync(createStudentDto);

        return CreatedAtRoute("GetSingleStudent", new { id = student.StudentId }, student);
    }
}
