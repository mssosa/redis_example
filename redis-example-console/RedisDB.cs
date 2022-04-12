using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redis_example_console
{
    internal class RedisDB
    {
        private Lazy<ConnectionMultiplexer> _lazyConnection;

        public ConnectionMultiplexer Connection
        {
            get
            {
                return _lazyConnection.Value;

            }
        }

        public RedisDB()
        {
            _lazyConnection = new Lazy<ConnectionMultiplexer>((() =>
                ConnectionMultiplexer.Connect("localhost")
            ));
        }

    }
}
