using StackExchange.Redis;

namespace MS.Basket.Settings
{
    //public class RedisService
    //{
    //    private readonly string _connectionString;
    //    private ConnectionMultiplexer _connectionMultiplexer;

    //    public RedisService(string host, int port)
    //    {
    //        _connectionString = $"{host}:{port}";
    //    }

    //    public void Connect()
    //    {
    //        if (_connectionMultiplexer is null || !_connectionMultiplexer.IsConnected)
    //        {
    //            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
    //        }
    //    }

    //    public IDatabase GetDb(int db = 1)
    //    {
    //        if (_connectionMultiplexer is null)
    //        {
    //            throw new InvalidOperationException("Redis bağlantısı kurulmadı. Önce Connect() metodunu çağırın.");
    //        }

    //        return _connectionMultiplexer.GetDatabase(db);
    //    }
    //}
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
