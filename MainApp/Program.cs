using Infrastructure.Models;
using Infrastructure.Services;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Система управления ===");
            Console.WriteLine("1. Управление студентами");
            Console.WriteLine("2. Управление группами");
            Console.WriteLine("3. Управление менторами");
            Console.WriteLine("4. Управление курсами");
            Console.WriteLine("5. Управление студент-группами");
            Console.WriteLine("6. Управление ментор-группами");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер действия: ");
            
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageStudents();
                    break;
                case "2":
                    ManageGroups();
                    break;
                case "3":
                    ManageMentors();
                    break;
                case "4":
                    ManageCourses();
                    break;
                case "5":
                    ManageStudentGroups();
                    break;
                case "6":
                    ManageMentorGroups();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter для продолжения...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageStudents()
    {
        var studentService = new StudentService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Управление студентами ===");
            Console.WriteLine("1. Показать всех студентов");
            Console.WriteLine("2. Найти студента по ID");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Обновить данные студента");
            Console.WriteLine("5. Удалить студента");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите действие: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var students = studentService.GetStudents();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.StudentId}: {student.FirstName} {student.LastName}");
                    }
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Введите ID студента: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var student = studentService.GetStudentById(studentId);
                        if (student != null)
                        {
                            Console.WriteLine($"ID: {student.StudentId}, Имя: {student.FirstName}, Фамилия: {student.LastName}");
                        }
                        else
                        {
                            Console.WriteLine("Студент не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    var newStudent = new Student();
                    Console.Write("Введите имя: ");
                    newStudent.FirstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    newStudent.LastName = Console.ReadLine();
                    Console.Write("Введите email: ");
                    newStudent.Email = Console.ReadLine();
                    Console.Write("Введите телефон: ");
                    newStudent.Phone = Console.ReadLine();
                    Console.Write("Введите адрес: ");
                    newStudent.Address = Console.ReadLine();
                    Console.Write("Введите дату рождения (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                    {
                        newStudent.BirthDate = birthDate;
                        if (studentService.AddStudent(newStudent))
                        {
                            Console.WriteLine("Студент успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при добавлении студента.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат даты.");
                    }
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Write("Введите ID студента для обновления: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var existingStudent = studentService.GetStudentById(updateId);
                        if (existingStudent != null)
                        {
                            Console.Write("Введите имя (текущее: {0}): ", existingStudent.FirstName);
                            existingStudent.FirstName = Console.ReadLine();
                            Console.Write("Введите фамилию (текущее: {0}): ", existingStudent.LastName);
                            existingStudent.LastName = Console.ReadLine();
                            // Аналогично для других полей...
                            if (studentService.UpdateStudent(existingStudent))
                            {
                                Console.WriteLine("Данные студента успешно обновлены.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка при обновлении данных студента.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Студент не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Write("Введите ID студента для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        if (studentService.DeleteStudent(deleteId))
                        {
                            Console.WriteLine("Студент успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при удалении студента.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    Console.ReadLine();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // Аналогичные методы для остальных сущностей
static void ManageGroups()
{
    var groupService = new GroupServices();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Управление группами ===");
        Console.WriteLine("1. Показать все группы");
        Console.WriteLine("2. Найти группу по ID");
        Console.WriteLine("3. Добавить группу");
        Console.WriteLine("4. Обновить данные группы");
        Console.WriteLine("5. Удалить группу");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var groups = groupService.GetGroups();
                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.GroupId}: {group.GroupName}, Курс: {group.CorseId}, Начало: {group.StartDate}, Конец: {group.EndDate}");
                }
                Console.ReadLine();
                break;

            case "2":
                Console.Write("Введите ID группы: ");
                if (int.TryParse(Console.ReadLine(), out int groupId))
                {
                    var group = groupService.GetGroupById(groupId);
                    if (group != null)
                    {
                        Console.WriteLine($"ID: {group.GroupId}, Название: {group.GroupName}, Курс: {group.CorseId}, Начало: {group.StartDate}, Конец: {group.EndDate}");
                    }
                    else
                    {
                        Console.WriteLine("Группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "3":
                var newGroup = new Group();
                Console.Write("Введите название группы: ");
                newGroup.GroupName = Console.ReadLine();
                Console.Write("Введите ID курса: ");
                if (int.TryParse(Console.ReadLine(), out int courseId))
                {
                    newGroup.CorseId = courseId;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для ID курса.");
                    Console.ReadLine();
                    break;
                }
                Console.Write("Введите дату начала (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    newGroup.StartDate = startDate;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для даты начала.");
                    Console.ReadLine();
                    break;
                }
                Console.Write("Введите дату окончания (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {
                    newGroup.EndDate = endDate;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для даты окончания.");
                    Console.ReadLine();
                    break;
                }

                if (groupService.AddGroup(newGroup))
                {
                    Console.WriteLine("Группа успешно добавлена.");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении группы.");
                }
                Console.ReadLine();
                break;

            case "4":
                Console.Write("Введите ID группы для обновления: ");
                if (int.TryParse(Console.ReadLine(), out int updateGroupId))
                {
                    var existingGroup = groupService.GetGroupById(updateGroupId);
                    if (existingGroup != null)
                    {
                        Console.Write("Введите название группы (текущее: {0}): ", existingGroup.GroupName);
                        existingGroup.GroupName = Console.ReadLine();
                        Console.Write("Введите ID курса (текущее: {0}): ", existingGroup.CorseId);
                        if (int.TryParse(Console.ReadLine(), out int updatedCourseId))
                        {
                            existingGroup.CorseId = updatedCourseId;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для ID курса.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите дату начала (текущее: {0}): ", existingGroup.StartDate);
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime updatedStartDate))
                        {
                            existingGroup.StartDate = updatedStartDate;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для даты начала.");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите дату окончания (текущее: {0}): ", existingGroup.EndDate);
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime updatedEndDate))
                        {
                            existingGroup.EndDate = updatedEndDate;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для даты окончания.");
                            Console.ReadLine();
                            break;
                        }

                        if (groupService.UpdateGroup(existingGroup))
                        {
                            Console.WriteLine("Данные группы успешно обновлены.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при обновлении данных группы.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "5":
                Console.Write("Введите ID группы для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int deleteGroupId))
                {
                    if (groupService.DeleteGroup(deleteGroupId))
                    {
                        Console.WriteLine("Группа успешно удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при удалении группы.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Неверный выбор.");
                Console.ReadLine();
                break;
        }
    }
}
static void ManageMentors()
{
    var mentorService = new MentorService();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Управление менторами ===");
        Console.WriteLine("1. Показать всех менторов");
        Console.WriteLine("2. Найти ментора по ID");
        Console.WriteLine("3. Добавить ментора");
        Console.WriteLine("4. Обновить данные ментора");
        Console.WriteLine("5. Удалить ментора");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var mentors = mentorService.GetMentors();
                foreach (var mentor in mentors)
                {
                    Console.WriteLine($"ID: {mentor.MentorId}, Имя: {mentor.FirstName}, Фамилия: {mentor.LastName}, Email: {mentor.Email}, Телефон: {mentor.Phone}, Адрес: {mentor.Address}, Дата рождения: {mentor.BirthDate}");
                }
                Console.ReadLine();
                break;

            case "2":
                Console.Write("Введите ID ментора: ");
                if (int.TryParse(Console.ReadLine(), out int mentorId))
                {
                    var mentor = mentorService.GetMentorById(mentorId);
                    if (mentor != null)
                    {
                        Console.WriteLine($"ID: {mentor.MentorId}, Имя: {mentor.FirstName}, Фамилия: {mentor.LastName}, Email: {mentor.Email}, Телефон: {mentor.Phone}, Адрес: {mentor.Address}, Дата рождения: {mentor.BirthDate}");
                    }
                    else
                    {
                        Console.WriteLine("Ментор не найден.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "3":
                var newMentor = new Mentor();
                Console.Write("Введите имя ментора: ");
                newMentor.FirstName = Console.ReadLine();
                Console.Write("Введите фамилию ментора: ");
                newMentor.LastName = Console.ReadLine();
                Console.Write("Введите email ментора: ");
                newMentor.Email = Console.ReadLine();
                Console.Write("Введите телефон ментора: ");
                newMentor.Phone = Console.ReadLine();
                Console.Write("Введите адрес ментора: ");
                newMentor.Address = Console.ReadLine();
                Console.Write("Введите дату рождения (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    newMentor.BirthDate = birthDate;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод даты.");
                    Console.ReadLine();
                    break;
                }

                if (mentorService.AddMentor(newMentor))
                {
                    Console.WriteLine("Ментор успешно добавлен.");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении ментора.");
                }
                Console.ReadLine();
                break;

            case "4":
                Console.Write("Введите ID ментора для обновления: ");
                if (int.TryParse(Console.ReadLine(), out int updateMentorId))
                {
                    var existingMentor = mentorService.GetMentorById(updateMentorId);
                    if (existingMentor != null)
                    {
                        Console.Write("Введите имя ментора (текущее: {0}): ", existingMentor.FirstName);
                        existingMentor.FirstName = Console.ReadLine();
                        Console.Write("Введите фамилию ментора (текущее: {0}): ", existingMentor.LastName);
                        existingMentor.LastName = Console.ReadLine();
                        Console.Write("Введите email ментора (текущее: {0}): ", existingMentor.Email);
                        existingMentor.Email = Console.ReadLine();
                        Console.Write("Введите телефон ментора (текущее: {0}): ", existingMentor.Phone);
                        existingMentor.Phone = Console.ReadLine();
                        Console.Write("Введите адрес ментора (текущее: {0}): ", existingMentor.Address);
                        existingMentor.Address = Console.ReadLine();
                        Console.Write("Введите дату рождения (текущее: {0}): ", existingMentor.BirthDate);
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime updatedBirthDate))
                        {
                            existingMentor.BirthDate = updatedBirthDate;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод даты.");
                            Console.ReadLine();
                            break;
                        }

                        if (mentorService.UpdateMentor(existingMentor))
                        {
                            Console.WriteLine("Данные ментора успешно обновлены.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при обновлении данных ментора.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ментор не найден.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "5":
                Console.Write("Введите ID ментора для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int deleteMentorId))
                {
                    if (mentorService.DeleteMentor(deleteMentorId))
                    {
                        Console.WriteLine("Ментор успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при удалении ментора.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Неверный выбор.");
                Console.ReadLine();
                break;
        }
    }
}
static void ManageCourses()
{
    var courseService = new CorseService();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Управление курсами ===");
        Console.WriteLine("1. Показать все курсы");
        Console.WriteLine("2. Найти курс по ID");
        Console.WriteLine("3. Добавить курс");
        Console.WriteLine("4. Обновить данные курса");
        Console.WriteLine("5. Удалить курс");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var courses = courseService.GetCourses();
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: {course.CourseId}, Название: {course.CourseName}, Описание: {course.CourseDescription}");
                }
                Console.ReadLine();
                break;

            case "2":
                Console.Write("Введите ID курса: ");
                if (int.TryParse(Console.ReadLine(), out int courseId))
                {
                    var course = courseService.GetCourseById(courseId);
                    if (course != null)
                    {
                        Console.WriteLine($"ID: {course.CourseId}, Название: {course.CourseName}, Описание: {course.CourseDescription}");
                    }
                    else
                    {
                        Console.WriteLine("Курс не найден.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "3":
                var newCourse = new Course();
                Console.Write("Введите название курса: ");
                newCourse.CourseName = Console.ReadLine();
                Console.Write("Введите описание курса: ");
                newCourse.CourseDescription = Console.ReadLine();

                if (courseService.AddCourse(newCourse))
                {
                    Console.WriteLine("Курс успешно добавлен.");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении курса.");
                }
                Console.ReadLine();
                break;

            case "4":
                Console.Write("Введите ID курса для обновления: ");
                if (int.TryParse(Console.ReadLine(), out int updateCourseId))
                {
                    var existingCourse = courseService.GetCourseById(updateCourseId);
                    if (existingCourse != null)
                    {
                        Console.Write("Введите новое название курса (текущее: {0}): ", existingCourse.CourseName);
                        existingCourse.CourseName = Console.ReadLine();
                        Console.Write("Введите новое описание курса (текущее: {0}): ", existingCourse.CourseDescription);
                        existingCourse.CourseDescription = Console.ReadLine();

                        if (courseService.UpdateCourse(existingCourse))
                        {
                            Console.WriteLine("Данные курса успешно обновлены.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при обновлении данных курса.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Курс не найден.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "5":
                Console.Write("Введите ID курса для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int deleteCourseId))
                {
                    if (courseService.DeleteCourse(deleteCourseId))
                    {
                        Console.WriteLine("Курс успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при удалении курса.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Неверный выбор.");
                Console.ReadLine();
                break;
        }
    }
}
static void ManageStudentGroups()
{
    var studentGroupService = new StudentGroupService();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Управление студент-группами ===");
        Console.WriteLine("1. Показать все студент-группы");
        Console.WriteLine("2. Найти студент-группу по ID");
        Console.WriteLine("3. Добавить студент-группу");
        Console.WriteLine("4. Обновить данные студент-группы");
        Console.WriteLine("5. Удалить студент-группу");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var studentGroups = studentGroupService.GetStudentGroups();
                foreach (var studentGroup in studentGroups)
                {
                    Console.WriteLine($"ID: {studentGroup.StudentGroupId}, {studentGroup.GroupId}");
                }
                Console.ReadLine();
                break;

            case "2":
                Console.Write("Введите ID студент-группы: ");
                if (int.TryParse(Console.ReadLine(), out int studentGroupId))
                {
                    var studentGroup = studentGroupService.GetStudentGroupById(studentGroupId);
                    if (studentGroup != null)
                    {
                        Console.WriteLine($"ID: {studentGroup.StudentGroupId}, GroupId: {studentGroup.GroupId}");
                    }
                    else
                    {
                        Console.WriteLine("Студент-группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "3":
                var newStudentGroup = new StudentGroup();
                Console.Write("Введите MentorId: ");

                Console.Write("Введите GroupId: ");
                if (int.TryParse(Console.ReadLine(), out int groupId))
                {
                    newStudentGroup.GroupId = groupId;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод GroupId.");
                    Console.ReadLine();
                    break;
                }

                if (studentGroupService.AddStudentGroup(newStudentGroup))
                {
                    Console.WriteLine("Студент-группа успешно добавлена.");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении студент-группы.");
                }
                Console.ReadLine();
                break;

            case "4":
                Console.Write("Введите ID студент-группы для обновления: ");
                if (int.TryParse(Console.ReadLine(), out int updateStudentGroupId))
                {
                    var existingStudentGroup = studentGroupService.GetStudentGroupById(updateStudentGroupId);
                    if (existingStudentGroup != null)
                    {
                        Console.Write("Введите новый GroupId (текущее: {0}): ", existingStudentGroup.GroupId);
                        if (int.TryParse(Console.ReadLine(), out int updatedGroupId))
                        {
                            existingStudentGroup.GroupId = updatedGroupId;
                        }

                        if (studentGroupService.UpdateStudentGroup(existingStudentGroup))
                        {
                            Console.WriteLine("Данные студент-группы успешно обновлены.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при обновлении данных студент-группы.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Студент-группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "5":
                Console.Write("Введите ID студент-группы для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int deleteStudentGroupId))
                {
                    if (studentGroupService.DeleteStudentGroup(deleteStudentGroupId))
                    {
                        Console.WriteLine("Студент-группа успешно удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при удалении студент-группы.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Неверный выбор.");
                Console.ReadLine();
                break;
        }
    }
}
static void ManageMentorGroups()
{
    var mentorGroupService = new MentorGroupService();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Управление ментор-группами ===");
        Console.WriteLine("1. Показать все ментор-группы");
        Console.WriteLine("2. Найти ментор-группу по ID");
        Console.WriteLine("3. Добавить ментор-группу");
        Console.WriteLine("4. Обновить данные ментор-группы");
        Console.WriteLine("5. Удалить ментор-группу");
        Console.WriteLine("0. Назад");
        Console.Write("Выберите действие: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var mentorGroups = mentorGroupService.GetMentorGroup();
                foreach (var mentorGroup in mentorGroups)
                {
                    Console.WriteLine($"ID: {mentorGroup.MentorGroupId}, MentorId: {mentorGroup.MentorId}, GroupId: {mentorGroup.GroupId}");
                }
                Console.ReadLine();
                break;

            case "2":
                Console.Write("Введите ID ментор-группы: ");
                if (int.TryParse(Console.ReadLine(), out int mentorGroupId))
                {
                    var mentorGroup = mentorGroupService.GetMentorGroupById(mentorGroupId);
                    if (mentorGroup != null)
                    {
                        Console.WriteLine($"ID: {mentorGroup.MentorGroupId}, MentorId: {mentorGroup.MentorId}, GroupId: {mentorGroup.GroupId}");
                    }
                    else
                    {
                        Console.WriteLine("Ментор-группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "3":
                var newMentorGroup = new MentorGroup();
                Console.Write("Введите MentorId: ");
                if (int.TryParse(Console.ReadLine(), out int mentorId))
                {
                    newMentorGroup.MentorId = mentorId;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод MentorId.");
                    Console.ReadLine();
                    break;
                }

                Console.Write("Введите GroupId: ");
                if (int.TryParse(Console.ReadLine(), out int groupId))
                {
                    newMentorGroup.GroupId = groupId;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод GroupId.");
                    Console.ReadLine();
                    break;
                }

                if (mentorGroupService.AddMentorGroup(newMentorGroup))
                {
                    Console.WriteLine("Ментор-группа успешно добавлена.");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении ментор-группы.");
                }
                Console.ReadLine();
                break;

            case "4":
                Console.Write("Введите ID ментор-группы для обновления: ");
                if (int.TryParse(Console.ReadLine(), out int updateMentorGroupId))
                {
                    var existingMentorGroup = mentorGroupService.GetMentorGroupById(updateMentorGroupId);
                    if (existingMentorGroup != null)
                    {
                        Console.Write("Введите новый MentorId (текущее: {0}): ", existingMentorGroup.MentorId);
                        if (int.TryParse(Console.ReadLine(), out int updatedMentorId))
                        {
                            existingMentorGroup.MentorId = updatedMentorId;
                        }

                        Console.Write("Введите новый GroupId (текущее: {0}): ", existingMentorGroup.GroupId);
                        if (int.TryParse(Console.ReadLine(), out int updatedGroupId))
                        {
                            existingMentorGroup.GroupId = updatedGroupId;
                        }

                        if (mentorGroupService.UpdateMentorGroup(existingMentorGroup))
                        {
                            Console.WriteLine("Данные ментор-группы успешно обновлены.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка при обновлении данных ментор-группы.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ментор-группа не найдена.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "5":
                Console.Write("Введите ID ментор-группы для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int deleteMentorGroupId))
                {
                    if (mentorGroupService.DeleteMentorGroup(deleteMentorGroupId))
                    {
                        Console.WriteLine("Ментор-группа успешно удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при удалении ментор-группы.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }
                Console.ReadLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Неверный выбор.");
                Console.ReadLine();
                break;
        }
    }
}
}
