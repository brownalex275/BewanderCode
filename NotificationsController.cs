 public ActionResult FlagNotification(int postID)



        {



            Notifications notification = new Notifications();



            notification.MessageID = postID;



            notification.MessageType = 2;



            notification.Content = "New Flagged Post!";



            notification.DateTime = DateTime.Now;



            notification.isread = false;



            notification.data = null;



            notification.UserID = null;







            if (ModelState.IsValid)



            {



                db.Notifications.Add(notification);



                db.SaveChanges();



               



            }



            return RedirectToAction("Index");



        }