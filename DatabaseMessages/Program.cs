using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMessages
{
    class Program
    {
        static void Main(string[] args)
        {
           
          
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("What do you want to do? Save, retrieve or exit?");
                string answer = Console.ReadLine().ToLower();

                if (answer == "save")
                {
                    Console.WriteLine("Type in the message you want to save");
                    string NewMessage = Console.ReadLine();
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=c:\users\tina\documents\visual studio 2015\Projects\DatabaseMessages\DatabaseMessages\Database1.mdf;Integrated Security=True");
                    SqlCommand command = new SqlCommand($"INSERT INTO[Table] (Message) VALUES('{NewMessage}'); SELECT @@Identity as ID", connection);
  

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Console.WriteLine("Your message # is: " + reader["ID"]);
                    }
                    reader.Close();
                    connection.Close();
                }

                else if (answer == "retrieve")
                {
                    Console.WriteLine("Type in the ID of the message you want to save?");
                    string userNumber = Console.ReadLine();
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=c:\users\tina\documents\visual studio 2015\Projects\DatabaseMessages\DatabaseMessages\Database1.mdf;Integrated Security=True");
                    SqlCommand command = new SqlCommand("SELECT (Message) FROM [Table] where ID=" + userNumber, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        reader.Read();
                        Console.WriteLine("Your message is: " + reader["Message"]);
                    }

                    else
                    {
                        Console.WriteLine("That message doesn't exist");
                    }

                    reader.Close();
                    connection.Close();

                }

                if (answer == "exit")
                {
                    Console.WriteLine("Okay, bye...");
                    looping = false;
                }
            }

            Console.ReadLine();
        }
    }
}
