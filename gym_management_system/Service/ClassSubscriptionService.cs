using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Service
{
    public class ClassSubscriptionService
    {
        public List<ClassSubscriptionModel> GetClassSubscriptions()
        {
            try
            {
                List<ClassSubscriptionModel> subscriptions = new List<ClassSubscriptionModel>();
                string query = @"
                     SELECT 
                         cs.id AS class_subscription_id,
                         cs.start_date,
                         cs.num_of_attend,
                         m.id AS member_id,
                         m.first_name AS member_first_name,
                         m.second_name AS member_second_name,
                         e.id AS employee_id,
                         e.first_name AS employee_first_name,
                         e.second_name AS employee_second_name,
                         c.id AS class_id,
                         c.name
                     FROM 
                         class_subscription cs
                     JOIN 
                         member m ON cs.memberID = m.id
                     JOIN 
                         employee e ON cs.employeeID = e.id
                     JOIN 
                         class c ON cs.classID = c.id";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassSubscriptionModel subscription = new ClassSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["class_subscription_id"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),

                            Member = new MemberModel
                            {
                                Id = Convert.ToInt32(reader["member_id"]),
                                FirstName = reader["member_first_name"].ToString(),
                                SecondName = reader["member_second_name"].ToString(),
                            },

                            Employee = new EmployeeModel
                            {
                                Id = Convert.ToInt32(reader["employee_id"]),
                                FirstName = reader["employee_first_name"].ToString(),
                                SecondName = reader["employee_second_name"].ToString(),
                            },

                            ClassModel = new ClassModel
                            {
                                Id = Convert.ToInt32(reader["class_id"]),
                                Name = reader["name"].ToString(),
                            },
                        };

                        subscriptions.Add(subscription);
                        MessageBox.Show(subscription.ClassModel.Name);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine("Error getting class subscriptions: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting class subscriptions from MySql: {ex.Message}");
                return null;
            }
        }
        public bool UpdateClassAttributes(ClassSubscriptionModel classModel, bool numOfAttend = false, bool startDate = false, bool endDate = false)
        {
            try
            {
                string query = "UPDATE class SET";
                if (numOfAttend)
                {
                    query += $" num_of_attend = {classModel.NumberOfAttend},";
                }
                if (startDate)
                {
                    query += $" start_date = '{classModel.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }
                if (endDate)
                {
                    query += $" end_date = '{classModel.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }

                if (query == "UPDATE class SET")
                {
                    Console.WriteLine($"Error updating class attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {classModel.Id}";
                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Class attributes updated successfully for ID: {classModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating class attributes: No rows affected for ID: {classModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating class attributes in MySql: {ex.Message}");
                return false;
            }
        }
        public bool AddClassSubscription(ClassSubscriptionModel classSubscriptionModel)
        {
            try
            {
                string query = $"INSERT INTO class_subscription ( start_date, num_of_attend, memberID, employeeID, classID) VALUES " +
                               $"(' '{classSubscriptionModel.StartDate.ToString("yyyy-MM-dd")}', " +
                               $"'{classSubscriptionModel.NumberOfAttend}', '{classSubscriptionModel.Member.Id}', " +
                               $"'{classSubscriptionModel.Employee.Id}', '{classSubscriptionModel.ClassModel.Id}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Class subscription added successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding class subscription: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding class subscription in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
