using Microsoft.EntityFrameworkCore;
using WebApi03.Models;

namespace WebApi03.Data
{
    public class SQL
    {
        private readonly ModelBuilder _builder;

        public SQL(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Authors>(a =>
            {
                a.HasData(new Authors
                {
                    AuthorsID = 1,
                    FullName = "Phan Hồ Anh Kha",
                });
                a.HasData(new Authors
                {
                    AuthorsID = 2,
                    FullName = "Cao Mai Hương",
                });
            });

            _builder.Entity<Books>(b =>
            {
                b.HasData(new Books
                {
                    BookID = 1,
                    Title = "Bảy Viên Ngọc Rồng",
                    Description = "Hành trình đi tìm ngọc rồng của cậu bé Songoku.",
                    IsRead = true,
                    DateRead = DateTime.Now,
                    Rate = 10,
                    Genre = null,
                    CoverUrl = "https://images.example.com/Book.jpg",
                    DateAdded = DateTime.Now,
                    PublisherID = 1,
                });

                b.HasData(new Books
                {
                    BookID = 2,
                    Title = "Naruto",
                    Description = "Hành trình phưu lưu của cậu bé mồ côi.",
                    IsRead = true,
                    DateRead = DateTime.Now,
                    Rate = 5,
                    Genre = null,
                    CoverUrl = "https://images.example.com/BookNaruto.jpg",
                    DateAdded = DateTime.Now,
                    PublisherID = 2,
                }); ;
            });


            _builder.Entity<Publishers>(c =>
            {
                c.HasData(new Publishers
                {
                    PublishersID = 1,
                    Name = "Khổng Tử",
                });
                c.HasData(new Publishers
                {
                    PublishersID = 2,
                    Name = "Hồ Chí Minh",
                });
            });
        }
    }
}

