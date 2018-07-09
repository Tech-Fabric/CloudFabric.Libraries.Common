using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public abstract class BaseException : Exception
    {
        public abstract HttpStatusCode Status();
        public abstract string Body();
    }
}
