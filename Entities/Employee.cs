namespace linqExercise.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string n, string e, double s)
        {
            Name = n;
            Email = e;
            Salary = s;
        }
    }
}