using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Domain.Entities;

namespace ForumTest.Builder
{
    public class CategoryBuilder
    {
        private string Name = "Name";
        public static CategoryBuilder NewCategoryBuilder()
        {
            return new CategoryBuilder();
        }

        public Category Build => new Category(Name);

        public CategoryBuilder CheckName(string name)
        {
            Name = name;
            return this;
        }
    }
}
