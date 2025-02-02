using AmericanGirlLookup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AmericanGirlLookup.Models
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            // (RoleManager) Seed roles into database
            using (var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
            {
                await SeedUserRolesAsync(roleManager);
            }

            // (Database Context) Seed users and dolls into database 
            using (var databaseContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            using (var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>())
            {
                await SeedUserInfoAsync(databaseContext, userManager);

                // TODO: Don't skip entire default adding process just because a user created their own custom data
                if (!databaseContext.Doll.Any())
                {
                    SeedDollInfo(databaseContext);
                }

                await databaseContext.SaveChangesAsync();
            }
        }

        private static async Task SeedUserRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[]
            {
                "Administrator",
                "Moderator",
                "Doll Curator",
                "Member"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedUserInfoAsync(ApplicationDbContext databaseContext, UserManager<IdentityUser> userManager)
        {
            // Spooooky plain text password!
            string demoPassword = "DemoDummy5$";

            var demoUsers = new (string Role, string Email)[]
            {
                ("Moderator", "john.doe@example.com"),
                ("Moderator", "jane.doe@example.com"),
                ("Doll Curator", "penny.tool@example.com"),
                ("Member", "justin.case@example.com"),
                ("Member", "russell.sprout@example.com")
            };

            foreach (var demoUser in demoUsers)
            {
                if (await userManager.FindByEmailAsync(demoUser.Email) != null) { continue; }

                var user = new IdentityUser
                {
                    UserName = demoUser.Email,
                    Email = demoUser.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                await userManager.CreateAsync(user, demoPassword);
                await userManager.AddToRoleAsync(user, demoUser.Role);
            }
        }

        private static void SeedDollInfo(ApplicationDbContext databaseContext)
        {
            // Seeding test dolls
            databaseContext.Doll.AddRange(
                new Doll
                {
                    DollName = "Samantha Parkington",
                    ReleaseDate = new DateTime(1986, 5, 1),
                    RetirementDate = new DateTime(2008, 5, 1),
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$82",
                    CurrentValue = "$200+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://images.mattel.net/image/upload/w_2000,c_scale/f_auto/q_auto:low/shop-ag-prod/files/x0bpgxbhssyy1y4onzqq.png?v=1737671601"
                },
                new Doll
                {
                    DollName = "Molly McIntire",
                    ReleaseDate = new DateTime(1986, 5, 1),
                    RetirementDate = new DateTime(2013, 1, 1),
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$82",
                    CurrentValue = "$150+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/amjayic1rpnqb2dheah6.png?v=1734029972"
                },
                new Doll
                {
                    DollName = "Kirsten Larson",
                    ReleaseDate = new DateTime(1986, 5, 1),
                    RetirementDate = new DateTime(2010, 1, 1),
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$82",
                    CurrentValue = "$300+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/qwhcke2rcvv6t7s1qfuv.png?v=1734029993"
                },
                new Doll
                {
                    DollName = "Felicity Merriman",
                    ReleaseDate = new DateTime(1991, 9, 1),
                    RetirementDate = new DateTime(2011, 1, 1),
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$82",
                    CurrentValue = "$250+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://i.ebayimg.com/images/g/bhoAAOSw--BhmXad/s-l1200.jpg"
                },
                new Doll
                {
                    DollName = "Addy Walker",
                    ReleaseDate = new DateTime(1993, 9, 1),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$84",
                    CurrentValue = "$110+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/y58rscjo0qujzyl4tkwb.png?v=1736554408"
                },
                new Doll
                {
                    DollName = "Josefina Montoya",
                    ReleaseDate = new DateTime(1997, 9, 1),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$84",
                    CurrentValue = "$110+",
                    OwningCompany = "Pleasant Company",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/nnrdm3isadm6jlg1mikm.png?v=1734029981"
                },
                new Doll
                {
                    DollName = "Kit Kittredge",
                    ReleaseDate = new DateTime(2000, 7, 1),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$84",
                    CurrentValue = "$110+",
                    OwningCompany = "American Girl",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/nvkhqqrwni3kjerhmy9p.png?v=1736965234"
                },
                new Doll
                {
                    DollName = "Julie Albright",
                    ReleaseDate = new DateTime(2007, 9, 10),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$90",
                    CurrentValue = "$110+",
                    OwningCompany = "American Girl",
                    ImagePath = "https://images.mattel.net/image/upload/w_430,c_scale/f_auto/q_auto:low/shop-ag-prod/files/onm4tf0bp1qvlkrcwdta.png?v=1734029969"
                },
                new Doll
                {
                    DollName = "Rebecca Rubin",
                    ReleaseDate = new DateTime(2009, 5, 31),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "American Girls Collection",
                    OriginalPrice = "$95",
                    CurrentValue = "$110+",
                    OwningCompany = "American Girl",
                    ImagePath = "https://www.americangirl.com/cdn/shop/files/gr6pta6mwkjoxqfyd6yh_691877c5-6baf-41d9-9ac6-538d1e62a91e.png?v=1724772705"
                },
                new Doll
                {
                    DollName = "Nanea Mitchell",
                    ReleaseDate = new DateTime(2017, 8, 21),
                    RetirementDate = DateTime.MinValue, // Still available
                    CharacterType = "Historical",
                    Collection = "BeForever",
                    OriginalPrice = "$115",
                    CurrentValue = "$115",
                    OwningCompany = "American Girl",
                    ImagePath = "https://images.mattel.net/image/upload/w_3024,c_scale/f_auto/q_auto:low/shop-ag-prod/files/hlar0w7u1gux9ec8xksi.png?v=1729720706"
                }
            );
        }
    }
}
