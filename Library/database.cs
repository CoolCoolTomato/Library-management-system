using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    //  对数据库操作进行封装
    public class Database
    {
        private static string connectStr = "server=127.0.0.1;port=3306;user=root;password=msql_lqk;database=book;";
        private static MySqlConnection Connect = new MySqlConnection(connectStr);

        public Database()
        {
            Connect.Open();
        }

        ~Database()
        {
            Connect.Close();
        }
        //  普通sql查询
        private static string bookSql = "SELECT * FROM book WHERE id = @id";
        private static string bookTypeSql = "SELECT * FROM bookType WHERE id = @id";
        private static string readerSql = "SELECT * FROM reader WHERE code = @code";
        private static string readerTypeSql = "SELECT * FROM readerType WHERE id = @id";
        private static string borrowSql = "SELECT * FROM borrow WHERE id = @id";
        //  普普通通查询
        private static string bookTypeFindSql = "SELECT * FROM bookType";
        private static string readerTypeFindSql = "SELECT * FROM readerType";
        //  联合sql查询
        private static string bookFindSql = @"
                                    SELECT
                                        b.id AS 书籍ID,
                                        b.title AS 书籍标题,
                                        t.typeName AS 书籍种类,
                                        b.description AS 书籍描述
                                    FROM
                                        book b
                                            INNER JOIN
                                        bookType t ON b.bookType = t.id;";
        private static string readerFindSql = @"
                                    SELECT
                                        r.name AS 读者姓名,
                                        r.code AS 读者编号,
                                        r.age AS 读者年龄,
                                        r.message AS 读者信息,
                                        t.typeName AS 读者种类
                                    FROM
                                        reader r
                                            INNER JOIN
                                        readertype t ON r.readerType = t.id;";
        private static string borrowFindSql = @"
                                    SELECT 
                                        b.id AS 记录ID,
                                        b.readerCode AS 学生学号,
                                        r.name AS 学生姓名,
                                        b.bookId AS 书籍ID,
                                        t.title AS 书籍名称,
                                        b.getDate AS 借书日期,
                                        b.outdate AS 还书日期
                                    FROM
                                        borrow b
                                            INNER JOIN
                                        reader r ON b.readerCode = r.code
                                            INNER JOIN
                                        book t ON b.bookId = t.id;";
        //  操作book
        private static string bookInsertSql = "INSERT INTO book (bookType, title, description) VALUES (@bookType, @title, @description)";
        private static string bookUpdateSql = "UPDATE book SET bookType = @bookType, title = @title, description = @description WHERE id = @id";
        private static string bookDeleteSql = "DELETE FROM book WHERE id = @id";
        //  操作bookType
        private static string bookTypeInsertSql = "INSERT INTO bookType (typename) VALUES (@typename)";
        private static string bookTypeUpdateSql = "UPDATE bookType SET typename = @typename WHERE id = @id";
        private static string bookTypeDeleteSql = "DELETE FROM bookType WHERE id = @id";
        //  操作reader
        private static string readerInsertSql = "INSERT INTO reader (readerType, code, name, age, message) VALUES (@readerType, @code, @name, @age, @message)";
        private static string readerUpdateSql = "UPDATE reader SET readerType = @readerType, name = @name, age = @age, message = @message WHERE code = @code";
        private static string readerDeleteSql = "DELETE FROM reader WHERE code = @code";
        //  操作readerType
        private static string readerTypeInsertSql = "INSERT INTO readerType (typename) VALUES (@typename)";
        private static string readerTypeUpdateSql = "UPDATE readerType SET typename = @typename WHERE id = @id";
        private static string readerTypeDeleteSql = "DELETE FROM readerType WHERE id = @id";
        //  操作borrow
        private static string borrowInsertSql = "INSERT INTO borrow (readerCode, bookId, getDate, outDate) VALUES (@readerCode, @bookId, @getDate, @outDate)";
        private static string borrowUpdateSql = "UPDATE borrow SET readerCode = @readerCode, bookId = @bookId, getDate = @getDate, outDate = @outDate WHERE id = @id";
        private static string borrowDeleteSql = "DELETE FROM borrow WHERE id=@id";
        
        //
        //  查询操作
        //
        //  根据id查询书籍
        public Book GetBook(int id)
        {
            MySqlCommand cmd = new MySqlCommand(bookSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            Book book = null;
            if (sqlReader.Read())
            {
                book = new Book();
                book.id = sqlReader.GetInt32(0);
                book.bookType = sqlReader.GetInt32(1);
                book.title = sqlReader.GetString(2);
                book.description = sqlReader.GetString(3);
            }
            sqlReader.Close();
            return book;
        }
        //  根据id查询书籍分类
        public BookType GetBookType(int id)
        {
            MySqlCommand cmd = new MySqlCommand(bookTypeSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            BookType bookType = null;
            if (sqlReader.Read())
            {
                bookType = new BookType();
                bookType.id = sqlReader.GetInt32(0);
                bookType.typeName = sqlReader.GetString(1);
            }
            sqlReader.Close();
            return bookType;
        }
        //  根据code查询读者
        public Reader GetReader(int code)
        {
            MySqlCommand cmd = new MySqlCommand(readerSql, Connect);
            cmd.Parameters.AddWithValue("@code", code);
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            Reader reader = null;
            if (sqlReader.Read())
            {
                reader = new Reader();
                reader.id = sqlReader.GetInt32(0);
                reader.readerType = sqlReader.GetInt32(1);
                reader.code = sqlReader.GetInt32(2);
                reader.name = sqlReader.GetString(3);
                reader.age = sqlReader.GetInt32(4);
                reader.message = sqlReader.GetString(5);
            }
            sqlReader.Close();
            return reader;
        }
        //  根据id查询读者分类
        public ReaderType GetReaderType(int id)
        {
            MySqlCommand cmd = new MySqlCommand(readerTypeSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            ReaderType readerType = null;
            if (sqlReader.Read())
            {
                readerType = new ReaderType();
                readerType.id = sqlReader.GetInt32(0);
                readerType.typeName = sqlReader.GetString(1);
            }
            sqlReader.Close();
            return readerType;
        }
        //  根据id查询记录
        public Borrow GetBorrow(int id)
        {
            MySqlCommand cmd = new MySqlCommand(borrowSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            Borrow borrow = null;
            if (sqlReader.Read())
            {
                borrow = new Borrow();
                borrow.id = sqlReader.GetInt32(0);
                borrow.readerCode = sqlReader.GetInt32(1);
                borrow.bookId = sqlReader.GetInt32(2);
                borrow.getDate = sqlReader.GetDateTime(3);
                if (!sqlReader.IsDBNull(4))
                {
                    borrow.outDate = sqlReader.GetDateTime(4);
                }
            }
            sqlReader.Close();
            return borrow;
        }
        
        //
        //  操作book
        //
        //  添加book
        public bool InsertBook(int bookType, string title, string description) {
            MySqlCommand cmd = new MySqlCommand(bookInsertSql, Connect);
            cmd.Parameters.AddWithValue("@bookType", bookType);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        //  更新book
        public bool UpdateBook(int id, int bookType, string title, string description) {
            MySqlCommand cmd = new MySqlCommand(bookUpdateSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@bookType", bookType);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true; 
            }
            return false;
        } 
        //  删除book
        public bool DeleteBook(int id) {
            MySqlCommand cmd = new MySqlCommand(bookDeleteSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        
        //
        //  操作bookType
        //
        //  添加bookType
        public bool InsertBookType(string typeName) {
            MySqlCommand cmd = new MySqlCommand(bookTypeInsertSql, Connect); 
            cmd.Parameters.AddWithValue("@typeName", typeName);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        //  更新bookType
        public bool UpdateBookType(int id, string typeName) {
            MySqlCommand cmd = new MySqlCommand(bookTypeUpdateSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@typeName", typeName); 
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false; 
        }
        //  删除bookType
        public bool DeleteBookType(int id) {
            MySqlCommand cmd = new MySqlCommand(bookTypeDeleteSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true; 
            }
            return false;
        }
        
        //
        //  操作reader
        //
        //  添加reader
        public bool InsertReader(int readerType, int code, string name, int age, string message) {
            MySqlCommand cmd = new MySqlCommand(readerInsertSql, Connect);
            cmd.Parameters.AddWithValue("@readerType", readerType); 
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age); 
            cmd.Parameters.AddWithValue("@message", message);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            } 
            return false;
        }
        //  更新reader
        public bool UpdateReader(int code, int readerType, string name, int age, string message) {
            MySqlCommand cmd = new MySqlCommand(readerUpdateSql, Connect);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@readerType", readerType);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@message", message);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;  
            }
            return false;
        }
        //  删除reader
        public bool DeleteReader(int code) {
            MySqlCommand cmd = new MySqlCommand(readerDeleteSql, Connect);
            cmd.Parameters.AddWithValue("@code", code);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false; 
        }
        
        //
        //  操作readerType
        //
        //  添加readerType
        public bool InsertReaderType(string typeName) {
            MySqlCommand cmd = new MySqlCommand(readerTypeInsertSql, Connect);
            cmd.Parameters.AddWithValue("@typeName", typeName);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        //  更新readerType
        public bool UpdateReaderType(int id, string typeName) {
            MySqlCommand cmd = new MySqlCommand(readerTypeUpdateSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@typeName", typeName);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        //  删除readerType
        public bool DeleteReaderType(int id) {
            MySqlCommand cmd = new MySqlCommand(readerTypeDeleteSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0) {
                return true;
            }
            return false;
        }
        
        //
        //  操作borrow
        //
        //  添加borrow
        public bool InsertBorrow(int readerCode, int bookId, DateTime getDate, DateTime outDate)
        {
            MySqlCommand cmd = new MySqlCommand(borrowInsertSql, Connect);
            cmd.Parameters.AddWithValue("@readerCode", readerCode);
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.Parameters.AddWithValue("@getDate", getDate); 
            cmd.Parameters.AddWithValue("@outDate", outDate);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
        //  更新borrow
        public bool UpdateBorrow(int id, int readerCode, int bookId, DateTime getDate, DateTime outDate)
        {
            MySqlCommand cmd = new MySqlCommand(borrowUpdateSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@readerCode", readerCode);
            cmd.Parameters.AddWithValue("@bookId", bookId);  
            cmd.Parameters.AddWithValue("@getDate", getDate);
            cmd.Parameters.AddWithValue("@outDate", outDate);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
        //  删除borrow
        public bool DeleteBorrow(int id)
        {
            MySqlCommand cmd = new MySqlCommand(borrowDeleteSql, Connect);
            cmd.Parameters.AddWithValue("@id", id);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
        
        //
        //  数据绑定
        //
        //  绑定book
        public bool BindBook(BindingSource bindingSource) {
            try {
                MySqlDataAdapter bookAdapter = new MySqlDataAdapter(bookFindSql, Connect); 
                DataTable dataTable = new DataTable();
                bookAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable; 
                return true;
            }
            catch (Exception ex) {
                return false; 
            }
        }
        //  绑定bookType
        public bool BindBookType(BindingSource bindingSource){
            try {
                MySqlDataAdapter bookTypeAdapter = new MySqlDataAdapter(bookTypeFindSql, Connect);
                DataTable dataTable = new DataTable();
                bookTypeAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        //  绑定reader
        public bool BindReader(BindingSource bindingSource){
            try {
                MySqlDataAdapter readerAdapter = new MySqlDataAdapter(readerFindSql, Connect);
                DataTable dataTable = new DataTable();
                readerAdapter.Fill(dataTable); 
                bindingSource.DataSource = dataTable;
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        //  绑定readerType
        public bool BindReaderType(BindingSource bindingSource){
            try {
                MySqlDataAdapter readerTypeAdapter = new MySqlDataAdapter(readerTypeFindSql, Connect);
                DataTable dataTable = new DataTable();
                readerTypeAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        //  绑定borrow
        public bool BindBorrow(BindingSource bindingSource){
            try {
                MySqlDataAdapter borrowAdapter = new MySqlDataAdapter(borrowFindSql, Connect);
                DataTable dataTable = new DataTable();
                borrowAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
