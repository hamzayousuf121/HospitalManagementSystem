//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication2.Models;

//namespace WebApplication2
//{
//    public class Patient : Attribute, IActionFilter
//    {
//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            string accessToken = context.HttpContext.Request.Cookies["user-access-token"];
//            HospitalContext _context = context.HttpContext.RequestServices.GetRequiredService<HospitalContext>();
//            User user = _context.Users.Where(x => x.AccessToken == accessToken && x.Role.Name == "Patient").FirstOrDefault();

//            if (user == null)
//            {
//                context.Result = new RedirectResult("/Account/Login");
//            }
//        }
//        public void OnActionExecuted(ActionExecutedContext context)
//        {

//        }
//    }
//}
