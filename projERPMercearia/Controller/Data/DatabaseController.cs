using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using projERPMercearia.Model;

namespace projERPMercearia.Controller
{
    class DatabaseController
    {
        public static void InitiateDatabase()
        {
            if (SQLiteHelper.CheckIfDatabaseExist()) SQLiteHelper.SetDatabase();
            else SQLiteHelper.CreateDatabase();

            DatabaseSynch.Synch();
        }

        public static void Add(string table, string columns, string values)
        {
            string teste = CommonQuery.Add(table, columns, values);
            SQLiteHelper.RunQuery(teste);
        }

        public static void Update(string table, string changes, string where)
        {
            SQLiteHelper.RunQuery(CommonQuery.Update(table, changes, where));
        }

        public static string Select(string table, string column, string where)
        {
           return SQLiteHelper.GetAllValuesFromTableByArray(CommonQuery.Select(column, table, where), column)[0];
        }

        public static string[] SelectInArray(string column, string table)
        {
            return SQLiteHelper.GetAllValuesFromTableByArray(CommonQuery.Select(column, table), column);
        }
        public static string[] SelectInArray(string column, string table, string where)
        {
            return SQLiteHelper.GetAllValuesFromTableByArray(CommonQuery.Select(column, table, where), column);
        }
        public static int SelectCount(string table, string column)
        {
            return Convert.ToInt32(SQLiteHelper.ReturnValue(CommonQuery.SelectCount(table)));
        }

        public static int SelectCount(string table, string column, string where)
        {
            return Convert.ToInt32(SQLiteHelper.ReturnValue(CommonQuery.Select(column, table, where)));
        }

        public static bool CheckIfExist(string table, string column, string where)
        {
            string query = CommonQuery.Select(column, table, where);
            if (SQLiteHelper.GetAllValuesFromTableByArray(query, column).Count() > 0) return true;
            else return false;
        }

        public static DataGridView SelectProductDataGridView(DataGridView data, string name)
        {
            return SQLiteHelper.GetAllProductsFromTableByDataTable
            (
                data,
                "PRODUCT INNER JOIN EAN_CODES ON PRODUCT.ID = EAN_CODES.ID_PRODUCT", 
                $"PRODUCT.NAME LIKE '%{name}%' AND " +
                $"EAN_CODES.ADD_DATE = " +
                $"(SELECT ADD_DATE FROM EAN_CODES WHERE ID_PRODUCT = PRODUCT.ID ORDER BY ADD_DATE)"
            );
        }

        public static DataGridView SelectProductDataGridView(DataGridView data, long ean)
        {
            return SQLiteHelper.GetAllProductsFromTableByDataTable
            (
                data,
                "PRODUCT INNER JOIN EAN_CODES ON PRODUCT.ID = EAN_CODES.ID_PRODUCT", 
                $"EAN_CODES.EAN = '{ean}'"
            );
        }

        public static DataGridView SelectProductsWithQuantityLessThen10(DataGridView data, int filter)
        {
            return SQLiteHelper.GetProductsWithQuantityLessThen10
            (
                data,
                "EAN, NAME, QUANTITY",
                "(SELECT * FROM PRODUCT " +
                "INNER JOIN EAN_CODES ON PRODUCT.ID = EAN_CODES.ID_PRODUCT GROUP BY NAME)",
                $"CAST(QUANTITY AS DECIMAL) <= {filter}"
            );
        }

        public static DataGridView SelectValuesDataGridView(DataGridView data, string select, string table, string where)
        {
            return SQLiteHelper.GetAllValueFromTableByDataTable(data, select, table, where);
        }

        public static DataGridView SelectMovementDataGridView(DataGridView data, int id)
        {
            return SQLiteHelper.GetAllProductsMovementsFromTableByDataTable(data, "PRODUCT_MOVEMENTS", $"ID_PRODUCT = {id}");
        }

        public static DataGridView SelectProductChangesDataGridView(DataGridView data, int id)
        {
            return SQLiteHelper.GetAllProductChangesTableByDataTable(data, "PRODUCT_CHANGES", $"ID_PRODUCT = {id}");
        }

        public static DataGridView SelectProductEansDataGridView(DataGridView data, int id)
        {
            return SQLiteHelper.GetAllProductEanFromTableByDataTable(data, "EAN_CHANGES INNER JOIN EAN_CODES", $"EAN_CHANGES.EAN_CODE = EAN_CODES.EAN AND EAN_CODES.ID_PRODUCT = {id}");
        }

        public static Product SelectProduct(string id)
        {
            return SQLiteHelper.GetProduct(id);
        }

        public static Product SelectProduct(long ean)
        {
            return SQLiteHelper.GetProduct(ean);
        }

        public static List<Product> SelectProductsListBySector(string where)
        {
            return SQLiteHelper.GetProducts(where);
        }

        public static bool ReturnIfExistElementInArray(string column, string table, string value)
        {
            string[] query = SelectInArray(column, table);
            return Array.Exists(query, element => element == value);
        }

        public static void CloseDatabase()
        {
            SQLiteHelper.SetDatabaseActive(false);
        }
    }
}
