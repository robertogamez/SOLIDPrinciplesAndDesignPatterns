using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SingletonPattern.Core
{
    public class WebSiteMetadata
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(40)]
        public string DefaultTheme { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }

        [Required]
        public bool LogErrors { get; set; }

        private static WebSiteMetadata instance;

        private WebSiteMetadata()
        {
        }

        public static WebSiteMetadata GetInstance()
        {
            if(instance == null)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    if(db.Metadata.Count() == 0)
                    {
                        db.Metadata.Add(new WebSiteMetadata
                        {
                            Title = "My Application",
                            AdminEmail = "admin@localhost",
                            DefaultTheme = "Summer",
                            LogErrors = true
                        });

                        db.SaveChanges();
                    }

                    instance = db.Metadata.FirstOrDefault();
                }
            }

            return instance;
        }
    }
}
