using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Succeeded = true;
        }
        public ServiceResult(object responseObject)
        {
            Succeeded = true;
            Response = responseObject;
        }
        public ServiceResult(ServiceError error)
        {
            Errors = new List<ServiceError>() { error };
        }

        public ServiceResult(List<ServiceError> errors)
        {
            Errors = errors;
        }
        public bool Succeeded { get; set; }
        public object Response { get; set; }
        public IEnumerable<ServiceError> Errors { get; protected set; }
    }

    public class ServiceError
    {
        public ServiceError(string key, string description)
        {
            Key = key;
            Description = description;
        }
        public string Key { get; set; }
        public string Description { get; set; }
    }

    public enum ServiceResultStatus
    {
        Succeeded,
        Failed
    }
}
