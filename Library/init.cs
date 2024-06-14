using System;
using MySql.Data.MySqlClient;

namespace Library
{
    public class Init
    {
        String connectStr = "server=127.0.0.1;port=3306;user=root;password=msql_lqk;database=book;";
        public void connect_database()
        {
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                //  book表
                string sql_book = @"CREATE TABLE IF NOT EXISTS `book` (
               `id` int(8) NOT NULL AUTO_INCREMENT,
               `booktype` int(8) NOT NULL,
               `title` varchar(100) NOT NULL,
               `description` varchar(500) DEFAULT NULL, 
               PRIMARY KEY (`id`)
              ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                MySqlCommand command_book = new MySqlCommand(sql_book, conn);
                command_book.ExecuteNonQuery();
                
                //  booktype表
                string sql_booktype = @"CREATE TABLE IF NOT EXISTS `booktype` (
               `id` int(8) NOT NULL AUTO_INCREMENT, 
               `typename` varchar(50) NOT NULL,
               PRIMARY KEY (`id`)   
              ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                MySqlCommand command_booktype = new MySqlCommand(sql_booktype, conn);  
                command_booktype.ExecuteNonQuery();
                
                //  reader表
                string sql_reader = @"CREATE TABLE IF NOT EXISTS `reader` (
               `id` int(8) NOT NULL AUTO_INCREMENT,
               `readertype` int(8) NOT NULL,
               `code` varchar(8) NOT NULL, 
               `name` varchar(50) NOT NULL,
               `age` int(3) unsigned,  
               `message` varchar(500) DEFAULT NULL,
               PRIMARY KEY (`id`)
              ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                MySqlCommand command_reader = new MySqlCommand(sql_reader, conn);
                command_reader.ExecuteNonQuery();
                
                //  readertype表
                string sql_readertype = @"CREATE TABLE IF NOT EXISTS `readertype` (
               `id` int(8) NOT NULL AUTO_INCREMENT,  
               `typename` varchar(50) NOT NULL,
               PRIMARY KEY (`id`)
              ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                MySqlCommand command_readertype = new MySqlCommand(sql_readertype, conn);
                command_readertype.ExecuteNonQuery();
                
                //  borrow表
                string sql_borrow = @"CREATE TABLE IF NOT EXISTS `borrow` (
               `id` int(8) NOT NULL AUTO_INCREMENT,
               `readercode` int(8) NOT NULL,  
               `bookid` int(8) NOT NULL,
               `getdate` date,
               `outdate` date,  
               PRIMARY KEY (`id`)
              ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                MySqlCommand command_borrow = new MySqlCommand(sql_borrow, conn);
                command_borrow.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
