﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace CassandraDataLayer
{
    public static class SessionManager
    {
        public static ISession session;

        public static ISession GetSession()
        {
            if (session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = cluster.Connect("eldnevnik");
            }

            return session;
        }
    }
}
