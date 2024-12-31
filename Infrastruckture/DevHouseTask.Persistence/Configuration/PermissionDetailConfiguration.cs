using DevHouseTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Persistence.Configuration
{
    public class PermissionDetailConfiguration : IEntityTypeConfiguration<PermissionDetail>
    {
        public void Configure(EntityTypeBuilder<PermissionDetail> builder)
        {
            throw new NotImplementedException();
        }
    }
}
