using AutoMapper;
using Repositories.Contracts.Interfaces;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Base
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult Succeeded()
        {
            return new ServiceResult();
        }
        public ServiceResult Succeeded(object response)
        {
            return new ServiceResult(response);
        }
        public ServiceResult Failed(string key, string description)
        {
            return new ServiceResult(new ServiceError(key, description));
        }
    }
}
