using System;
using Microsoft.EntityFrameworkCore;
using recipe_guru.WebAPI.Database;

namespace recipeguru.WebAPI
{
    public class SetupService
    {
        public static void Init(recipeGuruContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
