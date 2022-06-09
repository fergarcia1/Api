using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymous : Attribute
    {
    }
}
