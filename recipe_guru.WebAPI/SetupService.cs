using System;
using recipe_guru.WebAPI.Database;

namespace recipeguru.WebAPI
{
    public class SetupService
    {
        public static void Init(recipeGuruContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
