﻿using System;
namespace BlogSystem
{
    public class BaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();//特别长不会重复
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool IsRemove { get; set; }
    }
}
