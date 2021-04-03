﻿using Repository.Data.Entities;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IAboutService
    {
        Task<About> GetAbout();
    }
}