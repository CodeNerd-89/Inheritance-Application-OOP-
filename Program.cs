using System;

class Student
{
    private int student_id;
    private string name;
    protected int contact_number;

    public int StudentID
    {
        get { return student_id; }
        set { student_id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ContactNumber
    {
        get { return contact_number; }
        set { contact_number = value; }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Student ID: {student_id}, Name: {name}, Contact Number: {contact_number}");
    }
}

class Admin : Student
{
    private List<Student> students;

    public Admin()
    {
        students = new List<Student>();
    }

    public void AddStudent(int id, string name, int contactNo)
    {
        Student student = new Student
        {
            StudentID = id,
            Name = name,
            ContactNumber = contactNo
        };
        students.Add(student);
        Console.WriteLine("Student added successfully!\n");
    }

    public void ShowAllStudents()
    {
        Console.WriteLine("Student Summary:");
        for (int i = 0; i < students.Count; i++)
        {
            students[i].ShowInfo();
        }
        Console.WriteLine();
    }

    public void SearchStudent(string keyword)
    {
        Console.WriteLine("Search Results:");
        bool found = false;
        
        for (int i = 0; i < students.Count; i++)
        {
            Student student = students[i];
            if (student.StudentID.ToString() == keyword || student.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase) || student.ContactNumber.ToString() == keyword)
            {
                student.ShowInfo();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.\n");
        }
        else
        {
            Console.WriteLine();
        }
    }

    public void UpdateContactNumber(int id, int newContactNo)
    {
        bool updated = false;
        
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].StudentID == id)
            {
                students[i].ContactNumber = newContactNo;
                Console.WriteLine("Contact number updated successfully!\n");
                updated = true;
                break; 
            }
        }

        if (!updated)
        {
            Console.WriteLine("Student with the given ID not found.\n");
        }
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Student Summary");
            Console.WriteLine("3. Search Student Details by ID, Name, Contact Number");
            Console.WriteLine("4. Update Contact Number using ID");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            
            string input = Console.ReadLine();
            int choice;
            
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 5.\n");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Student ID: ");
                    string idInput = Console.ReadLine();
                    int id;
                    if (!int.TryParse(idInput, out id))
                    {
                        Console.WriteLine("Invalid ID! Please enter a numeric value.\n");
                        break;
                    }

                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Contact Number: ");
                    string contactInput = Console.ReadLine();
                    int contactNo;
                    if (!int.TryParse(contactInput, out contactNo))
                    {
                        Console.WriteLine("Invalid Contact Number! Please enter a numeric value.\n");
                        break;
                    }

                    AddStudent(id, name, contactNo);
                    break;

                case 2:
                    ShowAllStudents();
                    break;

                case 3:
                    Console.Write("Enter Student ID, Name, or Contact Number to search: ");
                    string keyword = Console.ReadLine();
                    SearchStudent(keyword);
                    break;

                case 4:
                    Console.Write("Enter Student ID to update contact number: ");
                    string searchIdInput = Console.ReadLine();
                    int searchId;
                    if (!int.TryParse(searchIdInput, out searchId))
                    {
                        Console.WriteLine("Invalid ID! Please enter a numeric value.\n");
                        break;
                    }

                    Console.Write("Enter new Contact Number: ");
                    string newContactInput = Console.ReadLine();
                    int newContactNo;
                    if (!int.TryParse(newContactInput, out newContactNo))
                    {
                        Console.WriteLine("Invalid Contact Number! Please enter a numeric value.\n");
                        break;
                    }

                    UpdateContactNumber(searchId, newContactNo);
                    break;

                case 5:
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.\n");
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Admin admin = new Admin();
        admin.Menu();
    }
}
