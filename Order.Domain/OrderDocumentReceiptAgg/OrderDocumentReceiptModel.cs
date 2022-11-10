using Frameworkes;
using Order.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderDocumentReceiptAgg
{
    public class OrderDocumentReceiptModel : BaseEntity
    {
        

        public OrderDocumentReceiptModel(long orderId,double amountPaid,string documentReceiptDescription, string documentReceiptPhoto, long creatorId) :  base(creatorId)
        {
            OrderId = orderId;
            DocumentReceiptDescription = documentReceiptDescription;
            DocumentReceiptPhoto = documentReceiptPhoto;
            AmountPaid = amountPaid;
            
        }
        public void Edit(string documentReceiptDescription, double amountPaid, string documentReceiptPhoto, long creatorId)
        {
            DocumentReceiptDescription = documentReceiptDescription;
            AmountPaid = amountPaid;
            if (!string.IsNullOrWhiteSpace(documentReceiptPhoto)) 
                DocumentReceiptPhoto = documentReceiptPhoto;

        }

        public long OrderId { get;private set; }
        public string DocumentReceiptDescription { get; private set; }
        public string DocumentReceiptPhoto { get; private set; }
        public double AmountPaid { get; private set; }
        public bool IsPaidFull { get; private set; }
        public OrderModel Order { get;private set; }
    }
}
