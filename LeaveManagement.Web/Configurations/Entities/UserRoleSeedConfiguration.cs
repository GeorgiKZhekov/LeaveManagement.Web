using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities;

public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {

        builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "b37900c7-8840-41a7-adc1-db1666502657",
                    RoleId = "FB04C3E1-2134-48FB-A187-44107D90ED38",
                },
                new IdentityUserRole<string>
                {
                    UserId = "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42",
                    RoleId = "FAE750D3-5866-42F9-A55F-E68349AF69F1",
                }
            );
    }
}