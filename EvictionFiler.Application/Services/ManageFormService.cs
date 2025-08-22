using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class ManageFormService : IManageFormService
    {
        private readonly IManageFormRepository _repository;
        public ManageFormService(IManageFormRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<List<FormAddEditViewModelDto>> GetAllFormAsync()
        {
            var forms = await _repository.GetAllForm();
            var result = forms.Select(x => new FormAddEditViewModelDto
            {
                Name = x.Name,
                CaseType = x.CaseType,
                CaseTypeId = x.CaseTypeId,
                HTML = x.HTML,
                Id = x.Id,
                
            }).ToList();
            return result;
        }
    }
}
