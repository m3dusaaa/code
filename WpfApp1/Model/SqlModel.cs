using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Model;
using WpfApp1.Tools;

    public class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;
        }

       
        internal List<Client> SelectAllClients()
        {
            string query = $"SELECT * FROM Client";
            List<Client> result = new List<Client>();
            var mySqlDB = MySqlDB.GetDB();
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Client
                        {
                            ID = dr.GetInt32("idclient"),
                            FIO = dr.GetString("clientFIO"),
                            Birthday = dr.GetDateTime("clientbirthday"),
                            OperatorId = dr.GetInt32("idoperator"),
                            Oplata_idclient = dr.GetInt32("oplata_idclient")

                        });
                    }
                }
                mySqlDB.CloseConnection();
            }

            return result;
        }

        internal List<Operator> SelectAllOperators()
        {
           List<Operator> result = new List<Operator>();
            string query = $"SELECT * FROM Operator";
            var mySqlDB = MySqlDB.GetDB();
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(new Operator
                        {
                            OperatorFIO = dr.GetString("operatorfio"),
                            PhoneNumber = dr.GetString("phone"),
                            OperatorID = dr.GetInt32("idoperator"),
                            Tour_order_num = dr.GetInt32("tour_order_num"),
                            Tour_idoperator = dr.GetInt32("tour_idoperator")

                        });
                    }
                }
                mySqlDB.CloseConnection();
            }

            return result;
        }




        internal List<Oplata> SelectAllOplatas()
        {
            List<Oplata> oplatas = new List<Oplata>();
            string query = $"SELECT * FROM Oplata";
            var mySqlDB = MySqlDB.GetDB();
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oplatas.Add(new Oplata
                        {
                            Zakaza = dr.GetDateTime("datazakaza"),
                            idclient = dr.GetString("idclient"),
                            IDOperator = dr.GetInt32("tour_idoperator"),
                            Price = dr.GetString("price")
                           
                        });
                    }  
                   
                }
                mySqlDB.CloseConnection();
            }
            return oplatas;
        }

        internal List<Tour> SelectAllTours()
        {
            List<Tour> tours = new List<Tour>();
            string query = $"SELECT * FROM Tour";
            var mySqlDB = MySqlDB.GetDB();
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tours.Add(new Tour
                        {
                            Country = dr.GetString("country"),
                            City = dr.GetString("city"),
                            NomerZakaza = dr.GetInt32("order_num"),
                            Dlitelnost = dr.GetString("time"),
                            hotel = dr.GetString("hotel"),
                            Price = dr.GetString("price"),         
                            IDOperator = dr.GetInt32("idoperator"),
                            Oplata_idclient = dr.GetInt32("oplata_idclient"),
                            Oplata_price = dr.GetInt32("oplata_price")


                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return tours;
        }

        public int Insert<T>(T value)
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
           
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1);
            return id;
        }
        
        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }

       
        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Item2));
                return $"{s.Item1} = @p{count++}";
            });
            stringBuilder.Append(string.Join(',', rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            table = ((TableAttribute)tableAtrributes.First()).Table;
            values = new List<(string, object)>();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((ColumnAttribute)columnAttributes.First()).Column;
                    values.Add(new(column, prop.GetValue(value)));
                }
            }
        }
    }

