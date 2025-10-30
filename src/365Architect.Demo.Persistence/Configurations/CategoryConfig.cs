using _365Architect.Demo.Domain.Constants;
using _365Architect.Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Persistence.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasColumnName(CategoryConst.FIELD_DESCRIPTION).HasMaxLength(CategoryConst.DESCRIPTION_MAX_LENGTH);

            builder.Property(x => x.CreatedAt)
              .HasColumnName(CategoryConst.FIELD_CREATED_AT);

            builder.Property(x => x.UpdatedAt)
                   .HasColumnName(CategoryConst.FIELD_UPDATED_AT);

            builder.ToTable(CategoryConst.TABLE_NAME);

        }
    }
}
