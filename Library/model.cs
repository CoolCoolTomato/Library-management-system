using System;

namespace Library
{
    public class Book
    {
        public int id;
        public int bookType;
        public string title;
        public string description;
    }

    public class Reader
    {
        public int id;
        public int code;
        public string name;
        public int readerType;
        public int age;
        public string message;
    }

    public class Borrow
    {
        public int id;
        public int readerCode;
        public int bookId;
        public DateTime getDate;
        public DateTime outDate;
    }

    public class BookType
    {
        public int id;
        public string typeName;
    }

    public class ReaderType
    {
        public int id;
        public string typeName;
    }
}