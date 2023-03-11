using LeaveManagement.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities;

public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
{

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
                new IdentityRole
                {
                    Id = "FB04C3E1-2134-48FB-A187-44107D90ED38",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "FAE750D3-5866-42F9-A55F-E68349AF69F1",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
            ); ;
    }
}