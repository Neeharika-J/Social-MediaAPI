using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMApi.dbcontext;
using SMApi.DTO;
using SMApi.Helper;
using SMApi.Interfaces;
using SMApi.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace SMApi.Services
{
    public class UserService:IUserService
    {
        private readonly ApplicationDBContext dbContext;
        private readonly IMapper  mapper;
        private readonly JwtTokenGenerator jwtTokenGenerator;
        public UserService(ApplicationDBContext dbContext, IMapper mapper,JwtTokenGenerator jwtTokenGenerator)
        {
            this.dbContext=dbContext;
            this.mapper = mapper;
            this.jwtTokenGenerator = jwtTokenGenerator;  
        }

        public async Task<(string token,DateTime expiry)> createUserAsync(UserCreateDTO userCreateDTO) 
        { 
            var smuser=mapper.Map<SMUser>(userCreateDTO);
            smuser.registerDate = DateTime.UtcNow;
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(userCreateDTO.password);
            var (Token,Expiry) = jwtTokenGenerator.GenerateToken(smuser);

            smuser.userSecurity = new UserSecurity
            {
                password = hashedpassword,
                //verificationToken = Token,
                //tokenExpiry=Expiry
            };

            dbContext.SMUser.Add(smuser);

            await dbContext.SaveChangesAsync();
            //return mapper.Map<UserReadDTO>(smuser);
            return (Token, Expiry);
        }

        public async Task<IEnumerable<UserReadDTO>> getAllUsersAsync()
        {
            IEnumerable<SMUser> smuserlist = await dbContext.SMUser.ToListAsync();
            return mapper.Map<IEnumerable<UserReadDTO>>(smuserlist);
        }

        public async Task<UserReadDTO> getUserByIdAsync(int userid)
        {
            var dto = await dbContext.SMUser.FirstOrDefaultAsync(u => u.userId == userid);
            return mapper.Map<UserReadDTO>(dto);
        }

        public async Task<UserReadDTO> updateUserByIdAsync(UserUpdateDTO userDto)
        {
            bool ifalreadyexists = await dbContext.SMUser.AnyAsync(u => u.email == userDto.email && u.userId != userDto.userId);
            if (ifalreadyexists)
            {
                return null;
            }
            //bring old information 
            var oldsmuser = await dbContext.SMUser.FirstOrDefaultAsync(u =>u.userId==userDto.userId);
            //new infomation from user
            var newsmuser = mapper.Map<SMUser>(userDto);
            oldsmuser.userName=newsmuser.userName;
            oldsmuser.gender=newsmuser.gender;
            oldsmuser.email=newsmuser.email;
            await dbContext.SaveChangesAsync();
            return mapper.Map<UserReadDTO>(await dbContext.SMUser.FirstOrDefaultAsync(u => u.userId == userDto.userId));
        }

        public async Task<AuthResponseDTO> loginUserAsync(LoginDTO loginDto)
        {
            AuthResponseDTO authResponseDTO = new AuthResponseDTO();
            var user=await dbContext.SMUser.FirstOrDefaultAsync(u=>u.email==loginDto.email);
            var password = await dbContext.UserSecurity.Where(u => u.userId == user.userId).Select(u => u.password).FirstOrDefaultAsync();    
            
            if (BCrypt.Net.BCrypt.Verify(loginDto.password,password))
            {
                var(token, expiry)= jwtTokenGenerator.GenerateToken(user);
                authResponseDTO.token = token;
                authResponseDTO.expiry = expiry;
                authResponseDTO.userReadDTO = mapper.Map<UserReadDTO>(user);
                authResponseDTO.message = "Login Successful";
            }
            else
            {
                authResponseDTO.message = "User Not Found";
            }
            return authResponseDTO;
        }

        public async Task deleteUserAsync(string email)
        {
            var user = await dbContext.SMUser.FirstOrDefaultAsync(u => u.email == email);
            if (user != null)
            {
                dbContext.SMUser.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
