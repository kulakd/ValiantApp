using ValiantApp.Models;
using Microsoft.AspNetCore.Identity;
using ValiantApp.Data;

namespace Valiant.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Groups.Any())
                {
                    context.Groups.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Name = "D&D Conquerors",
                            ProfileImage = "https://cdn1.naekranie.pl/media/cache/article-cover/2021/01/181687_6002d23e3a302.jpeg",
                            Desc = "Very lucklaster description of our awesome D&D Group ",
                            Category = Category.Gamers,
                            Address = new Address()
                            {
                                Street = "Fredry St",
                                City = "Poznan",
                            }
                         },
                        new Club()
                        {
                            Name = "Mirrors Edge Wannabe",
                            ProfileImage = "https://t4.ftcdn.net/jpg/01/60/39/19/360_F_160391988_n7sawy0KLPTF8TKbXbeBco05fnRAF8xs.jpg",
                            Desc = "Parkour 4 Life",
                            Category = Category.Athletes,
                            Address = new Address()
                            {
                                Street = "Zaulek Koscielny",
                                City = "Zbaszynek",
                            }
                        },
                        new Club()
                        {
                            Name = "Julia Child's Children",
                            ProfileImage = "https://www.pbs.org/food/wp-content/blogs.dir/2/files/2012/08/Tributes-Feat.jpg",
                            Desc = "Great atmosphere, interesting recipes and hands on experience. Definitely experience to have if you like cooking.",
                            Category = Category.Cooks,
                            Address = new Address()
                            {
                                Street = "Molo St",
                                City = "Sopot"
                            }
                        },
                        new Club()
                        {
                            Name = "Crazy Highschoolers",
                            ProfileImage = "https://www.pbs.org/food/wp-content/blogs.dir/2/files/2012/08/Tributes-Feat.jpg",
                            Desc = "Party Rock Anthem",
                            Category = Category.PartyPeople,
                            Address = new Address()
                            {
                                Street = "Krolowej Jadwigi St",
                                City = "Torun"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Cook off World Cup",
                            Image = "https://d-art.ppstatic.pl/kadry/k/r/1/bf/c2/609634198856a_o_medium.jpg",
                            Desc = "World Greatest cooking tournament",
                            EventCategory = EventCategory.Grill,
                            AddressId = 1,
                            Address = new Address()
                            {
                                Street = "Molo St",
                                City = "Sopot",
                            }
                        },
                        new Event()
                        {
                            Name = "Neuroshima campaign",
                            Image = "https://samequizy.pl/wp-content/uploads/2017/06/filing_images_884e32201d1c.jpg",
                            Desc = "Let's play Neuroshima, maybe it'll take less than 4years to finish it",
                            EventCategory = EventCategory.Gaming,
                            AddressId = 2,
                            Address = new Address()
                            {
                                Street = "Przedzamcze St",
                                City = "Torun"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                if (!await roleManager.RoleExistsAsync(Roles.User))
                    await roleManager.CreateAsync(new IdentityRole(Roles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "296686@stud.umk.pl";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "296686",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "Uczelniana",
                            City = "Torun",
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
                }

                string appUserEmail = "aaa@aaa.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newUser = new User()
                    {
                        UserName = "AAAA",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 ABC",
                            City = "Zbaszynek",
                        }
                    };
                    await userManager.CreateAsync(newUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newUser, Roles.User);
                }
            }
        }
    }
}
