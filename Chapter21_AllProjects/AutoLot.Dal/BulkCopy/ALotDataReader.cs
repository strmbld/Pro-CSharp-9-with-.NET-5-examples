using System;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLot.Dal.Model;

namespace AutoLot.Dal.BulkCopy
{
    public sealed class ALotDataReader<T> : IALotDataReader<T>
    {
        public List<T> Records { get; set; }
        private int currentIndex;
        private readonly PropertyInfo[] propertyInfos;
        private readonly Dictionary<int, string> nameDictionary;
        private readonly SqlConnection connection;
        private readonly string schema;
        private readonly string tableName;
        public int FieldCount => propertyInfos.Length;

        public ALotDataReader(List<T> records, SqlConnection connection, string schema, string tableName)
        {
            Records = records;
            currentIndex = -1;
            propertyInfos = typeof(T).GetProperties();
            nameDictionary = new Dictionary<int, string>();
            this.connection = connection;
            this.schema = schema;
            this.tableName = tableName;

            DataTable schemaTable = GetSchemaTable();
            for (int i = 0; i < schemaTable?.Rows.Count; i++)
            {
                DataRow col = schemaTable.Rows[i];
                var columnName = col.Field<string>("ColumnName");
                nameDictionary.Add(i, columnName);
            }
        }


        public bool Read()
        {
            if (currentIndex + 1 >= Records.Count)
            {
                return false;
            }
            currentIndex++;
            return true;
        }
        public object GetValue(int i) =>
            propertyInfos
            .First(x => x.Name.Equals(nameDictionary[i], StringComparison.OrdinalIgnoreCase))
            .GetValue(Records[currentIndex])
            ;
        
        public DataTable GetSchemaTable()
        {
            using var schemaCommand = new SqlCommand($"SELECT * FROM {schema}.{tableName}", connection);

            using var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly);

            return reader.GetSchemaTable();
        }


        public object this[int i] => throw new NotImplementedException();

        public object this[string name] => throw new NotImplementedException();

        public int Depth => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public int RecordsAffected => throw new NotImplementedException();

        

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        
    }
}
