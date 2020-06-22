using System;
using System.Collections.Generic;
using System.Dynamic;

namespace TrueForm.BusinessObjects.Helpers
{
    public class DataActionResponse
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }

    public static class DataActionResponseFactory
    {
        public static DataActionResponse CreateDataActionResponseSuccess(this object data)
        {
            return new DataActionResponse()
            {
                IsSuccessful = true,
                Data = data
            };
        }


        public static DataActionResponse CreateDataActionResponseSuccessForDelete(this object data, string propertyName, object value)
        {
            var myObject = new ExpandoObject() as IDictionary<string, Object>;
            myObject.Add(propertyName, value);

            return new DataActionResponse()
            {
                IsSuccessful = true,
                Data = myObject
            };
        }

        public static DataActionResponse CreateDataActionResponseSuccessForDelete(this object data, Dictionary<string, Object> propertNameValueList)
        {
            var myObject = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var o in propertNameValueList)
                myObject.Add(o.Key, o.Value);

            return new DataActionResponse()
            {
                IsSuccessful = true,
                Data = myObject
            };
        }


        public static DataActionResponse CreateDataActionResponseFailed(string errorMessage, object data = null)
        {
            return new DataActionResponse()
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage,
                Data = data
            };
        }

         

    }
}
