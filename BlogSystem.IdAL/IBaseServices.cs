﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IdAL
{
    public interface IBaseServices<T>:IDisposable where T : BaseEntity
    {
        Task CreateAsync(T model, bool saved = true);
        Task EditAsync(T model, bool saved = true);
        Task RemoveAsync(Guid id, bool saved = true);
        Task RemoveAsync(T model, bool saved = true);
        Task Save();
        Task<T> GetOneByIdAsync(Guid id);
        IQueryable<T> GetAllAsync();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllOrderAsync(bool asc = true);//排序

        IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}
