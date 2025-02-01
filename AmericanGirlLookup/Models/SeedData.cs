using AmericanGirlLookup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace AmericanGirlLookup.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Users.Any())
                {

                    var hasher = new PasswordHasher<IdentityUser>();

                    // Spooooky plain text password!
                    string demoPassword = "DemoDummy5$";

                    // Seeding demo users
                    context.Users.AddRange(
                        new IdentityUser
                        {
                            Id = "c192f2fa-5db2-4976-983b-80599e617e8a",
                            UserName = "john.doe@example.com",
                            Email = "john.doe@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "JOHN.DOE@EXAMPLE.COM",
                            NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                            PasswordHash = hasher.HashPassword(null, demoPassword)
                        },
                        new IdentityUser
                        {
                            Id = "1b260f88-d355-46f9-ad21-2d3f8555845c",
                            UserName = "jane.doe@example.com",
                            Email = "jane.doe@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "JANE.DOE@EXAMPLE.COM",
                            NormalizedEmail = "JANE.DOE@EXAMPLE.COM",
                            PasswordHash = hasher.HashPassword(null, demoPassword)
                        },
                        new IdentityUser
                        {
                            Id = "36608445-defd-4e83-9a71-6314278f0b2a",
                            UserName = "penny.tool@example.com",
                            Email = "penny.tool@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "PENNY.TOOL@EXAMPLE.COM",
                            NormalizedEmail = "PENNY.TOOL@EXAMPLE.COM",
                            PasswordHash = hasher.HashPassword(null, demoPassword)
                        },
                        new IdentityUser
                        {
                            Id = "9fa550d0-73fe-4381-868f-90afe44ac13d",
                            UserName = "justin.case@example.com",
                            Email = "justin.case@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "JUSTIN.CASE@EXAMPLE.COM",
                            NormalizedEmail = "JUSTIN.CASE@EXAMPLE.COM",
                            PasswordHash = hasher.HashPassword(null, demoPassword)
                        },
                        new IdentityUser
                        {
                            Id = "e825d9c5-33d0-4136-95e2-f0f829087126",
                            UserName = "russell.sprout@example.com",
                            Email = "russell.sprout@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "RUSSELL.SPROUT@EXAMPLE.COM",
                            NormalizedEmail = "RUSSELL.SPROUT@EXAMPLE.COM",
                            PasswordHash = hasher.HashPassword(null, demoPassword)
                        }
                     );
                }

                if (!context.Doll.Any())
                {
                    // Seeding test dolls
                    context.Doll.AddRange(
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

                context.SaveChanges();
            }
        }
    }
}
