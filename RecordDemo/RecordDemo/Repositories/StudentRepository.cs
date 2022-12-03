namespace RecordDemo.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly RecordDemoDbContext _dbContext;
    private readonly IMapper _mapper;

    public StudentRepository(RecordDemoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<StudentDto>> GetStudentsInfoAsync()
    {
        return await _dbContext.Students
            .Include(s => s.Courses)
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        // return await _dbContext.Students
        //     .Include(s => s.Courses)
        //     .ProjectToType<StudentDto>()
        //     .ToListAsync();
    }

    public async Task<StudentDto> GetStudentDetailAsync(Guid id)
    {
        return await _dbContext.Students
            .Include(s => s.Courses)
            .Where(s => s.Id == id)
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<StudentDto> AddStudentAsync(CreateStudentDto createStudentDto)
    {
        var student = _mapper.Map<Student>(createStudentDto);

        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<StudentDto>(student);
    }
}
