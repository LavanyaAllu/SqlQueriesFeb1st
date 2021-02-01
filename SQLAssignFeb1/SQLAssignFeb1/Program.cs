using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLAssignFeb1
{
    class DMLCommandsWithParameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int ShowData()
        {
            try
            {
                cn = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab", cn);
                cn.Open();
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
                return 0;

            }
            finally
            {
                cn.Close();
            }
        }
        public int InsertWithParameters()
        {
            try
            {
                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();
                Console.WriteLine("enter Employee salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("enter Employee departmentid");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeTab values(@empname,@salary,@deptno)", cn);
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
                cn.Open();
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
                cn.Close();
            }
        }
        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Emp Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Emp Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Emp dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update Employeetab set EmpName=@ename,Salary=@esal,DeptNo=@did where EmpId=@empid", cn);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row updated using parameters to the table");
                //ShowData();
                return i;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public void SearchWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from Employeetab where EmpId=@empid", cn);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eid;

                cn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpName"]}\t {dr["Salary"]}\t {dr["DeptNo"]}");
                }
                //ShowData();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                dr.Close();
                cn.Close();
            }

        }   
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-IKLNFH7;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from Employeetab where EmpId=@eid", cn);
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted using parameters to the table");
                //ShowData();
                return i;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DMLCommandsWithParameters dm = new DMLCommandsWithParameters();
            int option;
            do
            {
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.update");
                Console.WriteLine("3.Search");
                Console.WriteLine("4.delete");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: dm.InsertWithParameters(); break;
                    case 2: dm.UpdateWithParameters(); break;
                    case 3: dm.SearchWithParameters(); break;
                    case 4: dm.DeleteWithParameters(); break;
                    default: Console.WriteLine("Invalid option"); break;
                }
            } while (option >= 1 && option <= 4);
            Console.ReadLine();
        }

    }
}
