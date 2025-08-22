using EvictionFiler.Application.DTOs.FormTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IManageFormService
    {
        Task<List<FormAddEditViewModelDto>> GetAllFormAsync();
    }
}
