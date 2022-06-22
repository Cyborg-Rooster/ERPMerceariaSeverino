using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using projERPMercearia.Model;

namespace projERPMercearia.Controller
{
    static class SQLiteHelper
    {
        private static SQLiteConnection Database;

        public static bool CheckIfDatabaseExist()
        {
            if (File.Exists(@$"{AppDomain.CurrentDomain.BaseDirectory}\Database\Database.sqlite")) return true;
            else return false;
        }

        public static void CreateDatabase()
        {
            Directory.CreateDirectory(@$"{AppDomain.CurrentDomain.BaseDirectory}\Database\");
            SQLiteConnection.CreateFile(@$"{AppDomain.CurrentDomain.BaseDirectory}\Database\Database.sqlite");
            SetDatabase();
        }

        public static void SetDatabase()
        {
            Database = GetDatabaseConnection();
            SetDatabaseActive(true);
        }

        public static void RunQuery(string query)
        {
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        public static string[] GetAllValuesFromTableByArray(string query, string columnToRead)
        {
            List<string> output = new List<string>();
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = query;
            SQLiteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    if(columnToRead == "*") for(int i = 0; i < 5; i++) output.Add(Convert.ToString(reader[i]));
                    else output.Add(Convert.ToString(reader[columnToRead]));
                }
                else output.Add("0");
            };

            return output.ToArray();
        }

        public static DataGridView GetAllProductsFromTableByDataTable(DataGridView dgv, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select("*", table , where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    reader.GetValue(reader.GetOrdinal("ID")),
                    reader.GetValue(reader.GetOrdinal("EAN")),
                    reader.GetValue(reader.GetOrdinal("NAME")),
                    reader.GetValue(reader.GetOrdinal("DESCRIPTION")),
                });
            }

            return datatable;
        }

        public static DataGridView GetAllValueFromTableByDataTable(DataGridView dgv, string select, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select(select, table, where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    /*DateFormatter.DateFormat(reader.GetString(reader.GetOrdinal("PDV_DATE"))),
                    reader.GetValue(reader.GetOrdinal("CLIENTS_NUMB")),
                    $"R${DoubleFormatter.ConvertDoubleToString(reader.GetDouble(reader.GetOrdinal("GROSS_VALUE")))}",
                    $"R${DoubleFormatter.ConvertDoubleToString(reader.GetDouble(reader.GetOrdinal("NET_VALUE")))}"*/
                    DateFormatter.DateFormat(reader.GetString(0), false),
                    reader.GetValue(1),
                    $"R${DoubleFormatter.ConvertDoubleToString(reader.GetDouble(2))}",
                    $"R${DoubleFormatter.ConvertDoubleToString(reader.GetDouble(3))}"
                });
            }

            return datatable;
        }

        public static DataGridView GetProductsWithQuantityLessThen10(DataGridView dgv, string select, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select(select, table, where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2)
                });
            }

            return datatable;
        }

        public static DataGridView GetAllProductsMovementsFromTableByDataTable(DataGridView dgv, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select("*", table, where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("MOVEMENTS_DATE"))),
                    reader.GetValue(reader.GetOrdinal("MOVEMENT_TYPE")),
                    reader.GetValue(reader.GetOrdinal("MOVED_QUANTITY")),
                    reader.GetValue(reader.GetOrdinal("FINAL_QUANTITY")),
                    reader.GetValue(reader.GetOrdinal("WHY")),
                });
            }

            return datatable;
        }

        public static DataGridView GetAllProductEanFromTableByDataTable(DataGridView dgv, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select("*", table, where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("EAN_CHANGES_DATE"))),
                    reader.GetValue(reader.GetOrdinal("EAN_CODE")),
                    reader.GetValue(reader.GetOrdinal("WHY"))
                });
            }

            return datatable;
        }

        public static DataGridView GetAllProductChangesTableByDataTable(DataGridView dgv, string table, string where)
        {
            DataGridView datatable = dgv;
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = CommonQuery.Select("*", table, where);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                datatable.Rows.Add(new object[]
                {
                    reader.GetValue(reader.GetOrdinal("CHANGE")),
                    DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("CHANGE_DATE")))
                });
            }

            return datatable;
        }

        public static Product GetProduct(string id)
        {
            Product product = new Product();
            var cmd = new SQLiteCommand(Database);

            cmd.CommandText = CommonQuery.Select
            (
                "*",
                "PRODUCT " +
                "INNER JOIN EAN_CODES ON PRODUCT.ID = EAN_CODES.ID_PRODUCT "+
                "INNER JOIN PRICE_CHANGES ON PRODUCT.ID = PRICE_CHANGES.ID_PRODUCT", 
                $"PRODUCT.ID = {id}"
            );

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product temp = new Product()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    EAN = reader.GetString(reader.GetOrdinal("EAN")),
                    DateEAN = DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("ADD_DATE"))),
                    DatePrice = DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("CHANGE_DATE"))),
                    Name = reader.GetString(reader.GetOrdinal("NAME")),
                    Description = reader.GetString(reader.GetOrdinal("DESCRIPTION")),
                    Quantity = double.Parse
                    (
                        reader.GetString
                        (
                            reader.GetOrdinal("QUANTITY")
                        ).Replace(',', '.'),
                        CultureInfo.InvariantCulture
                    ),

                    Section = new Section()
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID_SECTION")),
                        Name = ReturnValue(CommonQuery.Select("NAME", "SECTION", $"ID = {reader.GetInt32(reader.GetOrdinal("ID_SECTION"))}"))
                    },

                    Price = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PRICE"))
                    ),

                    Profit = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PROFIT"))
                    ),

                    Unity = reader.GetInt32(reader.GetOrdinal("UNITY")) == 1
                };

                product = temp;
            }

            return product;
        }

        public static Product GetProduct(long ean)
        {
            Product product = new Product();
            var cmd = new SQLiteCommand(Database);

            cmd.CommandText = CommonQuery.Select
            (
                "*",
                "PRODUCT " +
                "INNER JOIN EAN_CODES ON PRODUCT.ID = EAN_CODES.ID_PRODUCT ",
                $"EAN_CODES.EAN = {ean}"
            );

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product temp = new Product()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    EAN = reader.GetString(reader.GetOrdinal("EAN")),
                    DateEAN = DateFormatter.DateTimeFormat(reader.GetString(reader.GetOrdinal("ADD_DATE"))),
                    Name = reader.GetString(reader.GetOrdinal("NAME")),
                    Description = reader.GetString(reader.GetOrdinal("DESCRIPTION")),
                    Quantity = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("QUANTITY"))
                    ),

                    Section = new Section()
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID_SECTION")),
                        Name = ReturnValue(CommonQuery.Select("NAME", "SECTION", $"ID = {reader.GetInt32(reader.GetOrdinal("ID_SECTION"))}"))
                    },

                    Price = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PRICE"))
                    ),

                    Profit = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PROFIT"))
                    ),

                    Unity = reader.GetInt32(reader.GetOrdinal("UNITY")) == 1
                };

                product = temp;
            }

            return product;
        }

        public static List<Product> GetProducts(string where)
        {
            List<Product> products = new List<Product>();
            var cmd = new SQLiteCommand(Database);

            cmd.CommandText = CommonQuery.Select
            (
                "*",
                "PRODUCT",
                where
            );

            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product temp = new Product()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Name = reader.GetString(reader.GetOrdinal("NAME")),
                    Description = reader.GetString(reader.GetOrdinal("DESCRIPTION")),
                    Quantity = double.Parse
                    (
                        reader.GetString
                        (
                            reader.GetOrdinal("QUANTITY")
                        ).Replace(',', '.'),
                        CultureInfo.InvariantCulture
                    ),

                    Section = new Section()
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID_SECTION")),
                        Name = ReturnValue(CommonQuery.Select("NAME", "SECTION", $"ID = {reader.GetInt32(reader.GetOrdinal("ID_SECTION"))}"))
                    },

                    Price = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PRICE"))
                    ),

                    Profit = DoubleFormatter.ConvertStringToDouble
                    (
                        reader.GetString(reader.GetOrdinal("PROFIT"))
                    ),

                    Unity = reader.GetInt32(reader.GetOrdinal("UNITY")) == 1
                };
                products.Add(temp);
            }

            return products;
        }

        public static string ReturnValue(string query)
        {
            string output = "";
            var cmd = new SQLiteCommand(Database);
            cmd.CommandText = query;

            output = cmd.ExecuteScalar().ToString();

            return output;
        }

        public static void SetDatabaseActive(bool active)
        {
            if (active) Database.Open();
            else Database.Close();
        }

        private static SQLiteConnection GetDatabaseConnection()
        {
            return new SQLiteConnection($"Data Source={AppDomain.CurrentDomain.BaseDirectory}\\Database\\Database.sqlite; Version=3;");
        }
    }
}
