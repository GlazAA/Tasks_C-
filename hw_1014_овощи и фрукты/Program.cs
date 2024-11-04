using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace test
{

    class Program
    {
        SqlConnection conn = null;
        public Program()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn = new SqlConnection(connectionString);

        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            //pr.InsertAuthorsQuery();
            //pr.InsertBooksQuery();
            //pr.ReadData();
            pr.ReadData2();
            //pr.ExecStoredProcedure();
        }

        /*internal class Program
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
            // статический метод не привязан к классу. */

        public void InsertQuery()
        {
            try
            {
                //открыть соединение
                conn.Open();
                //подготовить запрос insert
                // в переменной типа string 
                string insertString = @" insert into Books (AuthorId, Title, Price,Pages) values (2,'The Adventures of Tom Sawyer', 9.99, 275)";
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
                //открыть соединение
                conn.Open();
                //создать новый объект command с запросом select
                SqlCommand cmd = new SqlCommand("select * from Authors;", conn);
                //выполнить запрос select, сохранив
                //возвращенный результат
                rdr = cmd.ExecuteReader();
                //извлечь полученные строки
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + ") " + rdr[1] + " " + rdr[2]);
                }
            }
            finally
            {
                //закрыть reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                //закрыть соединение
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void ReadData2()
        {
            SqlDataReader rdr = null;
            try
            {
                //Open the connection
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Fruits_vegetables;", conn);
                rdr = cmd.ExecuteReader();
                int line = 0;
                //извлекаем полученные строки
                do
                {
                    while (rdr.Read())
                    {
                        if (line == 0) //формируем шапку таблицы перед выводом первой строки
                        {
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                Console.Write(rdr.GetName(i).ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                        line++;
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write(rdr[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Total records processed: " + line.ToString());
                    Console.WriteLine();
                    line = 0;
                } while (rdr.NextResult());

                Console.ReadKey();

            }
            finally
            {
                //close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




        /*  public void ExecStoredProcedure()
          {
              try
              {
                  conn.Open();
                  SqlCommand cmd = new SqlCommand("getBooksNumber", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add("@AuthorId", System.Data.SqlDbType.Int).Value = 1;

                  SqlParameter outputParam = new SqlParameter("@BookCount", System.Data.SqlDbType.Int);
                  outputParam.Direction = ParameterDirection.Output;
                  cmd.Parameters.Add(outputParam);

                  cmd.ExecuteNonQuery();
                  Console.WriteLine(cmd.Parameters["@BookCount"].Value.ToString());

              }

              catch (SqlException sqlEx)
              {
                  Console.WriteLine("Ошибка SQL: " + sqlEx.Message);
                  Console.ReadKey();
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Ошибка: " + ex.Message);
                  Console.ReadKey();
              }
              finally
              {
                  {
                      conn.Close();
                  }
              }

          }*/
    }

}
