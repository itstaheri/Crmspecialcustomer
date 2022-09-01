using Microsoft.AspNetCore.Http;
using Request.Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Request
{
    public class CreateRequestViewModel
    {
        [SelectValidation(0,ErrorMessage ="انتخاب استان الزامی است")]
        public long StateId { get; set; }
        [SelectValidation(0, ErrorMessage = "انتخاب شهر الزامی است")]
        public long CityId { get; set; }
        public long CustomerCode { get; set; }
        [MaxLength(200,ErrorMessage =("نام درخواست دهنده نباید بیشتر از 200حرف باشد!"))]
        public string ApplicantName { get; set; }
        [SelectValidation(0, ErrorMessage = "انتخاب سرویس الزامی است")]
        public long ServiceId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ConstantPhone { get; set; }
        public string Phone { get; set; }
        public IFormFile LetterPhoto { get; set; }
        public string CompanyName { get; set; }
    }
}
