using AutoMapper;
using ClassLibraryEF;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdminService : BaseService<Admin, AdminDto>,IAdminService
    {
        private readonly IAdminRepository repository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AdminService(IAdminRepository repository, IMapper mapper, IConfiguration configuration) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public TokenDto GetLogin(LoginDto dto)
        {
            var query = repository.GetList(t => t.UserName == dto.UserName).FirstOrDefault();
            if (query==null)
            {
                return new TokenDto { Code = 1, msg = "该用户不存在" };
            }
            if (query.Password != Md5(dto.Password))
            {
                return new TokenDto { Code = 2, msg = "密码错误" };
            }

            //生成Token令牌
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, dto.UserName)
            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));

            //算法，签名证书
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);


            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims, //自定义声明信息
                notBefore: DateTime.UtcNow,  //创建时间
                expires: expires,   //过期时间
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new TokenDto { Code=0, msg = "登录成功",Token=jwt };
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResultDto CreateAdmin(AdminDto dto)
        {
            ResultDto result = new ResultDto();
            
            if (repository.GetList(t => t.UserName == dto.UserName.ToLower()).Count()>0)
            {
                result.Code = 500;
                result.msg = "该用户已经存在";
                return result;
            }
            dto.Password = Md5(dto.Password);
            dto.CreateTime = DateTime.Now;
            dto.LastLoginTime = null;
             repository.AddInfo(mapper.Map<Admin>(dto));
            result.Code = 0;
            result.msg = "注册成功";
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override int Update(AdminDto dto)
        {
            dto.Password = Md5(dto.Password);
            return base.Update(dto);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }

        /// <summary>
        /// 列表分页
        /// </summary>
        /// <returns></returns>
        public PageResult<AdminListDto> GetAdmin(Result dto)
        {
            var list= repository.QueryAll().AsQueryable();
            //总条数
            PageResult<AdminListDto> result = new PageResult<AdminListDto>();
            result.totalCount = list.Count();
            //总页数
            int pageCount = (int)Math.Ceiling(result.totalCount * 1.0 / dto.pageSize);
            if (dto.pageIndex > pageCount)
            {
                dto.pageIndex = 1;
            }
            //分页
            var query = list.OrderBy(t => t.AdminId).Skip((dto.pageIndex - 1) * dto.pageSize).Take(dto.pageSize).ToList();
            result.Data = mapper.Map<List<AdminListDto>>(query);
            foreach (var item in result.Data)
            {
                item.CreateTime = string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(item.CreateTime));
            }
            return result;
        }

    }
}
