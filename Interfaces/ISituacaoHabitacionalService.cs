using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_aapcmr.Dto;
using api_aapcmr.Repository;

namespace api_aapcmr.Interfaces
{
    public interface ISituacaoHabitacionalService
    {
        Task<SituacaoHabitacional> GetItemSituacaoHabitacional(long id);
        Task UpdateSituacaoHabitacional(SituacaoHabitacionalDto model);
        Task<SituacaoHabitacional> InsertSituacaoHabitacional(SituacaoHabitacionalDto model);
    }
}