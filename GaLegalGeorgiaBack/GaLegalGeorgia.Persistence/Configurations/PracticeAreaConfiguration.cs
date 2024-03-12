using GaLegalGeorgia.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Persistence.Configurations
{
    public class PracticeAreaConfiguration : IEntityTypeConfiguration<PracticeArea>
    {
        public void Configure(EntityTypeBuilder<PracticeArea> builder)
        {
            builder.HasData(new PracticeArea
            {
                Id = 1,
                Title = "სამოქალაქო სამართალი",
                Content = "წარმომადგენლობა სასამართლოში",
                TitleEn = "Civil Law",
                ContentEn = "Court Representation"
            }); 
        }
    }
}
