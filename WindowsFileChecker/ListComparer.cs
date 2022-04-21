using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class ListComparer
    {
        private OrderList OrderList { get; set; }
        private ProductionFileList WhFileList { get; set; }
        private ProductionFileList UltimaFileList { get; set; }
        

        public ListComparer(OrderList orderList, ProductionFileList whFileList, ProductionFileList ultimaFileList)
        {
            OrderList = orderList;
            WhFileList = whFileList;
            UltimaFileList = ultimaFileList;
            
        }
        public OrderList Compare()
        {
            OrderList resultOrderList = new();
            foreach (var order in OrderList.Orders)
            {
                OrderCompared orderCompared = new OrderCompared(order.Srcdoc, order.OrderNumber, order.State, order.ProductionDate, order.InfoType);

                foreach (var file in WhFileList.Files)
                {
                    if (file.OrderNumber.Contains(order.OrderNumber))
                    {
                        orderCompared.WhFile = true; 
                    }
                }
                foreach (var file2 in UltimaFileList.Files)
                {
                    if (file2.OrderNumber.Contains(order.OrderNumber))
                    {
                        orderCompared.UltimaFile = true;
                        orderCompared.InfoType = "";
                    }
                }
                resultOrderList.Orders.Add(orderCompared);
            }
            return resultOrderList;
        }
    }
}
