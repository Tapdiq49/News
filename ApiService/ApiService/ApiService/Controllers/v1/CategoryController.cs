﻿using ApiService.Resources.NewsCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Entities;
using Repository.Exceptions;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryService.GetAllCategories();
            var categoryResource = _mapper.Map<IEnumerable<Category>, IEnumerable<NewsCategoryResource>>(category);
            return Ok(categoryResource);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute]int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                return Ok(category);
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, new { e.Message });
            }
        }
    }
}