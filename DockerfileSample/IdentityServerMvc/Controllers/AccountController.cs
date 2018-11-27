using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServerMvc.Models;
using IdentityServerMvc.Models.AccountViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityServerMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        #region 登录
        public IActionResult Login(string returnUrl=null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl=null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("用户登录");
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(model.Password, "密码错误！");
            }
            return View(model);
        }
        #endregion

        #region 注册
        public IActionResult Register(string rerurnUrl = null)
        {
            ViewData["ReturnUrl"] = rerurnUrl;
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rerurnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model,string rerurnUrl=null)
        {
            ViewData["ReturnUrl"] = rerurnUrl;
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    NormalizedEmail = model.Email
                };
                var identityResult = await _userManager.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    _logger.LogInformation("用户注册成功");
                    await _signInManager.SignInAsync(user, false);
                    _logger.LogInformation("用户登录");
                    return RedirectToLocal(rerurnUrl);
                }
                AddErrors(identityResult);
            }
            return View(model);
        }
        #endregion

        #region 登出
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("用户登出");
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region helps

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion
    }
}