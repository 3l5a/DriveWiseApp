﻿using DTOs;

namespace Repositories.Contracts;

public interface IStatusRepository
{
    Task<StatusAddDto> AddAsync(StatusAddDto statusAddDto);
    Task<List<StatusGetDto>> GetAllAsync();
    Task<StatusGetDto> GetByIdAsync(int id);
    Task<StatusUpdateDto> UpdateAsync(StatusUpdateDto statusUpdateDto);
    Task DeleteAsync(int id);
}