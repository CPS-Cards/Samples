using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPCL.Repositories
{
    public class MyNewTableRepository : BaseRepository<MyNewTable, MyDataContext>
    {

        private readonly MyDataContext _context;

        public MyNewTableRepository(MyDataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MyNewTable> GetWelcomeByWelcomeTypeName(string welcomeType) => await _context.MyNewTable
                .Where(m => m.MyField.Equals(welcomeType))
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}
