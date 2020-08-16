using DoctorPatient.Infrastructure;
using DoctorPatient.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorPatient.Startup))]
namespace DoctorPatient
{
    public partial class Startup
    {
        private HospitalDbContext db = new HospitalDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
            
        }
    
        public void CreateRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            
            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Doctor"))
            {
                role = new IdentityRole();
                role.Name = "Doctor";
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("Patient"))
            {
                role = new IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);

            }
            else
            {
                
            }
        }
  

    }
}

