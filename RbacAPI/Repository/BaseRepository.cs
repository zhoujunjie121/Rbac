using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<TEntity, Key> : IBaseRepository<TEntity, Key> where TEntity : class where Key : struct
    {
        //private readonly MyDbContext myDbContext;

        //public BaseRepository(MyDbContext myDbContext)
        //{
        //    this.myDbContext = myDbContext;
        //}

        protected MyDbContext myDbContext;

        /// <summary>
        /// 泛型添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int AddInfo(TEntity t)
        {
            myDbContext.Set<TEntity>().Add(t);
            return myDbContext.SaveChanges();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public int AddAll(List<TEntity> ts)
        {
            foreach (var item in ts)
            {
                myDbContext.Set<TEntity>().Add(item);
            }
            return myDbContext.SaveChanges();
        }

        /// <summary>
        /// 泛型修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdInfo(TEntity t)
        {
            myDbContext.Entry<TEntity>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return myDbContext.SaveChanges();
        }

        /// <summary>
        /// 查询单条数据  反填
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity GetBity(Key key)
        {
            var list = myDbContext.Set<TEntity>().Find(key);
            return list;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(Key id)
        {
            var list = myDbContext.Set<TEntity>().Find(id);
            myDbContext.Remove(list);
            return myDbContext.SaveChanges();
        }

        /// <summary>
        /// 单条删除  根据表达式删除
        /// </summary>
        /// <returns></returns>
        public int Deletelame(Expression<Func<TEntity, bool>> predicate)
        {
            var list = myDbContext.Set<TEntity>().Where(predicate);
            myDbContext.RemoveRange(list);
            return myDbContext.SaveChanges();
        }


        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> QueryAll()
        {
            var list = myDbContext.Set<TEntity>().ToList();
            return list;
        }

        public IQueryable<TEntity> pageList()
        {
            var list = myDbContext.Set<TEntity>().AsQueryable();
            return list;
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            var list = myDbContext.Set<TEntity>().Where(predicate);
            return list;
        }

        /// <summary>
        /// 获取所有数据  List类型
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
             var list= myDbContext.Set<TEntity>().Where(predicate).ToList();

            return list;
        }

    }
}
