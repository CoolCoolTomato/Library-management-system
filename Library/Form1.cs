using System;
using MaterialSkin.Controls;

namespace Library
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            Init init = new Init();
            init.connect_database();
        }

        public Database database = new Database();
        public Common common = new Common();
        public void GetData()
        {
            database.BindBook(bindingSource1);
            database.BindBookType(bindingSource2);
            database.BindReader(bindingSource3);
            database.BindReaderType(bindingSource4);
            database.BindBorrow(bindingSource5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView4.AutoGenerateColumns = true;
            dataGridView5.AutoGenerateColumns = true;
            dataGridView6.AutoGenerateColumns = true;
        }
        //
        //  书籍信息
        //
        //  添加书籍
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBookType(textBox1, textBox2, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            string title;
            int bookType;
            string description;
            title = richTextBox3.Text;
            bool flag = int.TryParse(textBox1.Text, out bookType);
            description = richTextBox1.Text;
            if (title == "" || !flag || description == "" || textBox2.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }

            flag = database.InsertBook(bookType, title, description);
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            richTextBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            GetData();
        }
        //  更新书籍
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBookType(textBox4, textBox3, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox5.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Book book = database.GetBook(id);
            if (book == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            richTextBox4.Text = book.title;
            textBox4.Text = book.bookType.ToString();
            richTextBox2.Text = book.description;
            statusBar1.Text = "查询成功";
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            int id;
            string title;
            int bookType;
            string description;
            bool flag1 = int.TryParse(textBox5.Text, out id);
            title = richTextBox4.Text;
            bool flag2 = int.TryParse(textBox4.Text, out bookType);
            description = richTextBox2.Text;
            if (!flag1 || title == "" || !flag2 || description == "" || textBox3.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.UpdateBook(id, bookType, title, description);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            textBox5.Text = "";
            richTextBox4.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            richTextBox2.Text = "";
            GetData();
        }
        //  删除书籍
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBookType(textBox7, textBox6, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox8.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Book book = database.GetBook(id);
            if (book == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            richTextBox6.Text = book.title;
            textBox7.Text = book.bookType.ToString();
            richTextBox5.Text = book.description;
            statusBar1.Text = "查询成功";
        }
        private void materialButton3_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox8.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.DeleteBook(id);
            if (!flag)
            {
                statusBar1.Text = "删除失败";
                return;
            }
            statusBar1.Text = "删除成功";
            textBox8.Text = "";
            richTextBox6.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            richTextBox5.Text = "";
            GetData();
        }
        //  添加书籍分类
        private void materialButton4_Click(object sender, EventArgs e)
        {
            string typeName = richTextBox7.Text;
            if (typeName == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.InsertBookType(typeName);
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            richTextBox7.Text = "";
            GetData();
        }
        //  更新书籍分类
        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox9.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            BookType bookType = database.GetBookType(id);
            if (bookType == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            richTextBox8.Text = bookType.typeName;
        }
        private void materialButton5_Click(object sender, EventArgs e)
        {
            int id;
            string typename;
            bool flag = int.TryParse(textBox9.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            typename = richTextBox8.Text;
            if (typename == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.UpdateBookType(id, typename);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            textBox9.Text = "";
            richTextBox8.Text = "";
            GetData();
        }
        //  删除书籍分类
        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox10.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            BookType bookType = database.GetBookType(id);
            if (bookType == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            richTextBox9.Text = bookType.typeName;
        }
        private void materialButton6_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox10.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.DeleteBookType(id);
            if (!flag)
            {
                statusBar1.Text = "删除失败";
                return;
            }
            statusBar1.Text = "删除成功";
            textBox10.Text = "";
            richTextBox9.Text = "";
            GetData();
        }
        
        //
        // 读者信息
        //
        //  添加读者
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReaderType(textBox12, textBox11, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton7_Click(object sender, EventArgs e)
        {
            int code;
            string name;
            int age;
            int readerType;
            string message;
            bool flag1 = int.TryParse(textBox15.Text, out code);
            name = textBox13.Text;
            bool flag2 = int.TryParse(textBox14.Text, out age);
            bool flag3 = int.TryParse(textBox12.Text, out readerType);
            message = richTextBox10.Text;
            if (!flag1 || !flag2 || !flag3 || message == "" || name == "" || textBox11.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.InsertReader(readerType, code, name, age, message);
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            richTextBox10.Text = "";
            GetData();
        }
        //  更新读者
        private void button5_Click(object sender, EventArgs e)
        {
            int code;
            bool flag = int.TryParse(textBox27.Text, out code);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Reader reader = database.GetReader(code);
            if (reader == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox26.Text = reader.name;
            textBox25.Text = reader.age.ToString();
            textBox24.Text = reader.readerType.ToString();
            richTextBox11.Text = reader.message;
            statusBar1.Text = "查询成功";
        }
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReaderType(textBox24, textBox23, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton8_Click(object sender, EventArgs e)
        {
            int code;
            string name;
            int age;
            int readerType;
            string message;
            bool flag1 = int.TryParse(textBox27.Text, out code);
            name = textBox26.Text;
            bool flag2 = int.TryParse(textBox25.Text, out age);
            bool flag3 = int.TryParse(textBox24.Text, out readerType);
            message = richTextBox11.Text;
            if (!flag1 || !flag2 || !flag3 || message == "" || name == "" || textBox23.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.UpdateReader(code, readerType, name, age, message);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            textBox27.Text = "";
            textBox26.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";
            textBox23.Text = "";
            richTextBox11.Text = "";
            GetData();
        }
        //  删除读者
        private void button6_Click(object sender, EventArgs e)
        {
            int code;
            bool flag = int.TryParse(textBox18.Text, out code);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Reader reader = database.GetReader(code);
            if (reader == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox21.Text = reader.name;
            textBox22.Text = reader.age.ToString();
            textBox17.Text = reader.readerType.ToString();
            richTextBox14.Text = reader.message;
            statusBar1.Text = "查询成功";
        }
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReaderType(textBox17, textBox16, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton9_Click(object sender, EventArgs e)
        {
            int code;
            bool flag = int.TryParse(textBox18.Text, out code);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.DeleteReader(code);
            if (!flag)
            {
                statusBar1.Text = "删除失败";
                return;
            }
            statusBar1.Text = "删除成功";
            GetData();
        }
        //  添加读者分类
        private void materialButton10_Click(object sender, EventArgs e)
        {
            string typeName = richTextBox16.Text;
            bool flag = database.InsertReaderType(typeName);
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            richTextBox16.Text = "";
            GetData();
        }
        //  更新读者分类
        private void button7_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox19.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            ReaderType readerType = database.GetReaderType(id);
            if (readerType == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            statusBar1.Text = "查询成功";
            richTextBox17.Text = readerType.typeName;
        }
        private void materialButton11_Click(object sender, EventArgs e)
        {
            int id;
            string typeName;
            bool flag = int.TryParse(textBox19.Text, out id);
            typeName = richTextBox17.Text;
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.UpdateReaderType(id, typeName);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            richTextBox17.Text = "";
            textBox19.Text = "";
            GetData();
        }
        //  删除读者分类
        private void button8_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox20.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            ReaderType readerType = database.GetReaderType(id);
            if (readerType == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            statusBar1.Text = "查询成功";
            richTextBox18.Text = readerType.typeName;
        }
        private void materialButton12_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox20.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            flag = database.DeleteReaderType(id);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            richTextBox18.Text = "";
            textBox20.Text = "";
            GetData();
        }
        
        //
        //  借阅信息
        //
        //  添加借书信息
        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox32, textBox30, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox29, textBox28, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton13_Click(object sender, EventArgs e)
        {
            int readerCode;
            int bookId;
            DateTime getDate;
            bool flag1 = int.TryParse(textBox32.Text, out readerCode);
            bool flag2 = int.TryParse(textBox29.Text, out bookId);
            getDate = dateTimePicker1.Value;
            if (!flag1 || !flag2 || textBox30.Text == "" || textBox28.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.InsertBorrow(readerCode, bookId, getDate, new DateTime());
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            textBox32.Text = "";
            textBox30.Text = "";
            textBox29.Text = "";
            textBox28.Text = "";
            GetData();
        }
        //  修改借书信息
        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox35, textBox34, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox33, textBox31, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox37.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Borrow borrow = database.GetBorrow(id);
            if (borrow == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox35.Text = borrow.readerCode.ToString();
            textBox33.Text = borrow.bookId.ToString();
            dateTimePicker2.Value = borrow.getDate;
        }
        private void materialButton14_Click(object sender, EventArgs e)
        {
            int id;
            int readerCode;
            int bookId;
            DateTime getDate;
            bool flag1 = int.TryParse(textBox37.Text, out id);
            bool flag2 = int.TryParse(textBox35.Text, out readerCode);
            bool flag3 = int.TryParse(textBox33.Text, out bookId);
            getDate = dateTimePicker2.Value;
            if (!flag1 || !flag2 || !flag3 || textBox34.Text == "" || textBox31.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.UpdateBorrow(id, readerCode, bookId, getDate, new DateTime());
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            textBox37.Text = "";
            textBox35.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox31.Text = "";
            GetData();
        }
        //  删除借书信息
        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox40, textBox39, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox38, textBox36, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox41.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Borrow borrow = database.GetBorrow(id);
            if (borrow == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox40.Text = borrow.readerCode.ToString();
            textBox38.Text = borrow.bookId.ToString();
            dateTimePicker3.Value = borrow.getDate;
        }
        private void materialButton15_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox41.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }

            flag = database.DeleteBorrow(id);
            if (!flag)
            {
                statusBar1.Text = "删除失败";
                return;
            }

            statusBar1.Text = "删除成功";
            textBox41.Text = "";
            textBox40.Text = "";
            textBox39.Text = "";
            textBox38.Text = "";
            textBox36.Text = "";
            GetData();
        }
        //  添加还书信息
        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox45, textBox44, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox43, textBox42, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void materialButton16_Click(object sender, EventArgs e)
        {
            int readerCode;
            int bookId;
            DateTime getDate;
            DateTime outDate;
            bool flag1 = int.TryParse(textBox45.Text, out readerCode);
            bool flag2 = int.TryParse(textBox43.Text, out bookId);
            getDate = dateTimePicker4.Value;
            outDate = dateTimePicker7.Value;
            if (!flag1 || !flag2 || textBox44.Text == "" || textBox42.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.InsertBorrow(readerCode, bookId, getDate, outDate);
            if (!flag)
            {
                statusBar1.Text = "添加失败";
                return;
            }
            statusBar1.Text = "添加成功";
            textBox45.Text = "";
            textBox44.Text = "";
            textBox43.Text = "";
            textBox42.Text = "";
            GetData();
        }
        //  修改还书信息
        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox49, textBox48, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox47, textBox46, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox50.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Borrow borrow = database.GetBorrow(id);
            if (borrow == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox49.Text = borrow.readerCode.ToString();
            textBox47.Text = borrow.bookId.ToString();
            dateTimePicker5.Value = borrow.getDate;
            if (!borrow.outDate.Equals(DateTime.MinValue))
            {
                dateTimePicker8.Value = borrow.outDate;
            }
        }
        private void materialButton17_Click(object sender, EventArgs e)
        {
            int id;
            int readerCode;
            int bookId;
            DateTime getDate;
            DateTime outDate;
            bool flag1 = int.TryParse(textBox50.Text, out id);
            bool flag2 = int.TryParse(textBox49.Text, out readerCode);
            bool flag3 = int.TryParse(textBox47.Text, out bookId);
            getDate = dateTimePicker5.Value;
            outDate = dateTimePicker8.Value;
            if (!flag1 || !flag2 || !flag3 || textBox48.Text == "" || textBox46.Text == "")
            {
                statusBar1.Text = "参数错误";
                return;
            }
            bool flag = database.UpdateBorrow(id, readerCode, bookId, getDate, outDate);
            if (!flag)
            {
                statusBar1.Text = "更新失败";
                return;
            }
            statusBar1.Text = "更新成功";
            textBox50.Text = "";
            textBox49.Text = "";
            textBox48.Text = "";
            textBox47.Text = "";
            textBox46.Text = "";
            GetData();
        }
        //  删除还书信息
        private void textBox54_TextChanged(object sender, EventArgs e)
        {
            if (common.GetReader(textBox54, textBox53, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void textBox52_TextChanged(object sender, EventArgs e)
        {
            if (common.GetBook(textBox52, textBox51, database))
            {
                statusBar1.Text = "查询成功";
                return;
            }
            statusBar1.Text = "查询失败";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox55.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }
            Borrow borrow = database.GetBorrow(id);
            if (borrow == null)
            {
                statusBar1.Text = "查询失败";
                return;
            }
            textBox54.Text = borrow.readerCode.ToString();
            textBox52.Text = borrow.bookId.ToString();
            dateTimePicker6.Value = borrow.getDate;
            if (!borrow.outDate.Equals(DateTime.MinValue))
            {
                dateTimePicker9.Value = borrow.outDate;
            }
        }
        private void materialButton18_Click(object sender, EventArgs e)
        {
            int id;
            bool flag = int.TryParse(textBox55.Text, out id);
            if (!flag)
            {
                statusBar1.Text = "参数错误";
                return;
            }

            flag = database.DeleteBorrow(id);
            if (!flag)
            {
                statusBar1.Text = "删除失败";
                return;
            }

            statusBar1.Text = "删除成功";
            textBox55.Text = "";
            textBox54.Text = "";
            textBox53.Text = "";
            textBox52.Text = "";
            textBox51.Text = "";
            GetData();
        }
    }
}
