using System.Collections.Generic;
//using CSharpStudy.Extensions;

namespace CSharpStudy
{
    public class BookRepository{
        public List<Book> GetBooks(){
            return new List<Book>{
                new Book(){ 
                    Title = "Book 1", Price =5
                },
                new Book(){ 
                    Title = "Book 2", Price =10
                },
                new Book(){ 
                    Title = "Book 3", Price =23
                },
              new Book(){ 
                    Title = "Book 4", Price =999
                }                
            };
        }
    }
} 
