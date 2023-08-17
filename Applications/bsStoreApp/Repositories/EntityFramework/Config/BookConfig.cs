using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityFramework.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, CategoryId = 1, Title = "Uçurtma Avcısı", Price = 55 },
                new Book { Id = 2, CategoryId = 2, Title = "Kürk Mantolu Madonna", Price = 85 },
                new Book { Id = 3, CategoryId = 1, Title = "mindshare bypass Rubber microchip", Price = 500 }
            );
        }
    }
}
