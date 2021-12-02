using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    internal interface ILineItemDAO
    {
        List<LineItem> GetAllItemsByOrderId(int orderId);
        bool AddLineItem(LineItem item);

    }
}
