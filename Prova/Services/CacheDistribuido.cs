using StackExchange.Redis;

namespace Prova.Services
{
	public class CacheDistribuido
	{
        static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-18603.c74.us-east-1-4.ec2.cloud.redislabs.com:18603,password=<password>");
        static async Task Main(string[] args)
        {
            var db = redis.GetDatabase();
        }
    }
}


