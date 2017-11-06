using Bewander.DAL;



using Bewander.Models;



using System.ComponentModel.DataAnnotations;



using Microsoft.AspNet.Identity;



using Microsoft.AspNet.Identity.EntityFramework;







namespace Bewander.ViewModels



{



    public class NotificationsViewModel



    {



        private static BewanderContext db = new BewanderContext();



        private static ApplicationDbContext ac = new ApplicationDbContext();















        public int MessageID { get; set; }







        //Use this to flag different message types. 0 = Webmaster Notification, 1 = Administrator Notification, 2 = New User Notification







        //This composes what notifications will be put into the partial view. See _Notifications.cshtml in /Views/Shared



        public static List<NotificationsViewModel> GetNotifications(string userID)



        {







            



            List<Notifications> flags = db.Notifications.Where(i => i.MessageType == 2).ToList();



            var adminID = ac.Roles.Where(i => i.Name == "Admin").SingleOrDefault().Id;



            var admins = ac.Users.Where(u => u.Roles.Any(r => r.RoleId == adminID));



            







            try



            {



                List<Notifications> notifylist = db.Notifications.Where(i => i.UserID == userID).ToList();







                foreach (var admin in admins)



                {



                    if (admin.Id == userID)



                    {



                        foreach (var flag in flags)



                        {



                            notifylist.Add(flag);



                        }



                    }



                    







                    







                }