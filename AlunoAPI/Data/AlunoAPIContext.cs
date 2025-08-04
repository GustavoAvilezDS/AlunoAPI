using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlunoAPI.models;

namespace AlunoAPI.Data
{
    public class AlunoAPIContext : DbContext
    {
        public AlunoAPIContext (DbContextOptions<AlunoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AlunoAPI.models.Aluno> Aluno { get; set; } = default!;
    }
}
