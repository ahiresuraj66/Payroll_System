
using System.Runtime.CompilerServices;
using System.Collections;
namespace Payroll_system
{
    public class Class_Employee
    {
        private static int Prev_Id = 0;
        protected int emp_Id;
        protected string emp_Name;
        protected decimal basic_sal;

        public int EmployeeId
        {
            get { return emp_Id; }
            set { emp_Id = value; }
        }

        public string EmployeeName
        {
            get { return emp_Name; }
            set { emp_Name = value; }
        }

        public decimal BasicSalary
        {
            get { return basic_sal; }
            set { basic_sal = value; }
        }

        public Class_Employee(string name, decimal salary)
        {
            Prev_Id++; 
            emp_Id = Prev_Id;
            emp_Name = name;
            basic_sal = salary;
        }

        public virtual decimal Calculate_Salary()
        {
            decimal deduction = basic_sal * 0.2m;
            return basic_sal - deduction;
        }
    }

    public class Class_Programmer : Class_Employee
    {
        private decimal hra;

        public Class_Programmer(string name, decimal salary) : base(name, salary)
        {
            hra = basic_sal * 0.05m;
        }

        public override decimal Calculate_Salary()
        {
            decimal deduction = basic_sal * 0.2m;
            return basic_sal - deduction + hra;
        }
    }

    public class Class_Sale_Exe : Class_Employee
    {
        private decimal travel_all;

        public Class_Sale_Exe(string name, decimal salary) : base(name, salary)
        {
            travel_all = basic_sal * 0.15m;
        }

        public override decimal Calculate_Salary()
        {
            decimal deduction = basic_sal * 0.2m;
            return basic_sal - deduction + travel_all;
        }
    }


    public class Class_Manager : Class_Employee
    {
        private decimal bonus;

        public Class_Manager(string name, decimal salary) : base(name, salary)
        {
            bonus = basic_sal * 0.1m;
        }

        public override decimal Calculate_Salary()
        {
            decimal deduction = basic_sal * 0.2m;
            return basic_sal - deduction + bonus;
        }
    }

 
    class Program
    {
        public static void Main()
        {
            ArrayList employees = new ArrayList();
            employees.Add(new Class_Programmer("Suraj", 20000m));
            employees.Add(new Class_Manager("Divesh", 40000m));
            Console.WriteLine("Payroll application to calculate the salary of an employee");
            while (true)
            {
                Console.WriteLine("Hey! Would you want to continue y/n");
                char chr = Console.ReadLine()[0];
                if(chr =='n' || chr=='N')
                {
                    break;
                }
                Console.WriteLine("press 1 to add an employee to the database");
                Console.WriteLine("press 2 to Print details of all employees");
                Console.WriteLine("press 3 to calculate the salary of all employees");
                int choice = Convert.ToInt32(Console.ReadLine());
                string temp_name;
                decimal temp_salary;
                int choice_for_des;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name:");
                        temp_name = Console.ReadLine();
                        Console.WriteLine("Enter Designation press 1 for programmer 2 for Manager 3 for sales sales executive");
                        choice_for_des = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter salary:");
                        temp_salary = Convert.ToInt32(Console.ReadLine());
                        if (choice_for_des == 1)
                        {
                            employees.Add(new Class_Programmer(temp_name, temp_salary));
                        }
                        else if (choice_for_des == 1)
                        {
                            employees.Add(new Class_Manager(temp_name, temp_salary));
                        }
                        else
                        {
                            employees.Add(new Class_Sale_Exe(temp_name, temp_salary));
                        }
                        break;
                    case 2:
                        foreach (Class_Employee emp in employees)
                        {
                            Console.WriteLine("Employee Name: {0}, Base Salary: {1}", emp.EmployeeName, emp.BasicSalary);
                        }
                        break;
                    case 3:
                        foreach (Class_Employee emp in employees)
                        {
                            Console.WriteLine("Employee ID: {0}, Employee Name: {1}, Salary: {2}", emp.EmployeeId, emp.EmployeeName, emp.Calculate_Salary());
                        }
                        break;
                }



            }


            
           
        }
    }
}




