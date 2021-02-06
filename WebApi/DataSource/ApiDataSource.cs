using WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataSource
{
    public class ApiDataSource
    {
        public static ApiDataSource Current { get; } = new ApiDataSource();
        public List<Categories> categories { get; set; }
        public ApiDataSource()
        {
            categories = new List<Categories>()
            {
                new Categories()
                {
                    Id=0,
                    Name = "Macera",
                    bookOfInterests = new List<BookOfInterests>()
                    {
                        new BookOfInterests()
                        {
                            Id = 1,
                            Name = "Kuantum Casusu",
                            Author = "David"
                        },
                        new BookOfInterests()
                        {
                            Id = 2,
                            Name = "Sahte Krallık",
                            Author = "Sardugo"
                        },
                        new BookOfInterests()
                        {
                            Id = 3,
                            Name = "Yaşam Sinyali",
                            Author = "Jose Rodrigues"
                        },
                    }
                },
                 new Categories()
                {
                    Id=1,
                    Name = "Korku",
                    bookOfInterests = new List<BookOfInterests>()
                    {
                        new BookOfInterests()
                        {
                            Id = 1,
                            Name = "Gölgeler",
                            Author = "Jack London"
                        },
                        new BookOfInterests()
                        {
                            Id = 2,
                            Name = "Cinayet Şirketi",
                            Author = "Jack London"
                        },
                        new BookOfInterests()
                        {
                            Id = 3,
                            Name = "Ruh Kırıcı",
                            Author = "Sebastian"
                        },
                    }
                },
                  new Categories()
                {
                    Id=2,
                    Name = "Tarih",
                    bookOfInterests = new List<BookOfInterests>()
                    {
                        new BookOfInterests()
                        {
                            Id = 1,
                            Name = "Barbarossa",
                            Author = "İskender Pala"
                        },
                        new BookOfInterests()
                        {
                            Id = 2,
                            Name = "Home Deus",
                            Author = "Noah Harrari"
                        },
                        new BookOfInterests()
                        {
                            Id = 3,
                            Name = "Sultanın Korsanları",
                            Author = "Emrah Safa"
                        },
                    }
                }
            };
        }
    }
}