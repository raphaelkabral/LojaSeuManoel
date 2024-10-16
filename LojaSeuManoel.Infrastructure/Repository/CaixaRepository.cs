using LojaSeuManoel.Domain.IRepository;
using LojaSeuManoel.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSeuManoel.Infrastructure.Repository
{   
    public class CaixaRepository : Repository<Caixa>, ICaixaRepository
    {
        public CaixaRepository(ApplicationDbContext context) : base(context) { }
    }
}
