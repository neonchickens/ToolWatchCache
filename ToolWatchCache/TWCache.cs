using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolWatchCache
{
    public interface ITWCache
    {
        bool Contains(string key);
        object Delete(string key);
        object Get(string key);
        object[] MGet(params string[] keys);
        void Set(string key, object val);
        void SetNX(string key, object val);
        string[] ListKeys();
    }

    public class MyTWCache : ITWCache
    {
        Dictionary<string, object> dicCache;

        public MyTWCache()
        {
            dicCache = new Dictionary<string, object>();
        }

        public bool Contains(string key)
        {
            //Returns whether or not the key already exists in storage
            return dicCache.ContainsKey(key);
        }

        public object Delete(string key)
        {
            //Removes and returns the value from storage. If the value does not exist, it will throw an exception.
            if (dicCache.ContainsKey(key))
            {
                object obj = dicCache[key];
                dicCache.Remove(key);
                return obj;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public object Get(string key)
        {
            //Returns the value associated with that key should it exists. If the value does not exist, it will throw an exception.
            if (dicCache.ContainsKey(key))
            {
                return dicCache[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public string[] ListKeys()
        {
            //Returns all keys that exist in storage
            return dicCache.Keys.ToArray();
        }

        public object[] MGet(params string[] keys)
        {
            //Returns the values associated with those keys should they exists. If the values do not exist, it will throw an exception.
            object[] obj = new object[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                if (dicCache.ContainsKey(keys[i]))
                {
                    obj[i] = dicCache[keys[i]];
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            return obj;
        }

        public void Set(string key, object val)
        {
            //Will store the value for later retrieval under the same key. Will write over existing values of that same key.
            if (!dicCache.ContainsKey(key))
            {
                dicCache.Add(key, val);
            }
            else
            {
                dicCache[key] = val;
            }
        }

        public void SetNX(string key, object val)
        {
            //Will store the value for later retrieval under the same key. Will not write over existing values of that same key.
            if (!dicCache.ContainsKey(key))
            {
                dicCache.Add(key, val);
            }
        }
    }
}
