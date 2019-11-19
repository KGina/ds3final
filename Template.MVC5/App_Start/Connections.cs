using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbantwanaWebMaster.BusinessLogic;

namespace AbantwanaWebMaster.MVC5.App_Start
{
    public class Connections
    {
      // private connectionBussiness connection100 = new connectionBussiness();
        public static void PutUsersOffline()
        {
            connectionBussiness connection100 = new connectionBussiness();
            foreach (var connection in connection100.GetConnection() )
            {
                connection.IsOnline = false;
                connection100.updateConnection(connection);
            }
                   

                   //db.SaveChanges();
            //}
        }
    }
}