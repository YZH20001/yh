using BlogSystem;
using BlogSystem.IdAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace BlogSyster.DAL
{
    public class BaseService<T> : IBaseServices<T> where T : BaseEntity, new()
    {
        private readonly BlogContent _db;//只读
        public BaseService(BlogContent db)
        {
            this._db = db;
        }
        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved) await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;//EF关闭检查
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
        /// <summary>
        /// 返回所有未被删除的数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllAsync()
        {
            return _db.Set<T>().Where(m => !m.IsRemove).AsNoTracking();
        }

        public IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            return GetAllAsync().Skip(pageSize * pageIndex).Take(pageSize);//跳过
        }

        public IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllOrderAsync(asc).Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllOrderAsync(bool asc = true)
        {
            var datas = GetAllAsync();
            //升序
            if (asc)
            {
                datas = datas.OrderBy(m => m.CreateTime);
            }
            else
            {
                datas = datas.OrderByDescending(m => m.CreateTime);

            }
            return datas;
        }

        public async Task<T> GetOneByIdAsync(Guid id)
        {
            return await GetAllAsync().FirstAsync(predicate: m => m.Id == id);
        }

        public async Task RemoveAsync(Guid id, bool saved = false)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;//EF关闭检查
            var t = new T() { Id = id };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemove = true;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.Id, saved);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
