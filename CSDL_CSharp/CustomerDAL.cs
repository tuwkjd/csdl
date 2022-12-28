using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_CSharp
{
    public class CustomerDAL : DBConnection
    {
        public List<CustomerBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            SqlDataReader read = cmd.ExecuteReader();

            List<CustomerBEL> lstCus = new List<CustomerBEL>();
            AreaDAL are = new AreaDAL();
            while (read.Read())
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(read["id"].ToString());
                cus.Name = read["name"].ToString();
                cus.Area= are.ReadArea(int.Parse(read["id_area"].ToString()));
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void DeleteCus(CustomerBEL cus)
        {
            SqlConnection conn = CreateConection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("delete from customer where id= @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void NewCus(CustomerBEL cus)
        {
            SqlConnection conn = CreateConection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into  customer values(@id,@name)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void EditCus(CustomerBEL cus)
        {
            SqlConnection conn = CreateConection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("update  customer set name=@name, id_area=@id_area where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
