# ToolWatchCache
An exercise performed for ToolWatch as a final interview.

ToolWatch Cache is a generic caching tool that provides easy writing and retrieval for value storage.

Methods
---

Contains(string key)
-Returns whether or not the key already exists in storage

Delete(string key)
-Removes and returns the value from storage. If the value does not exist, it will throw an exception.

Get(string key)
-Returns the value associated with that key should it exists. If the value does not exist, it will throw an exception.

MGet(string[] keys)
-Returns the values associated with those keys should they exists. If the values do not exist, it will throw an exception.

Set(string key, object value)
-Will store the value for later retrieval under the same key. Will write over existing values of that same key.

SetNX(string key, object value)
-Will store the value for later retrieval under the same key. Will not write over existing values of that same key.

ListKeys()
-Returns all keys that exist in storage
