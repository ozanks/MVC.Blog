﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Blog_Ozan.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}