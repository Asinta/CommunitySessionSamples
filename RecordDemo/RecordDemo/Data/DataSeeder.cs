namespace RecordDemo.Data;

public static class DataSeeder
{
    public static async Task SeedDataAsync(this RecordDemoDbContext context)
    {
        var courses = new List<Course>
        {
            new() { Id = Guid.NewGuid(), Duration = 24, Name = "Math", TeacherName = "Math teacher" },
            new() { Id = Guid.NewGuid(), Duration = 40, Name = "English", TeacherName = "English teacher" },
            new() { Id = Guid.NewGuid(), Duration = 28, Name = "History", TeacherName = "History teacher" },
            new() { Id = Guid.NewGuid(), Duration = 36, Name = "Programming", TeacherName = "Programming teacher" },
            new() { Id = Guid.NewGuid(), Duration = 32, Name = "Physics", TeacherName = "Physics teacher" }
        };

        if (!context.Courses.Any())
        {
            context.Courses.AddRange(courses);
        }
        
        if (!context.Students.Any())
        {
            var students = new List<Student>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Age = 21,
                    Gender = Gender.Male,
                    Name = "Zhang san",
                    HomeAddress = "Fake home address for Zhang san",
                    Rating = "A",
                    Courses = new List<Course> { courses[0], courses[1], courses[3] }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Age = 22,
                    Gender = Gender.Female,
                    Name = "Li si",
                    HomeAddress = "Fake home address for Li si",
                    Rating = "A+",
                    Courses = new List<Course> { courses[0], courses[1], courses[2], courses[3], courses[4] }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Age = 21,
                    Gender = Gender.Male,
                    Name = "Wang wu",
                    HomeAddress = "Fake home address for Wang wu",
                    Rating = "B+",
                    Courses = new List<Course> { courses[2], courses[3] }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Age = 20,
                    Gender = Gender.Male,
                    Name = "Zhao liu",
                    HomeAddress = "Fake home address for Zhao liu",
                    Rating = "B-",
                    Courses = new List<Course> { courses[4] }
                }
            };
            
            context.Students.AddRange(students);
        }

        await context.SaveChangesAsync();
    }
}
