using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AWEARNESS.Models.Repository
{
    public class AwearnessDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<UserQRCodes> UserQRCodes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }

    }
}