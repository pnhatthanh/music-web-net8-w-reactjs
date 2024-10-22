using Microsoft.EntityFrameworkCore;
using MusicApi.Data.Data;
using MusicApi.Data.Models;
using MusicApi.Infracstructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Infracstructure.Repositories
{
    internal class UserRepository(ApplicationDbContext context)
        : BaseRepository<User>(context), IUserRepository
    {
    }
}
