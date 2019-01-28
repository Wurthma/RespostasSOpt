using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string caminhoPlanilha = Directory.GetParent(workingDirectory).Parent.FullName + "\\MeuExcel\\teste.xlsx";

            DataTable data = new DataTable();
            //string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=No;IMEX=1\";", caminhoPlanilha); //String de conexão com HDR=No para correção dos caracteres
            string connectionString = 
                string.Format(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\";", 
                caminhoPlanilha);

            OleDbCommand selectCommand = new OleDbCommand();
            OleDbConnection connection = new OleDbConnection();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            connection.ConnectionString = connectionString;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            DataTable dtSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            List<string> SheetsName = GetSheetsName(dtSchema);
            for (int i = 1; i < SheetsName.Count; i++)
            {
                selectCommand.CommandText = "SELECT * FROM [" + SheetsName[i] + "]";
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
                DataTable Sheet = new DataTable();
                Sheet.TableName = SheetsName[i].Replace("$", "").Replace("'", "");
                adapter.Fill(Sheet);

                var ds = new DataSet();
                adapter.Fill(ds, SheetsName[i]);
                DataTable dataTeste = ds.Tables[SheetsName[i]];

                foreach (var coluna in dataTeste.Columns)
                {
                    Console.WriteLine(coluna.ToString());
                }
            }

            Console.ReadLine();
        }

        private static List<string> GetSheetsName(DataTable schemaDataTable)
        {
            var sheets = new List<string>();
            foreach (var dataRow in schemaDataTable.AsEnumerable())
            {
                sheets.Add(dataRow.ItemArray[2].ToString());
            }

            return sheets;
        }
    }
}
