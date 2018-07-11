using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CloudFabric.Library.Common.Entities
{
    public class UnauthorizedException : BaseException
    {
        public override string Body() => "";

        public override HttpStatusCode Status() => HttpStatusCode.Unauthorized;
    }
}
