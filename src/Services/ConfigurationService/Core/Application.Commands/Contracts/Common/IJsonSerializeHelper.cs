using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Contracts.Common
{
    public interface IJsonSerializeHelper<T>
    {
        public string Serialize(object? ojb, Type type);
    }
}
