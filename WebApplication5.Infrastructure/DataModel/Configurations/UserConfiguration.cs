using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication5.Infrastructure.Domain.Users;

namespace WebApplication5.Infrastructure.DataModel.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(d => d.Id).IsUnique();
        }
    }
}
