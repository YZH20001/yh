﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dto
{
   public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string Email { get; set; }

        public int GoodCount { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        public int BadCount { get; set; }
        public string ImagePath { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string[] CategoryNames { get; set; }
        public Guid[] CategoryIds { get; set; }
    }
}
