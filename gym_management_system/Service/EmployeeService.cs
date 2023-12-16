using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class EmployeeService
    {
        public List<EmployeeModel> SearchByIdOrUsername(string idOrUsername, bool includePicture, bool byId = false, bool byUsername = false, bool byFName = false, bool bySName = false, bool byFulName = false)
        {
            try
            {
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                string query = "";

                if (byId && int.TryParse(idOrUsername, out int id))
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE id = {id}";
                }
                else if (byUsername)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE user_name = '{idOrUsername}'";
                }
                else if (byFName || bySName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE first_name = '{idOrUsername}' OR second_name = '{idOrUsername}'";
                }
                else if (byFulName)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE CONCAT(first_name , ' ' , second_name) = '{idOrUsername}'";
                }
                if (query == "")
                {
                    Console.WriteLine($"Error getting from Employee search by Id or Username: No selected search tybe");
                    return null;
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeModel em = new EmployeeModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), admin: Convert.ToBoolean(reader["admin"]), accountStatus: Convert.ToBoolean(reader["account_status"]), username: reader["user_name"].ToString());
                        if (includePicture)
                        {
                            em.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                        }
                        employeeModels.Add(em);
                    }

                    return employeeModels;
                }
                else
                {
                    Console.WriteLine($"Error getting from Employee search by Id or Username: No records found for the specified ID or Username '{idOrUsername}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql Employee search by Id or Username: {ex.Message}");
                return null;
            }
        }

        public bool CheckUsername(string username)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM employee WHERE user_name = '{username}'";
                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error checking username in MySql: {ex.Message}");
                return false;
            }
        }

        public bool addEmployee(EmployeeModel employeeModel)
        {
            try
            {
                int id = employeeModel.generateId();
                string query = $"INSERT INTO employee (id, first_name, second_name, brithday, gender, picture, email, phone_number, user_name, password, account_status, admin) VALUES " +
                               $"('{id}', '{employeeModel.FirstName}', '{employeeModel.SecondName}', '{employeeModel.Brithday.ToString("yyyy-MM-dd")}', " +
                               $"'{employeeModel.Gender}', '{employeeModel.Base64Image}', " +
                               $"'{employeeModel.Email}', '{employeeModel.PhoneNumber}', '{employeeModel.Username}', '{constants.mangePassword.encrypt_password(employeeModel.Password, id)}', " +
                               $"{(employeeModel.AccountStatus ? 1 : 0)}, {(employeeModel.Admin ? 1 : 0)})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error add employee: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error add employee in MySql: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEmployeeStatusAttributes(int employeeId, EmployeeModel employeeModel, bool firstName = false, bool secondName = false, bool username = false, bool password = false, bool gender = false, bool brithday = false, bool email = false, bool phoneNumber = false, bool pictur = false, bool accountStatus = false, bool admin = false)
        {
            try
            {
                string query = "UPDATE employee SET";
                if (firstName)
                {
                    query += $" first_name = '{employeeModel.FirstName}',";
                }
                if (secondName)
                {
                    query += $" second_name = '{employeeModel.SecondName}',";
                }
                if (username)
                {
                    query += $" user_name = '{employeeModel.Username}'";
                }
                if (password)
                {
                    query += $"password = '{Global.mangePassword.encrypt_password(employeeModel.Password, employeeModel.Id)}',";
                }
                if (gender)
                {
                    query += $"gender = '{employeeModel.Gender}',";
                }
                if (brithday)
                {
                    query += $"brithday = '{employeeModel.Brithday}',";
                }
                if (email)
                {
                    query += $"email = '{employeeModel.Email}',";
                }
                if (phoneNumber)
                {
                    query += $"phone_number = '{employeeModel.PhoneNumber}',";
                }
                if (pictur)
                {
                    query += $"picture = '{employeeModel.Base64Image}',";
                }
                if (accountStatus)
                {
                    query += $"account_status = {(employeeModel.AccountStatus ? 1 : 0)},";
                }
                if (admin)
                {
                    query += $"admin = {(employeeModel.Admin ? 1 : 0)},";
                }
                if (query == $"UPDATE employee SET")
                {
                    Console.WriteLine($"Error updating employee status attributes: No selected data modfied");
                    return false;
                }
                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {employeeId}";
                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Employee status attributes updated successfully for ID: {employeeId}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating employee status attributes: No rows affected for ID: {employeeId}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating employee status attributes in MySql: {ex.Message}");
                return false;
            }
        }

        public List<EmployeeModel> getAllEmployee(bool accountStatus, bool isAdmin, bool includePicture)
        {
            try
            {
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                string query;
                if (accountStatus && isAdmin)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE account_status = 1 AND Admin = 1";
                }
                else if (accountStatus)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE account_status = 1";
                }
                else if (isAdmin)
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee WHERE Admin = 1";
                }
                else
                {
                    query = $"SELECT {GetSelectColumns(includePicture)} FROM employee";
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeModel em = new EmployeeModel(id: Convert.ToInt32(reader["id"]), firstName: reader["first_name"].ToString(), secondName: reader["second_name"].ToString(), brithday: Convert.ToDateTime(reader["brithday"]), gender: reader["gender"].ToString(), email: reader["email"].ToString(), phoneNumber: reader["phone_number"].ToString(), admin: isAdmin, accountStatus: accountStatus, username: reader["user_name"].ToString());
                        if (includePicture)
                        {
                            em.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                        }
                        employeeModels.Add(em);
                    }

                    return employeeModels;
                }
                else
                {
                    Console.WriteLine("Error getting from getAllEmployee: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getAllEmployee: {ex.Message}");
                return null;
            }
        }

        public EmployeeModel login(string userName, string password)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                string query = "SELECT * FROM employee where username = " + userName + "AND account_status = 1";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    reader.Read();
                    employeeModel.Id = Convert.ToInt32(reader["id"]);
                    if (Global.mangePassword.decrypt_password(reader["password"].ToString(), employeeModel.Id) != password)
                    {
                        Console.WriteLine("Error getting from Employee login: No username or password match in activate account");
                        return null;
                    }
                    employeeModel.FirstName = reader["first_name"].ToString();
                    employeeModel.SecondName = reader["second_name"].ToString();
                    employeeModel.Brithday = Convert.ToDateTime(reader["brithday"]);
                    employeeModel.Gender = reader["gender"].ToString();
                    employeeModel.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                    employeeModel.Email = reader["email"].ToString();
                    employeeModel.PhoneNumber = reader["phone_number"].ToString();
                    employeeModel.Username = userName;
                    employeeModel.Password = password;
                    employeeModel.AccountStatus = true;
                    employeeModel.Admin = Convert.ToBoolean(reader["admin"]);
                    return employeeModel;
                }
                else
                {
                    Console.WriteLine("Error getting from Employee login: No username or password match in activate account");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql login of Employee: {ex.Message}");
                return null;
            }
        }

        public int getLastId()
        {
            try
            {
                int id = 0;
                string query = "SELECT id FROM employee ORDER BY id DESC LIMIT 1";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    reader.Read();
                    id = Convert.ToInt32(reader["id"]);
                    return id;
                }
                else
                {
                    Console.WriteLine("Error getting from getLastId of Employee: No last id found");
                    return id;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql getLastId of Employee: {ex.Message}");
                return -1;
            }
        }

        private string GetSelectColumns(bool includePicture)
        {
            if (includePicture)
            {
                return "*";
            }
            else
            {
                return "id, first_name, second_name, brithday, gender, email, phone_number, user_name, password, account_status, admin";
            }
        }
    }
}
