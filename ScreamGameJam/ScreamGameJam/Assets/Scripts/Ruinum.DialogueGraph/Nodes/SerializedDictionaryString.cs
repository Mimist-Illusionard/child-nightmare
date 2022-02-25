using System;
using System.Collections.Generic;

using UnityEngine;


[Serializable]
public class SerializedDictionaryString
{
    [SerializeField] protected List<SerilializedDictionaryData> _data = new List<SerilializedDictionaryData>();

    public virtual void Add(string key, string value)
    {
        _data.Add(new SerilializedDictionaryData(key, value));
    }

    public bool TryGetValue(string key, out string value)
    {
        for (int i = 0; i < _data.Count; i++)
        {
            var dictionaryData = _data[i];
            if (dictionaryData.Key.ToString() == key.ToString())
            {
                value = dictionaryData.Value;
                return true;
            }
        }

        value = default;
        return false;
    }

    [Serializable]
    protected class SerilializedDictionaryData
    {
        [SerializeField] public string Key;
        [SerializeField] public string Value;

        public SerilializedDictionaryData(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}