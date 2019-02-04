using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkLogic
{
    public class UserDataLogic
    {

        public UserDataLogic()
        {

        }
        public static void Authenticate(IOptions<MySettingsModel> app, LivingCarParkContext context, iapplicationservice applicationservice)
        {
            //[FromBody]applicationlogin appParam)
            applicationlogin appParam = new applicationlogin();
            var appslogins = _applicationservice.Authenticate(appparam.username, appparam.password);
            if (appslogins == null)
                return BadRequest(new { message = "you shall not pass!! wrong pass or user!" });

            var msg = new Message<applicationlogin>();
            msg.Data = appslogins;
            msg.DataExist = true;
            msg.IsSuccess = true;
            return Ok(msg);


        }


    }
}
