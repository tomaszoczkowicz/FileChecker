using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileChecker
{
    public class SqlScanner
    {
        private WhConfig _whConfig;
        readonly string sql = "Select top 50 indeks, zlecenie_t, stan, realizacja, case when dtypy like '' then 'brak konstrukcji' else dtypy end "
                            + "from oferty "
                            + "where zlecenie_t not like '' and zlecenie_t like 'ZLC/A%' and SUBSTRING(zlecenie_t,17,2) not like 'V0' "
                            + "and stan like 'Produkcja%' and realizacja > GETDATE() order by realizacja";
        public SqlScanner(WhConfig whConfig)
        {
            _whConfig = whConfig;
        }
        public OrderList GenerateOrderList()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(_whConfig.GetConnectionString());
            cnn.Open();
            Console.WriteLine("Nawiązano połączenie z bazą SQL");
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
