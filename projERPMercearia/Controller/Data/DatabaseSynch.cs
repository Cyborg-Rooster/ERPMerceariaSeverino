using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projERPMercearia.Model;

namespace projERPMercearia.Controller
{
    class DatabaseSynch
    {
        public static readonly int Version = 1;
        public static void Synch()
        {
            CreateTables();
            SetDatabaseVersion();
        }

        private static void CreateTables()
        {
            SQLiteHelper.RunQuery("CREATE TABLE VERSION(VERSION_CODE INT)");
            SQLiteHelper.RunQuery("CREATE TABLE EAN_CODES(EAN VARCHAR(20), ID_PRODUCT INT, ADD_DATE DATE)");
            SQLiteHelper.RunQuery("CREATE TABLE PRICE_CHANGES (ID_PRODUCT INT, PRICE VARCHAR(10), CHANGE_DATE DATE)");
            SQLiteHelper.RunQuery("CREATE TABLE PRODUCT(ID INT, NAME VARCHAR(100), DESCRIPTION VARCHAR(200), ID_SECTION INT, PRICE VARCHAR(10), PROFIT VARCHAR(10), UNITY INT,QUANTITY VARCHAR(10))");
            SQLiteHelper.RunQuery("CREATE TABLE SECTION_PROFITS(PDV_ID INT, PROFIT_DATE STRING, SECTION_ID INT, GROSS_VALUE DOUBLE, NET_VALUE DOUBLE)");
            SQLiteHelper.RunQuery("CREATE TABLE EAN_CHANGES(EAN_CODE VARCHAR(20), EAN_CHANGES_DATE DATE, WHY VARCHAR(1000))");
            SQLiteHelper.RunQuery("CREATE TABLE PRODUCT_CHANGES(ID_PRODUCT INT, CHANGE VARCHAR(1000), CHANGE_DATE DATE)");
            SQLiteHelper.RunQuery("CREATE TABLE PRODUCT_MOVEMENTS(ID INT, ID_PRODUCT INT, MOVEMENTS_DATE DATE, MOVEMENT_TYPE VARCHAR(1), MOVED_QUANTITY VARCHAR(10), FINAL_QUANTITY VARCHAR(10), WHY VARCHAR(1000))");
            SQLiteHelper.RunQuery("CREATE TABLE SECTION(ID INT, NAME VARCHAR(20))");
            SQLiteHelper.RunQuery("CREATE TABLE SECTION_CHANGES(ID INT, ID_SECTION INT, CHANGE VARCHAR(200), CHANGE_DATE DATE)");
            SQLiteHelper.RunQuery("CREATE TABLE PDV_INFO(ID INT, PDV_DATE DATE, CLIENTS_NUMB INT, GROSS_VALUE DOUBLE, NET_VALUE DOUBLE)");
        }

        private static void SetDatabaseVersion()
        {
            SQLiteHelper.RunQuery(CommonQuery.Add("VERSION", "VERSION_CODE", Version.ToString()));
        }
    }
}
