﻿using DTOs.DTOs.CategoryDTOs;
using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class CategoryRepository(DriveWiseContext context, CategoryMapper categoryMapper, ILogger logger) : ICategoryRepository
{
    public async Task AddAsync(CategoryAddDto categoryAddDto)
    {
        Category? c = await context.Categories.FirstOrDefaultAsync(c => c.Name.ToUpper() == categoryAddDto.Name.ToUpper());

        if (c is null)
        {
            Category newCategory = categoryMapper.CategoryAddDtoToCategory(categoryAddDto);
            await context.AddAsync(newCategory);
        }
        else throw new Exception("Category already exists");
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            Category c = await context.Categories.FindAsync(id) ?? throw new Exception("Category not found");

            context.Categories.Remove(c);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to delete category");
            throw;
        }
    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        try
        {
            List<Category> categories = await context.Categories.ToListAsync();

            return categoryMapper.ListCategoryToListCategoryGetDto(categories);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get categories");
            throw;
        }
    }

    public async Task<CategoryGetDto> GetByIdAsync(int id)
    {
        Category c = await context.Categories.FindAsync(id) ?? throw new Exception("Category not found");

        return categoryMapper.CategoryToCategoryGetDto(c);
    }

    public async Task UpdateAsync(CategoryUpdateDto categoryDto)
    {
        Category c = await context.Categories.FindAsync(categoryDto.Id) ?? throw new Exception("Category not found");

        c.Name = categoryDto.Name;

        await context.SaveChangesAsync();
    }
}