using StackExchange.Redis;
using System.Text.Json;
using Common.ConstDB.Type;
using MyUtil;

namespace HttpServer.Cache;

public class RedisService
{
    private static readonly ConnectionMultiplexer _redis;

    static RedisService()
    {
        _redis = ConnectionMultiplexer.Connect(ServerVariable.RedisServerURL);
        
        if (_redis.IsConnected)
            MyLogger.WriteLineInfo("Redis connected");
        else
            throw new Exception("Redis connection failed");
    }

    public static IEnumerable<string> GetKeys()
    {
        var server = _redis.GetServer(_redis.GetEndPoints()[0]);
        return server.Keys().Select(k => k.ToString());
    }

    public static async Task<T> GetValueAsync<T>(string key)
    {
        var db = _redis.GetDatabase();
        var value = await db.StringGetAsync(key);
        
        return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
    }
    
    public static async Task SetKeyValueAsync<T>(string key, T value, TimeSpan expiration = default)
    {
        if (expiration == default)
            expiration = TimeSpan.FromMinutes(30);
        
        var db = _redis.GetDatabase();
        var serializedValue = JsonSerializer.Serialize(value);
        await db.StringSetAsync(key, serializedValue, expiration);
    }
    
    public static IEnumerable<(string Key, T Value)> GetKeysAndValues<T>()
    {
        var server = _redis.GetServer(_redis.GetEndPoints()[0]);
        var db = _redis.GetDatabase();

        foreach (var key in server.Keys())
        {
            var value = db.StringGet(key);
            yield return (key.ToString(), value.HasValue ? JsonSerializer.Deserialize<T>(value) : default);
        }
    }
    
    public static async Task<bool> KeyExists(string key)
    {
        var db = _redis.GetDatabase();
        return await db.KeyExistsAsync(key);
    }
    
    public static async Task RemoveKeyAsync(string key)
    {
        var db = _redis.GetDatabase();
        await db.KeyDeleteAsync(key);
    }
    
    public static void Ping(bool debug)
    {
        var elapsedTime = _redis.GetDatabase().Ping();
        if (debug) MyLogger.WriteLineInfo($"Ping for Redis : {elapsedTime}ms");
    }
}