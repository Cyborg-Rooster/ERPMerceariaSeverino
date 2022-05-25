using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projERPMercearia.Model
{
    class CommonQuery
    {
        public static readonly string AddProductWhyCommon = "Entrada comum via cupom fiscal.";
        public static readonly string SubstractProductWhyCommon = "Saída comum via caixa.";
        public static readonly string EanChangesWhyCommon = "Primeiro EAN cadastrado.";
        public static readonly string EanChangesWhyUpdate = "Novo EAN cadastrado.";
        public static string Add(string table, string columns, string values)
        {
            return $"INSERT INTO {table}({columns}) VALUES({values})";
        }

        public static string Select(string columns, string table)
        {
            return $"SELECT {columns} FROM {table}";
        }

        public static string Select(string columns, string table, string where)
        {
            return $"SELECT {columns} FROM {table} WHERE {where}";
        }

        public static string SelectCount(string table)
        {
            return $"SELECT COUNT(*) FROM {table}";
        }

        public static string Update(string table, string changes, string where)
        {
            return $"UPDATE {table} SET {changes} WHERE {where}";
        }

        public static string ReturnDateTimeFormat(DateTime dateTime)
        {
            return $"'{dateTime.Year}-{dateTime.Month}-{dateTime.Day} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}'";
        }

        public static string ReturnDateFormat(DateTime dateTime)
        {
            return $"'{dateTime.Year}-{dateTime.Month}-{dateTime.Day}'";
        }

    }
}
