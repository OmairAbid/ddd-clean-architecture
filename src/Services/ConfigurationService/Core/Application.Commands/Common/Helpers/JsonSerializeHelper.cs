using Application.Commands.Contracts.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Helpers
{
    public class JsonSerializeHelper<T> : IJsonSerializeHelper<T>
    {
        public string Serialize(object? value, Type type)
        {
            return  JsonConvert.SerializeObject(value, typeof(T), new JsonSerializerSettings() { });
        }
    }
}
