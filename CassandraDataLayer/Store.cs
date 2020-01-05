using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer
{
    public class Store
    {
        public User loggedUser { get; set; }
        private static Store instance;

        public static Store GetInstance()
        {
            if(instance == null)
            {
                instance = new Store();
            }
            return instance;
        }

        private Store()
        {
            loggedUser = null;
        }
        public User GetUser()
        {
            return loggedUser;
        }
        public bool SetUser(CassandraDataLayer.QueryEntities.User u)
        {
            try
            {
                loggedUser = u;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
