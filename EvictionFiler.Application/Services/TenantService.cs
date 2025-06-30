//using EvictionFiler.Application.DTOs.TenantDto;
//using EvictionFiler.Application.Interfaces.IServices;
//using EvictionFiler.Application.Interfaces.IUserRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EvictionFiler.Application.Services
//{
//    public class TenantService : ITenantService
//    {   
//        private readonly ITenantRepository _tenantRepository;
//        public TenantService(ITenantRepository tenantRepository)
//        { 
//            _tenantRepository = tenantRepository;
//        }

//        public async Task<bool> AddTenantAsync(CreateTenantDto dto)
//        {
//            var newtenant = await _tenantRepository.AddTenant(dto);
//            return newtenant;
//        }
//    }
//}
