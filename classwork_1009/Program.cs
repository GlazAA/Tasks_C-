using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace classwork_1009
{
    internal class Program
    {
        SqlConnection conn = null;

        //конструктор, на который опиирается вся реализация внутри
        public Program()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = library; Integrated Security = True;";

        }

        static void Main(string[] args)
        {

            Program pr = new Program();
            pr.InsertQuery();
            //pr.ReadData();

        }



        // объекты класса через конструктор создают подключение
        // статический метод не привязан к классу. 
        public void InsertQuery()
        {
            try
            {
                //открыть соединение
                conn.Open();
                //подготовить запрос insert
                // в переменной типа string 
                string insertString = @" insert into Authors (FirstName, LastName) values ('Mickle', 'Black')";
                // создать объект command 
                // инициировав оба св-ва
                SqlCommand cmd = new SqlCommand(insertString, conn);

                // выполнить запрос, занесенный в объект command 
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
            finally
            {
                //закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void ReadData()
        {
            SqlDataReader rdr = null;
            try
            {
                conn.Open(); // открыли соединение

                SqlCommand cmd = new SqlCommand("SELECT * FROM Authors", conn);

                // выполните запрос и получите SqlDataReader
                rdr = cmd.ExecuteReader();

                // извлечь полученные строки 
                if (!rdr.HasRows)
                {
                    Console.WriteLine("Нет данных в таблице Authors.");
                }

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + ")" + rdr[1] + " " + rdr[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                // закройте reader 
                if (rdr != null)
                {
                    rdr.Close();
                }
                // закройте соединение 
                if (conn != null)
                {
                    conn.Close();
                }
            }
            
            
        }
        

    }
}
