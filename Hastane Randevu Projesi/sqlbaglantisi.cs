using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Randevu_Projesi
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglann = new SqlConnection("Data Source=MSI-GL65-LEOPAR\\SQLEXPRESS;Initial Catalog=Hospital Appointment Project;Integrated Security=True");
            baglann.Open();
            return baglann;

        }

    }
}
