using System;
using System.Data;
using System.Data.SqlClient;

namespace ExamADO
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=.;database=trippy;integrated security=SSPI");
            con.Open();
            var command = new SqlCommand();
            command.Connection = con;

            //command.CommandText = "Create Table Employee (id int not null primary key, name varchar(40), age int)";
            // command.ExecuteNonQuery();
            Console.WriteLine("Press: 1=Inserting Value 2=Show Table Data 3=Delete Data 4=Update");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.WriteLine("ID:");
                    int id= int.Parse(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Age:");
                    int age = int.Parse(Console.ReadLine());
                    command.CommandText="insert into employee values("+id+",'"+name+"','"+age+"')";
                    command.ExecuteNonQuery();
                    break;

                case 2:
                    command.CommandText = "Select * from employee";
                    SqlDataReader sdr = command.ExecuteReader();
                    Console.WriteLine("ID   Age  Name");
                    while (sdr.Read()) {
                        Console.WriteLine(sdr["id"]+"  "+sdr["age"]+"   "+sdr["name"]);
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter ID to delete:");
                    int did = int.Parse(Console.ReadLine());
                    command.CommandText = "delete from employee where id='" + did + "'";
                    command.ExecuteNonQuery();
                    break;

                case 4:
                    Console.WriteLine("Enter ID to Update:");
                    int uid = int.Parse(Console.ReadLine());
                    Console.WriteLine("New ID:");
                    int nid = int.Parse(Console.ReadLine());
                    Console.WriteLine("New Name:");
                    string nname = Console.ReadLine();
                    Console.WriteLine("New Age:");
                    int nage = int.Parse(Console.ReadLine());
                    command.CommandText="update employee set id="+nid+",name='"+nname+"',age="+nage+"  where id='"+uid+"'";
                    
                    command.ExecuteNonQuery();
                    break;

               
            }
        }
    }
}
