using Frameworkes;
using Frameworkes.Auth;
using Frameworkes.Message;
using Frameworkes.Message.Sms;
using Frameworks;
using Intermediary.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using Request.Application.Contract.Request;
using Request.Domain.RequestAgg;
using Request.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Implements
{
    public class RequestApplication : IRequestApplication
    {
        private readonly IRequestRepository repository;
        private readonly IRequestToAreaRepository _requestToArea;
        private readonly IAuth _auth;
        private readonly IFileHelper _fileHelper;
        private readonly IMessage<SmsDetail> _message = new SmsMessage();

        public RequestApplication(IRequestRepository repository, IRequestToAreaRepository requestToArea, IAuth auth, IFileHelper fileHelper, IMessage<SmsDetail> message)
        {
            this.repository = repository;
            _requestToArea = requestToArea;
            _auth = auth;
            _fileHelper = fileHelper;
            _message = message;
        }

        public async Task ConfirmRequest(long RequestId)
        {

            //confirm request by <confirm> Method & savechange
            var request = (await repository.GetBy(RequestId));
            request.Confirm();
            //send confirm notification message by sms
            await _message.SendMassege(new SmsDetail { Message = "درخواست شما تایید شد" ,Number = request.Phone });

            await repository.SaveChanges();

        }

        public async Task CreateRequest(CreateRequestViewModel commend)
        {
            // Generate PhotoId
            var letterId = GeneratePhotoId.Generate(commend.CustomerCode.ToString());
            //Upload photo and get name
            var letterPhoto = await _fileHelper
                .SingleUploader(commend.LetterPhoto, "Letters", letterId);

            var request = new RequestModel(commend.StateId, commend.CityId, commend.CompanyName, commend.CustomerCode, commend.ApplicantName,
                commend.ServiceId, commend.Origin, commend.Destination, commend.ConstantPhone, commend.Phone, letterId, letterPhoto, _auth.GetCurrentId());

            await repository.Create(request);


        }

        public async Task DeConfirmRequest(long RequestId)
        {
            //confirm request by <confirm> Method & savechange
            var request = (await repository.GetBy(RequestId)).DeConfirm;
           
            await repository.SaveChanges();
        }

        public async Task EditRequest(EditRequestViewModel commend)
        {
            //Upload photo and get name
            var letterPhoto = await _fileHelper
                .SingleUploader(commend.LetterPhoto, "Letters", commend.LetterId);
            var request = await repository.GetBy(commend.RequestId);
            request.Edit(commend.StateId, commend.CityId, commend.CompanyName, commend.CustomerCode, commend.ApplicantName,
                commend.ServiceId, commend.Origin, commend.Destination, commend.ConstantPhone, commend.Phone,letterPhoto, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<List<RequestViewModel>> GetAllRequestInfo(RequestSearchViewModel commend)
        {

            var query = (await repository.GetAll()).Select(x => new RequestViewModel
            {
                ApplicantName = x.ApplicantName,
                ServiceId = x.ServiceId,
                Origin = x.Origin,
                Destination = x.Destination,
                ConstantPhone = x.ConstantPhone,
                Phone = x.Phone,
                CreationDate = x.CreationDate,
                CityId = x.CityId,
                CustomerCode = x.CustomerCode,
                IsConfirm = x.IsConfirm,
                RequestId = x.Id,
                StateId = x.StateId,
                ServiceName = x.Service.ServiceName,
                CompanyName = x.CompanyName,
                LetterPhoto = x.LetterPhoto,
                LetterId = x.LetterId

            }).ToList();


            foreach (var item in query)
            {
                //get detail of city from IRequestToAreaRepository in IntermediaryLayer by cityId
                var cityDetail = await _requestToArea.GetCityInfo(item.CityId);
                //set cityName & stateName 
                if (cityDetail != null)
                {
                    item.CityName = cityDetail.CityName;
                    item.StateName = cityDetail.StateName;
                }

            }

            //select by 
            if (commend != null)
            {
                if (!string.IsNullOrEmpty(commend.ConstantPhone))
                    query = query.Where(x => x.ConstantPhone == commend.ConstantPhone).ToList();

                if (!string.IsNullOrEmpty(commend.CityName))
                    query = query.Where(x => x.CityName == commend.CityName).ToList();

                if (!string.IsNullOrEmpty(commend.Phone))
                    query = query.Where(x => x.Phone == commend.Phone).ToList();

                if (!string.IsNullOrEmpty(commend.CompanyName))
                    query = query.Where(x => x.CompanyName == commend.CompanyName).ToList();

                if (commend.CustomerCode > 0)
                    query = query.Where(x => x.CustomerCode == commend.CustomerCode).ToList();

                if (commend.IsConfirm && commend.Status)
                    query = query.Where(x => x.IsConfirm == true).ToList();


                if (!string.IsNullOrEmpty(commend.FromDate) && !string.IsNullOrEmpty(commend.ToDate))
                    query = query.Where(x => x.CreationDate >= commend.FromDate.ToGeorgianDateTime() && x.CreationDate <= commend.ToDate.ToGeorgianDateTime()).ToList();

            }

            return query.ToList();
        }

        public async Task<long> GetStateId(long RequestId)
        {
            return (await repository.GetBy(RequestId)).StateId;
        }

        public async Task<EditRequestViewModel> GetValueForEdit(long RequestId)
        {
            var request = await repository.GetBy(RequestId);
            return new EditRequestViewModel
            {
                ApplicantName = request.ApplicantName,
                ServiceId = request.ServiceId,
                Origin = request.Origin,
                Destination = request.Destination,
                ConstantPhone = request.ConstantPhone,
                Phone = request.Phone,
                CityId = request.CityId,
                CustomerCode = request.CustomerCode,
                RequestId = request.Id,
                StateId = request.StateId,
                CompanyName = request.CompanyName,
                LetterId= request.LetterId

            };
        }

        public async Task RemoveRequest(long RequestId)
        {
            await repository.Remove(RequestId);
        }


    }
}
