namespace Properties
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public class ResourceCollection<TKey, TVal> : Dictionary<TKey, TVal>
    {
        public delegate void ErrorHandler(string message);

        public event ErrorHandler Error;

        public void SafeAdd(TKey key, TVal val)
        {
            if (ContainsKey(key)) return;

            Add(key, val);
        }
        public TVal SafeGet(TKey key)
        {
            if (ContainsKey(key))
                return this[key];

            Error("image with key '" + key + "' not found.");
            return default(TVal);
        }

        protected virtual void OnError(string message)
        {
            var handler = Error;
            if (handler != null) handler(message);
        }
    }
}