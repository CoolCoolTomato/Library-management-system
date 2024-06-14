using System.Windows.Forms;

namespace Library
{
    public class Common
    {
        //  获取书籍
        public bool GetBook(TextBox t1, TextBox t2, Database database)
        {
            int id = 0;
            bool flag = int.TryParse(t1.Text, out id);
            if (!flag)
            {
                return false;
            }
            Book book = database.GetBook(id);
            if (book != null)
            {
                t2.Text = book.title;
                return true;
            }
            return false;
        }
        //  获取书籍分类
        public bool GetBookType(TextBox t1, TextBox t2, Database database)
        {
            int id = 0;
            bool flag = int.TryParse(t1.Text, out id);
            if (!flag)
            {
                return false;
            }
            BookType bookType = database.GetBookType(id);
            if (bookType != null)
            {
                t2.Text = bookType.typeName;
                return true;
            }
            return false;
        }
        //  获取读者
        public bool GetReader(TextBox t1, TextBox t2, Database database)
        {
            int code = 0;
            bool flag = int.TryParse(t1.Text, out code);
            if (!flag)
            {
                return false;
            }
            Reader reader = database.GetReader(code);
            if (reader != null)
            {
                t2.Text = reader.name;
                return true;
            }
            return false;
        }
        //  获取读者分类
        public bool GetReaderType(TextBox t1, TextBox t2, Database database)
        {
            int id = 0;
            bool flag = int.TryParse(t1.Text, out id);
            if (!flag)
            {
                return false;
            }
            ReaderType readerType = database.GetReaderType(id);
            if (readerType != null)
            {
                t2.Text = readerType.typeName;
                return true;
            }
            return false;
        }
    }
}