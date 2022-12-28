using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_CSharp
{
     class CustomerBAL
    {

        CustomerDAL dal = new CustomerDAL();
        public List<CustomerBEL> ReadCus()
        {
            List<CustomerBEL> lstCus =dal.ReadCustomer();
            return lstCus;
        }

        public void NewCustomer(CustomerBEL cus)
        {
            dal.NewCus(cus);
        }
        public void DeleteCus(CustomerBEL cus)
        {
            dal.DeleteCus(cus);
        }
        public void EditCus(CustomerBEL cus)
        {
            dal.EditCus(cus);
        }
    }
}
