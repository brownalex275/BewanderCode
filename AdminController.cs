// GET: Admin/FlaggedPosts



        public ActionResult FlaggedPosts(string sortOrder, string currentFilter, string searchString, int? page)



        {



            // Tanvir(23/12/16): Creating Paged List







            ViewBag.CurrentSort = sortOrder;



            var Users = from u in bc.Users



                        select u;







            if (searchString != null)



            {



                page = 1;



            }



            else



            {



                searchString = currentFilter;



            }







            if (!String.IsNullOrEmpty(searchString))



            {



                Users = Users.Where(u => u.LastName.ToLower().Contains(searchString.ToLower()) || u.FirstName.ToLower().Contains(searchString.ToLower()));







            }







            int pageSize = 20;



            int pageNumber = (page ?? 1);







            // End of PagedList











            // Create ViewModel to run list function



            FlaggedViewModel fp = new FlaggedViewModel();



            // Assemble lists to be passed to list function



            List<FlaggedViewModel> viewModels = new List<FlaggedViewModel>();



            List<ApplicationUser> applicationUsers = ac.Users.ToList();



            List<Post> posts = bc.Posts.ToList();



            //pass data to list function



            fp.FlaggedList(viewModels,



             applicationUsers,



             posts



             );



           







            return View(viewModels.ToPagedList(pageNumber, pageSize));











        }