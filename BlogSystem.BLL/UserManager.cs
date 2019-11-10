using BlogSystem.Dto;
using BlogSystem.IBLL;
using BlogSyster.DAL;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.BLL
{
    public class UserManager : IUserManager
    {
        public async Task ChangeInformation(string email, string siteName, string imagePath)
        {
            using (IdAL.IUserService userService = new BlogSyster.DAL.UserService())
            {
                    var user = await userService.GetAllAsync().FirstAsync(m => m.Email == email);
                user.SiteName = siteName;
                user.ImagePath = imagePath;
              await userService.EditAsync(user);
            }
        }
        
        public async Task ChangePassWord(string email, string oldPwd, string newPwd)
        {
            using (IdAL.IUserService userService = new BlogSyster.DAL.UserService())
            {
               if (await userService.GetAllAsync().AnyAsync(predicate: m => m.Email == email && m.Password == oldPwd))
                {
                 var user= await userService.GetAllAsync().FirstAsync(m => m.Email == email);
                    user.Password = newPwd;
                   await userService.EditAsync(user);
                }
            }
        }

        public async Task<UserInformationDto> GetUserEmail(string email)
        {
            using (IdAL.IUserService userService = new BlogSyster.DAL.UserService())
            {
                if (await userService.GetAllAsync().AnyAsync(predicate: m => m.Email == email))
                {
                    return await userService.GetAllAsync().Where(m => m.Email == email).Select(m => new Dto.UserInformationDto()
                    {
                        ID = m.Id,
                        Email = m.Email,
                        FansCount = m.FansCount,
                        ImagePath = m.ImagePath,
                        SiteName = m.SiteName,
                        FocusCount = m.FocusCount
                    }).FirstAsync();
                }
                else
                {
                    throw new ArgumentException(message: "邮箱地址不存在");
                }
            }
        }

        public bool Login(string email, string password,out Guid userId)
        {
            using (IdAL.IUserService userService = new BlogSyster.DAL.UserService())
            {
           var user=  userService.GetAllAsync().FirstOrDefaultAsync(predicate: m=> m.Email ==email && m.Password == password);
                user.Wait();
               var data = user.Result;
                if (data == null)
                {
                    userId = new Guid();
                    return false;
                }
                else
                {
                    userId = data.Id;
                    return true;
                }
            }
        }

        public async Task Register(string email, string password)
        {
           using (IdAL.IUserService userService=new BlogSyster.DAL.UserService())
            {
              await userService.CreateAsync(new BlogSystem.User() 
              { Email = email,
                  Password = password, 
                  SiteName = "默认的小站", 
                  ImagePath ="default.png"
              });
            }
        }
    }
}
