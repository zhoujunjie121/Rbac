using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using AutoMapper;

namespace Application
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : class,new ()
        where TDto : class,new()
    {
        private readonly IBaseRepository<TEntity, int> repository;
        private readonly IMapper mapper;

        public BaseService(IBaseRepository<TEntity, int> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int Create(TDto dto)
        {
            return repository.AddInfo(mapper.Map<TEntity>(dto));
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <returns></returns>
        public List<TEntity> Query()
        {
            return repository.QueryAll();
        }
        /// <summary>
        /// 单个查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TDto Find(int id)
        {
            return mapper.Map<TDto>(repository.GetBity(id));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual int Update(TDto dto)
        {
            return repository.UpdInfo(mapper.Map<TEntity>(dto));
        }

    }
}
