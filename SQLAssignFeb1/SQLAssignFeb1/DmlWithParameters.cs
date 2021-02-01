using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLAssignFeb1
{
    class DmlWithParameters
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertWithOutParameters()
        {
            try
            {

                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();
                Console.WriteLine("enter Employee salary");
                var salary = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("enter Employee departmentid");
                var deptno = Convert.ToInt32(Console.ReadLine());

                con = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeTab values('" + empname + "'," + salary + "," + deptno + ")", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to the table");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }
        }


        public int UpateWithOutParameters()
        {
            try
            {
                Console.WriteLine("updating name by id-------");
                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();
                Console.WriteLine("enter Employee id");
                var empid = int.Parse(Console.ReadLine());

                con = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update EmployeeTab set empname=('" + empname + "')" + "where empid=(" + empid + ")", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to the table");
                ShowData();
                return i;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteWithOutParameters()
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                Console.WriteLine("enter Employee id to delete");
                var empid = int.Parse(Console.ReadLine());
                cmd = new SqlCommand("Delete from Employeetab where empid=(" + empid + ")", con);
                con.Open();
                int j = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted in the the table");
                ShowData();
                return j;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }

        }
        public int SearchWithOutParameters()
        {

            try
            {
                Console.WriteLine("enter Employee id to search");
                var empid = int.Parse(Console.ReadLine());
                con = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab where empid=(" + empid + ")", con);
                con.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Console.WriteLine($"{dr["empname"]}\t {dr["salary"]}\t {dr["deptno"]}");

                }
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        public int ShowData()
        {
            try
            {


                Console.WriteLine("Data from the table after the dML Command");
                con = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t{dr["empname"]}\t {dr["salary"]}\t {dr["deptno"]}");
                }
                return 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
    }
    class program1
    {
        static void Main()
        {
            int opt;
            DmlWithParameters dwp = new DmlWithParameters();

            do
            {
                Console.WriteLine("Choose an operation to perfom");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                Console.WriteLine("4.Search");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Insert operation");
                        dwp.InsertWithOutParameters();
                        break;
                    case 2:
                        Console.WriteLine("Update operation");
                        dwp.UpateWithOutParameters();
                        break;
                    case 3:
                        Console.WriteLine("Delete operation");
                        dwp.DeleteWithOutParameters();
                        break;
                    case 4:
                        Console.WriteLine("Search operation");
                        dwp.SearchWithOutParameters();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Choose only between 1-4");
                        break;

                }
            } while (opt >= 1 && opt <= 4);
            Console.ReadLine();
        }
    }
}
    

