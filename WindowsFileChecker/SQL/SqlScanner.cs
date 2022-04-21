using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class SqlScanner
    {
        private WhConfig _whConfig;
        readonly string sql = "Select distinct top 100 o.indeks, o.zlecenie_t, o.stan, o.realizacja , case when o.dtypy like '' then 'brak konstrukcji' else o.dtypy end "
                            + "from oferty as o join rep_czesci as c on o.indeks = c.srcdoc "
                            + "where o.zlecenie_t not like '' and o.zlecenie_t like 'ZLC/A%' and SUBSTRING(o.zlecenie_t,17,2) not like 'V0' and "
                            + "(c.nr_art like 'P-B88%' or "
                            + "c.nr_art like 'P-163%' or "
                            + "c.nr_art like 'GN%' or "
                            + "c.nr_art like 'UG%') "
                            + "and o.stan like 'Produkcja%' and o.realizacja > GETDATE() order by o.realizacja";
        public SqlScanner(WhConfig whConfig)
        {
            _whConfig = whConfig;
        }
        public OrderList GenerateOrderList()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_whConfig.GetConnectionString());
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            OrderList orderList = new();
            while (dataReader.Read())
            {
                try
                {
                    Order order = new((int)dataReader.GetValue(0), (string)dataReader.GetValue(1), (string)dataReader.GetValue(2), (DateTime)dataReader.GetValue(3), (string)dataReader.GetValue(4));
                    orderList.Orders.Add(order);
                }
                catch (Exception)
                {
                    throw new Exception("Błąd parsowania danych z tabel SQL");
                }

            }
            dataReader.Close();
            command.Dispose();
            cnn.Close();
            return orderList;
        }
    }
}
