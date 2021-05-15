using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarRental.Core.Extensions;
using CarRental.Business.Constants;

namespace CarRental.Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
