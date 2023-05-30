using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using N_Tire.BusinessLogic.Abstractions;
using N_Tire.BusinessLogic.Models.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace N_Tire.BusinessLogic.Logics
{
    public class AccountLogic:IAccountLogic
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateRole(CreateRoleUIDTO r)
        {
            var role = await _roleManager.Roles.Where(x=> x.Name == r.RoleName).FirstOrDefaultAsync();
            if(role == null)
            {
                IdentityRole newRole = new IdentityRole();
                newRole.Name = r.RoleName;
                await _roleManager.CreateAsync(newRole);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> Register(RegisterUIDTO r)
        {
            var user = await _userManager.FindByEmailAsync(r.Email);
            if(user == null)
            {
                IdentityUser newUser = new IdentityUser();
                newUser.UserName = r.UserName;
                newUser.Email = r.Email;
                await _userManager.CreateAsync(newUser, r.Password);
                await _userManager.AddToRoleAsync(newUser, "User");
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> Login(LoginUIDTO l)
        {
            var user = await _userManager.FindByEmailAsync(l.Email);
            if(user != null)
            {

               var result = await _userManager.CheckPasswordAsync(user, l.Password);
                if (result)
                {
                    await _signInManager.PasswordSignInAsync(user,l.Password, true,false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Update(UpdateUIDTO u)
        {
            var user = await _userManager.FindByEmailAsync(u.Email);
            if(user != null)
            {
                var checkPass = await _userManager.CheckPasswordAsync(user, u.oldPassword);
                if (checkPass)
                {
                    user.UserName = u.UserName;
                    await _userManager.ChangePasswordAsync(user, u.oldPassword, u.newPassword);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
