using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }    
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1,Title="Uçurtma Avcısı" , Price=80},
                new Book(){Id=2,Title="Kardeşimin Hikayesi" , Price=65},
                new Book(){Id=3,Title="Kürk Mantolu Madonna" , Price=100}
            };
        }
    }
}
