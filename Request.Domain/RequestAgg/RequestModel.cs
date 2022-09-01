using Frameworkes;
using Request.Domain.RequestServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.RequestAgg
{
    public class RequestModel : BaseEntity
    {
        public RequestModel(long stateId, long cityId, string companyName, long customerCode, string applicantName, 
            long serviceId, string origin, string destination, string constantPhone, string phone,string letterId, string letterPhoto, long creatorId) : base(creatorId)
        {
            StateId = stateId;
            CityId = cityId;
            CustomerCode = customerCode;
            ApplicantName = applicantName;
            ServiceId = serviceId;
            Origin = origin;
            Destination = destination;
            ConstantPhone = constantPhone;
            Phone = phone;
            IsConfirm = false;
            LetterPhoto = letterPhoto;
            CompanyName = companyName;
            LetterId = letterId;
        }

        public void Edit(long stateId, long cityId, string companyName, long customerCode, string applicantName,
            long serviceId, string origin, string destination, string constantPhone, string phone, string letterPhoto, long creatorId) 
        {
            StateId = stateId;
            CityId = cityId;
            CustomerCode = customerCode;
            ApplicantName = applicantName;
            ServiceId = serviceId;
            Origin = origin;
            Destination = destination;
            CreatorId = creatorId;
            Phone = phone;
            ConstantPhone=constantPhone;
            LetterPhoto=letterPhoto;

            if (!string.IsNullOrWhiteSpace(companyName))
                CompanyName = companyName;
        }

        //for confirm the request
        public void Confirm()=> IsConfirm = true;
        //for confirm the request
        public void DeConfirm()=> IsConfirm = false;

        public long StateId { get;private set; }
        public long CityId { get;private set; }
        public long CustomerCode { get;private set; }
        public string ApplicantName { get;private set; }
        public string CompanyName { get;private set; }
        public long ServiceId { get;private set; }
        public string Origin { get;private set; }
        public string Destination { get;private set; }
        public string ConstantPhone { get;private set; }
        public string Phone { get;private set; }
        public bool IsConfirm { get;private set; }
        public string LetterPhoto { get;private set; }
        public string LetterId { get;private set; }
        public ServiceModel Service { get; private set; }
    }
}
