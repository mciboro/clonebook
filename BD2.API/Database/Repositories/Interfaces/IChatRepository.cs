﻿using BD2.API.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.API.Database.Repositories.Interfaces
{
    public interface IChatRepository : ICrudRepository<Chat>
    {
        public Task<IEnumerable<Chat>> FindUserChats(Guid userId, Guid? watcherId = null);
    }
}
