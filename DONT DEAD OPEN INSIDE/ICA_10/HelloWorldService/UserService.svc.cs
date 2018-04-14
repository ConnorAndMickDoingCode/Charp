using ICA_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        List<UserModel> users = new List<UserModel>();

        public UserService()
        {
            users.Add(new UserModel("Mick", "test1"));
            users.Add(new UserModel("Megan", "test2"));
            users.Add(new UserModel("Gaby", "test3"));
        }

        public DTO GetAllUsers()
        {
            DTO dto = new DTO(0, "OK", users);
            return dto;
        }

        public DTO GetUser(string id)
        {
            int index = Int32.Parse(id);
            if(index > users.Count)
            {
                DTO dto = new DTO(-1, "user does not exist", null);
                return dto;
            }
            else
            {
                List<UserModel> user = new List<UserModel>();
                user.Add(users[index]);
                DTO dto = new DTO(0, "OK", user);
                return dto;
            }
            
        }


        public CompositeType GetObjectModel(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("composite");
            }

            CompositeType composite = new CompositeType();
            composite.BoolValue = false;
            composite.StringValue = "Your composite value was " + id + " ....     GetObjectModel(" + id + ")";
            return composite;
        }

        public string SayHello()
        {
            return "Hello from my first WCF REST Service!!!! Woohoo!! This is amazing!      ...     SayHello()";
        }

        public string GetData(string value)
        {
            return string.Format("You have " + value + " chickens... Why? Who knows!     ...       GetData(" +  value  + ")");
        }

       
    }
}
