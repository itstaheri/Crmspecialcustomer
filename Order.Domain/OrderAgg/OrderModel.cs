using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAgg
{
    public class OrderModel : BaseEntity
    {
        public OrderModel(long materialId, long value, double totalPrice, double payAmount,
            int discountRate, double discountAmount, double customerShare, string description, 
            string customerCode, string documentReceiptPhoto, string letterPhoto,long creatorId) : base(creatorId)
        {
            MaterialId = materialId;
            Value = value;
            TotalPrice = totalPrice;
            PayAmount = payAmount;
            DiscountRate = discountRate;
            DiscountAmount = discountAmount;
            CustomerShare = customerShare;
            Description = description;
            CustomerCode = customerCode;
            DocumentReceiptPhoto = documentReceiptPhoto;
            LetterPhoto = letterPhoto;
            IsPaid = false;
        }
        public void Edit(long materialId, long value, double totalPrice, double payAmount,
          int discountRate, double discountAmount, double customerShare, string description,
          string customerCode, string documentReceiptPhoto, string letterPhoto, long creatorId) 
        {
            MaterialId = materialId;
            Value = value;
            TotalPrice = totalPrice;
            PayAmount = payAmount;
            DiscountRate = discountRate;
            DiscountAmount = discountAmount;
            CustomerShare = customerShare;
            Description = description;
            CustomerCode = customerCode;
            DocumentReceiptPhoto = documentReceiptPhoto;
            LetterPhoto = letterPhoto;
            
        }

        public void Paid() => IsPaid = true;
        public void UnPaid() => IsPaid = false;

        public double ApplyDiscountrate(int discountRate)
        {
            return (TotalPrice * discountRate) / 100;
        }
        public double ApplyDiscountamount(double discountAmount)
        {
            return TotalPrice - discountAmount;
        }

        public long MaterialId { get;private set; }
        public long Value { get;private set; }
        public double TotalPrice { get;private set; }
        public double PayAmount { get;private set; }
        public int DiscountRate { get;private set; }
        public double DiscountAmount { get;private set; }
        public double CustomerShare { get;private set; }
        public string Description { get;private set; }
        public string CustomerCode { get;private set; }
        public string DocumentReceiptPhoto { get;private set; }
        public string LetterPhoto { get;private set; }
        public bool IsPaid { get;private set; }






    }
}
