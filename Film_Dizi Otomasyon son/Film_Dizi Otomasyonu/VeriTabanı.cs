using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_Dizi_Otomasyonu
{
    public class VeriTabanı
    {
        internal static string adres = "Data Source = LAPTOP-6OET6DB6; Initial Catalog = FilmDizi; Integrated Security = true; MultipleActiveResultSets=True";
        internal static SqlConnection connection = new SqlConnection(adres);
    }
}
