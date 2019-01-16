﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EspaceClient.Entities;
using Microsoft.EntityFrameworkCore;

namespace EspaceClient.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
           : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
