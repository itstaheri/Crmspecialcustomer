using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserRoleAgg;

namespace User.Domain.UserAgg
{
    public class UserModel : BaseEntity
    {
        public UserModel(string username, string password, string fullName, string code, string profilePicture, string phone, long roleId,long creatorId) : base(creatorId)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Code = code;
            ProfilePicture = profilePicture;
            Phone = phone;
            RoleId = roleId;
            IsActive = true;
        }
        //Edit UserInfo
        public void Edit(string username,  string fullName, string code, string profilePicture, string phone, long roleId, long creatorId)
        {
            Username = username;
            FullName = fullName;
            Code = code;
            if(!string.IsNullOrWhiteSpace(profilePicture))
                ProfilePicture = profilePicture;
            Phone = phone;
            RoleId = roleId;
           CreatorId = creatorId;

        }
        //for active and deactive user
        public void ActiveUser()=> IsActive = true;
        public void DeActiveUser()=> IsActive = false;

        public void ChangePassword(string NewPassword) => Password = NewPassword;

        public string Username { get;private set; }
        public string Password { get;private set; }
        public string FullName { get;private set; }
        public string Code { get;private set; }
        public string ProfilePicture { get;private set; }
        public string Phone { get;private set; }
        public long RoleId { get;private set; }
        public bool IsActive { get;private set; }
        public UserRoleModel userRole { get; private set; }
        
    }
}
