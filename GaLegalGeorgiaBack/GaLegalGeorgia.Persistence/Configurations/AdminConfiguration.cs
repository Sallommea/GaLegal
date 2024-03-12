using GaLegalGeorgia.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Persistence.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<AdminModel>
    {
        public void Configure(EntityTypeBuilder<AdminModel> builder)
        {
            builder.HasData(new AdminModel
            {
               Id = 1,
                Username= "givi.gviniashvili1@gmail.com",
                PasswordHash = "4682f3179bafb321e4257257fdb8d15cdadcc526a7cd9357d3440384df739f51"
            });
        }
    }
}
