using System;

namespace BakUna.Utilities
{
    abstract class DataExtractor
    {
        public abstract string Serialize<T>(T obj);

        public abstract T Deserialize<T>(string json);
    }
}
