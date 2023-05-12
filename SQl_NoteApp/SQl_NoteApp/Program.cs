using System.Data;
using System.Data.SqlClient;
namespace SQL_NoteApp
{
    class Application
    {
        public void CreateNote(SqlConnection con)
        {
            SqlDataAdapter adp1 = new SqlDataAdapter($"SELECT * FROM Note ", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            var row = ds1.Tables[0].NewRow();
            Console.Write("Title: ");
            row["Title"] =Console.ReadLine();
            Console.Write("Enter Description: ");
            row["Descriptionn"] =Console.ReadLine();
            Console.Write("Enter Date: ");
            row["Datee"] = Convert.ToDateTime(Console.ReadLine());

            ds1.Tables[0].Rows.Add(row);

            SqlCommandBuilder Builder = new SqlCommandBuilder(adp1);
            adp1.Update(ds1);
            Console.WriteLine("Record inserted successfully.");
        }
        public void ViewAll(SqlConnection con)
        {
            SqlDataAdapter adp2 = new SqlDataAdapter($"Select * from Note ", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "NoteTable");
            for (int i = 0; i < ds2.Tables["NoteTable"].Rows.Count; i++)
            {
                for (int j = 0; j < ds2.Tables["NoteTable"].Columns.Count; j++)
                {
                    Console.Write($"{ds2.Tables["NoteTable"].Rows[i][j]} |");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total Notes in NoteTable : {ds2.Tables["NoteTable"].Rows.Count}");
        }
        public void Update(SqlConnection con)
        { 
            SqlDataAdapter adp3 = new SqlDataAdapter($"SELECT * FROM Note", con);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3);

            Console.Write("Enter column name: ");
            string Colname = Console.ReadLine();

            Console.WriteLine("Enter the row:");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new value that you want to update : ");
            string Value = Console.ReadLine();

            ds3.Tables[0].Rows[i][Colname] = Value;

            SqlCommandBuilder Builder = new SqlCommandBuilder(adp3);
            adp3.Update(ds3);
            Console.WriteLine("Record updated successfully.");
        }
        public void Delete(SqlConnection con)
        {

            SqlDataAdapter adp4 = new SqlDataAdapter($"SELECT * FROM Note", con);
            DataSet ds4 = new DataSet();
            adp4.Fill(ds4);

            Console.Write("Enter row index: ");
            int i = Convert.ToInt16(Console.ReadLine());
            ds4.Tables[0].Rows[i].Delete();

            SqlCommandBuilder Builder = new SqlCommandBuilder(adp4);
            adp4.Update(ds4);
            Console.WriteLine("Record deleted successfully.");
        }
        public void View(SqlConnection con)
        {
            Console.Write("Enter id: ");
            int id = Convert.ToInt16(Console.ReadLine());
            SqlDataAdapter adp5 = new SqlDataAdapter($"Select * from Note where id={id}", con);
            DataSet ds5 = new DataSet();
            adp5.Fill(ds5);
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                
                for (int j = 0; j < ds5.Tables[0].Columns.Count; j++)
                {
                    Console.Write($"{ds5.Tables[0].Rows[i][j]} | ");
                }
                Console.WriteLine();
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=US-8ZBJZH3; database=NoteApp; Integrated Security=true");
            Application obj = new Application();
            string s = "";
            do
            {
                Console.WriteLine("Take Note App");
                Console.WriteLine("1. Create Note:");
                Console.WriteLine("2. View All Notes:");
                Console.WriteLine("3. Update Note :");
                Console.WriteLine("4. Delete Note :");
                Console.WriteLine("5. View Note :");
                Console.WriteLine("Enter ur choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            obj.CreateNote(con);
                            break;
                        }
                    case 2:
                        {
                            obj.ViewAll(con);
                            break;
                        }
                    case 3:
                        {
                            obj.Update(con);
                            break;
                        }
                    case 4:
                        {
                            obj.Delete(con);
                            break;
                        }
                    case 5:
                        {
                            obj.View(con);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!!!!");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue?[y/n]");
                s = Console.ReadLine();
            }
            while (s.ToLower() == "y");
        }
    }
}
           
    
  
