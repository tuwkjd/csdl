using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_CSharp
{
    public class AreaDAL:DBConnection
    {
        public List<AreaBEL> ReadAreaList()
        {
            SqlConnection conn = CreateConection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from areas", conn);
            SqlDataReader read = cmd.ExecuteReader();

            List<AreaBEL> lstArea = new List<AreaBEL>();
            while (read.Read())
            {
                AreaBEL cus = new AreaBEL();
                cus.Id = int.Parse(read["id"].ToString());
                cus.Name = read["name"].ToString();
                lstArea.Add(cus);
            }
            conn.Close();
            return lstArea;
        }
        public AreaBEL ReadArea(int id)
        {
            SqlConnection conn = CreateConection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from areas where id="+id.ToString(), conn);
            SqlDataReader read = cmd.ExecuteReader();

            AreaBEL area = new AreaBEL();
            if(read.HasRows && read.Read())
            {
                area.Id = int.Parse(read["id"].ToString()) ;
                area.Name = read["name"].ToString() ;
            }
            conn.Close();
            return area;
        }
    }
}
