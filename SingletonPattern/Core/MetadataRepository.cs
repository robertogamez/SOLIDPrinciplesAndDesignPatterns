using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingletonPattern.Core
{
    public class MetadataRepository
    {
        private readonly AppDbContext context;

        public MetadataRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
