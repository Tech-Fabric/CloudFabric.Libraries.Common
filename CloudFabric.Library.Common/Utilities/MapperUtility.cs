using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFabric.Library.Common.Utilities
{
    public static class MapperUtility
    {
        public static TOut Map<TIn, TOut>(TIn input)
        {
            return JsonConvert.DeserializeObject<TOut>(
                JsonConvert.SerializeObject(input, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }), new JsonSerializerSettings
                {
                    Error = HandleDeserializationError
                });
        }
        public static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }


    
}
