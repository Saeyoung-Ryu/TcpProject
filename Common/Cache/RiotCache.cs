using System.Reflection;
using MyUtil;
using RiotSharp;
using RiotSharp.Caching;

namespace HttpServer.Cache;

public class RiotCache : ICache
{
    public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
    {
        throw new NotImplementedException();
    }

    public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
    {
        throw new NotImplementedException();
    }

    public TV Get<TK, TV>(TK key) where TV : class
    {
        throw new NotImplementedException();
    }

    public void Remove<TK>(TK key)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}