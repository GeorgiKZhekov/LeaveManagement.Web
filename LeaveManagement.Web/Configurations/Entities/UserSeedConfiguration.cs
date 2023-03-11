using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities;

public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
{

    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        var hasher = new PasswordHasher<Employee>();
        builder.HasData(
                new Employee
                {
                    Id = "b37900c7-8840-41a7-adc1-db1666502657",
                    Email = "gtothejo@gmail.com",
                    NormalizedEmail = "GTOTHEJO@GMAIL.COM",
                    UserName = "gtothejo@gmail.com",
                    NormalizedUserName = "GTOTHEJO@GMAIL.COM",
                    FirstName = "Georgi",
                    LastName = "Zhekov",
                    PasswordHash = hasher.HashPassword(null, "2:Kqvhg7x2JzCr!"),
                    EmailConfirmed = true

                },
                new Employee
                {
                    Id = "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42",
                    Email = "jototheg@gmail.com",
                    NormalizedEmail = "JOTOTHEG@GMAIL.COM",
                    UserName = "jototheg@gmail.com",
                    NormalizedUserName = "JOTOTHEG@GMAIL.COM",
                    FirstName = "Ioana",
                    LastName = "Palova",
                    PasswordHash = hasher.HashPassword(null, "2:Kqvhg7x2JzCr!"),
                    EmailConfirmed = true
                }
            );
    }
}