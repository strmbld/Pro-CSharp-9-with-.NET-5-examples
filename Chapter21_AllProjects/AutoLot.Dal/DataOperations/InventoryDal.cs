using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLot.Dal.Model;
using Microsoft.Data.SqlClient;

namespace AutoLot.Dal.DataOperations
{
    public class InventoryDal : IDisposable
    {
        private bool disposed;
        private readonly string connectionString;
        private SqlConnection sqlConnection;
        public InventoryDal() : this(@"Data Source=.,5433;User Id=sa;Password=P@ssw0rd;Initial Catalog=Autolot;Encrypt=False") { }
        public InventoryDal(string connectionString)
        {
            this.connectionString = connectionString;
            sqlConnection = null;
            disposed = false;
        }


        public CarViewModel GetCarById(int id)
        {
            OpenConnection();

            CarViewModel car = null;

            SqlParameter p = new()
            {
                ParameterName = "@carId",
                Value = id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };

            string sql = $@"SELECT i.Id, i.Color, i.PetName, m.Name as Make
                            FROM Inventory i
                            INNER JOIN Makes m ON m.Id = i.MakeId
                            WHERE i.Id = @carId";

            using SqlCommand command = new(sql, sqlConnection) { CommandType = CommandType.Text };
            command.Parameters.Add(p);

            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                car = new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"],
                };
            }

            dataReader.Close();

            return car;
        }
        public List<CarViewModel> GetAllInventory()
        {
            OpenConnection();

            List<CarViewModel> inventory = new();

            string sql = @"SELECT i.Id, i.Color, i.PetName, m.Name as Make
                           FROM Inventory i
                           INNER JOIN Makes m ON m.Id = i.MakeId";

            using SqlCommand command = new(sql, sqlConnection) { CommandType = CommandType.Text };

            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                inventory.Add(new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"],
                });
            }

            dataReader.Close();

            return inventory;
        }
        public void UpdateCarName(int id, string newName)
        {
            OpenConnection();

            SqlParameter pId = new()
            {
                ParameterName = "@carId",
                Value = id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };
            SqlParameter pName = new()
            {
                ParameterName = "@name",
                Value = newName,
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
            };

            string sql = $"UPDATE Inventory SET PetName = @name WHERE Id = @carId";

            using (SqlCommand command = new(sql, sqlConnection))
            {
                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }
        public void DeleteCarById(int id)
        {
            OpenConnection();

            SqlParameter p = new()
            {
                ParameterName = "@carId",
                Value = id,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
            };

            string sql = $"DELETE FROM Inventory WHERE Id = @carId";
            using (SqlCommand command = new(sql, sqlConnection))
            {
                try
                {
                    command.Parameters.Add(p);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception("Attempting to delete car which is currently in order", e);
                }
            }

            CloseConnection();
        }
        public void AddCar(Car car)
        {
            OpenConnection();

            string sql = $"INSERT INTO Inventory (MakeId, Color, PetName) VALUES (@MakeId, @Color, @PetName)";

            using (SqlCommand command = new(sql, sqlConnection))
            {
                SqlParameter p = new()
                {
                    ParameterName = "@MakeId",
                    Value = car.MakeId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(p);

                p = new()
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(p);

                p = new()
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(p);

                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                CloseConnection();
            }  
        }
        public string GetCarNameSP(int id)
        {
            OpenConnection();

            string name;

            using (SqlCommand command = new("GetPetName", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new()
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(p);

                p = new()
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(p);

                command.ExecuteNonQuery();

                name = (string)command.Parameters["@petName"].Value;

                CloseConnection();
            }
            return name;
        }
        public void ProcessCreditRisk(bool throwEx, int customerId)
        {
            OpenConnection();

            string fName, lName;

            SqlCommand cmdSelect = new("SELECT * FROM Customers WHERE Id = @customerId", sqlConnection);

            SqlParameter custId = new()
            {
                ParameterName = "@customerId",
                SqlDbType = SqlDbType.Int,
                Value = customerId,
                Direction = ParameterDirection.Input,
            };
            cmdSelect.Parameters.Add(custId);

            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            cmdSelect.Parameters.Clear();

            SqlCommand cmdUpdate = new("UPDATE Customers SET LastName = LastName + ' (CreditRisk) ' WHERE Id = @customerId", sqlConnection);

            cmdUpdate.Parameters.Add(custId);

            SqlCommand cmdInsert = new("INSERT INTO CreditRisks (CustomerId, FirstName, LastName) VALUES (@customerId, @FirstName, @LastName)", sqlConnection);

            SqlParameter custId2 = new()
            {
                ParameterName = "@customerId",
                SqlDbType = SqlDbType.Int,
                Value = customerId,
                Direction = ParameterDirection.Input,
            };
            SqlParameter pFirstName = new()
            {
                ParameterName = "@FirstName",
                Value = fName,
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
            };
            SqlParameter pLastName = new()
            {
                ParameterName = "@LastName",
                Value = lName,
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
            };

            cmdInsert.Parameters.Add(custId2);
            cmdInsert.Parameters.Add(pFirstName);
            cmdInsert.Parameters.Add(pLastName);

            SqlTransaction transaction = null;
            try
            {
                transaction = sqlConnection.BeginTransaction();

                cmdInsert.Transaction = transaction;
                cmdUpdate.Transaction = transaction;

                cmdInsert.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                if (throwEx)
                {
                    throw new Exception("Transaction failed");
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
        private void OpenConnection()
        {
            sqlConnection = new(connectionString);
            sqlConnection.Open();
        }
        private void CloseConnection()
        {
            if (sqlConnection?.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                sqlConnection.Dispose();
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
