using Library.Domain.Entity;
using Library.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.DropdownMenuItem)
                .WithOne(d => d.MenuItem)
                .HasForeignKey(d => d.MenuItemId);

            modelBuilder.Entity<DropdownMenuItem>()
                .HasMany(d => d.SubMenuItems)
                .WithOne(s => s.DropdownMenuItem)
                .HasForeignKey(s => s.DropdownMenuItemId);
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<DropdownMenuItem> DropdownMenuItems { get; set; }
        public DbSet<SubMenuItem> SubMenuItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Position> StaffPositions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
    }
}
