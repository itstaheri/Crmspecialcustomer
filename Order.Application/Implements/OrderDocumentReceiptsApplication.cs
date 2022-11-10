using Frameworkes.Auth;
using Frameworks;
using Order.Application.Contract.OrderDocumentReceipt;
using Order.Domain.OrderDocumentReceiptAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Implements
{

    public class OrderDocumentReceiptsApplication : IOrderDocumentReceiptsApplication
    {
        private readonly IOrderDocumentReceiptRepository repository;
        private readonly IAuth _auth;
        private readonly IFileHelper _fileHelper;

        public OrderDocumentReceiptsApplication(IOrderDocumentReceiptRepository repository, IAuth auth, IFileHelper fileHelper)
        {
            this.repository = repository;
            _auth = auth;
            _fileHelper = fileHelper;
        }

        public async Task CreateReceipt(CreateOrderDocumentReceiptViewModel commend)
        {
            //Upload photo and return photoname
            var PhotoName = await _fileHelper.SingleUploader(commend.DocumentReceiptPhoto, "Receipts", commend.OrderId.ToString());
            var OrderDocumentReceipt = new OrderDocumentReceiptModel(commend.OrderId, commend.AmountPaid, commend.Description, PhotoName, _auth.GetCurrentId());
            await repository.Create(OrderDocumentReceipt);



        }

        public async Task EditReceipt(EditCreateOrderDocumentReceiptViewModel commend)
        {
            //Upload photo and return photoname
            var PhotoName = await _fileHelper.SingleUploader(commend.DocumentReceiptPhoto, "Receipts", commend.OrderId.ToString());
            //get orderDocumentReceipt detail by Id
            var orderDocumentReceipt = await repository.GetBy(commend.OrderDocumentReceiptId);
            //The sum of the previous amount and the new amount
            var currentAmountPaid = commend.AmountPaid + orderDocumentReceipt.AmountPaid;
            //edit
            orderDocumentReceipt.Edit(commend.Description, currentAmountPaid, PhotoName, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<DocumentReceiptViewModel> GetReceiptInfoBy(long DocumentReceiptId)
        {
            var orderDocumentReceipt = await repository.GetBy(DocumentReceiptId);
            return new DocumentReceiptViewModel
            {
                Description = orderDocumentReceipt.DocumentReceiptDescription,
                DocumentReceiptId = orderDocumentReceipt.Id,
                AmountPaid = orderDocumentReceipt.AmountPaid,
                OrderId = orderDocumentReceipt.OrderId,
                DocumentReceiptPhoto = orderDocumentReceipt.DocumentReceiptPhoto,
            };
        }

        public async Task<List<DocumentReceiptViewModel>> GetReceiptsBy(long OrderId)
        {
            var orderDocumentReceipt = (await repository.GetAll()).Where(x => x.OrderId == OrderId);
            return orderDocumentReceipt.Select(x => new DocumentReceiptViewModel
            {
                Description = x.DocumentReceiptDescription,
                DocumentReceiptId = x.Id,
                AmountPaid = x.AmountPaid,
                OrderId = x.OrderId,
                DocumentReceiptPhoto = x.DocumentReceiptPhoto,
                CreationDate = x.CreationDate.ToFarsiFull()
            }).ToList();
        }

        public async Task RemoveReceipt(long DocumentReceiptId)
        {
            await repository.Remove(DocumentReceiptId);
        }
    }
}
