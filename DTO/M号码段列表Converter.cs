using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DTO
{
    public class M号码段列表Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<M号码段>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object value, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return 解析(token.Value<string>());
        }

        public override void WriteJson(JsonWriter __writer, object __value, JsonSerializer __serializer)
        {
            var __对象 = (List<M号码段>)__value;
            __writer.WriteValue(合成(__对象));
        }

        private List<M号码段> 解析(string __号码范围)
        {
            throw new NotImplementedException();
        }

        private string 合成(List<M号码段> __号码范围)
        {
            throw new NotImplementedException();
        }

    }
}
