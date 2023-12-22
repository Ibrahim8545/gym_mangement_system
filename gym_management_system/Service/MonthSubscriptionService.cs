using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class MonthSubscriptionService
    {

        public List<ClassSubscriptionModel> SearchClassSubscriptions(string search, bool byId = false, bool byDate = false)
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
                e.second_name AS employee_second_name
            FROM 
                class_subscription cs
            JOIN 
                member m ON cs.memberID = m.id
            JOIN 
                employee e ON cs.employeeID = e.id
            WHERE ";

                if (byId && int.TryParse(search, out int id))
                {
                    query += $"cs.id = {id}";
                }
                else if (byDate && DateTime.TryParse(search, out DateTime date))
                {
                    query += $"cs.start_date = '{date.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    Console.WriteLine("Error getting from class_subscription search: No selected search type");
                    return null;
                }

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
                            }
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine($"Error getting from class_subscription search: No records found '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql class_subscription search: {ex.Message}");
                return null;
            }
        }

        public bool CheckMemberInMonthSubscription(int memberId)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = $@"
                SELECT COUNT(*) 
                FROM month_subscription ms
                INNER JOIN month_offer mo ON ms.monthID = mo.id
                WHERE ms.memberID = {memberId}
                AND ms.start_date <= NOW()
                AND DATE_ADD(ms.start_date, INTERVAL mo.num_of_months MONTH) >= NOW()";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error checking member month subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public List<MonthSubscriptionModel> SearchMonthSubscription(string search, bool byId = false, bool byDate = false)
        {
            try
            {
                List<MonthSubscriptionModel> subscriptions = new List<MonthSubscriptionModel>();
                string query = $@"
            SELECT 
                ms.id AS subscription_id,
                ms.num_of_attend,
                ms.start_date,
                ms.remain_freze_day,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                mo.id AS month_offer_id,
                mo.max_num_freze,
                mo.num_of_months,
                mo.price
            FROM 
                month_subscription ms
            JOIN 
                member m ON ms.memberID = m.id
            JOIN 
                employee e ON ms.employeeID = e.id
            JOIN 
                month_offer mo ON ms.monthID = mo.id
            WHERE ";

                if (byId && int.TryParse(search, out int id))
                {
                    query += $"ms.id = {id}";
                }
                else if (byDate && DateTime.TryParse(search, out DateTime date))
                {
                    query += $"ms.start_date = '{date.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    Console.WriteLine($"Error getting from month_subscription search: No selected search type");
                    return null;
                }

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MonthOfferModel monthOffer = new MonthOfferModel
                        {
                            Id = Convert.ToInt32(reader["month_offer_id"]),
                            MaxNumFreze = Convert.ToInt32(reader["max_num_freze"]),
                            NumOfMonth = Convert.ToInt32(reader["num_of_months"]),
                            Price = Convert.ToInt32(reader["price"])
                        };

                        MemberModel member = new MemberModel
                        {
                            Id = Convert.ToInt32(reader["member_id"]),
                            FirstName = reader["member_first_name"].ToString(),
                            SecondName = reader["member_second_name"].ToString()
                        };

                        EmployeeModel employee = new EmployeeModel
                        {
                            Id = Convert.ToInt32(reader["employee_id"]),
                            FirstName = reader["employee_first_name"].ToString(),
                            SecondName = reader["employee_second_name"].ToString()
                        };

                        MonthSubscriptionModel subscription = new MonthSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["subscription_id"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            RemainFrezeDay = Convert.ToInt32(reader["remain_freze_day"]),
                            MonthOffer = monthOffer,
                            Member = member,
                            Employee = employee
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine($"Error getting from month_subscription search: No records found '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql month_subscription search: {ex.Message}");
                return null;
            }
        }

        public bool AddMonthSubscription(MonthSubscriptionModel subscription)
        {
            try
            {
                string query = $@"INSERT INTO month_subscription 
                                (num_of_attend, start_date, remain_freze_day, memberID, employeeID, monthID) VALUES 
                                ({subscription.NumberOfAttend}, '{subscription.StartDate.ToString("yyyy-MM-dd")}', {subscription.RemainFrezeDay}, {subscription.Member.Id}, {subscription.Employee.Id}, {subscription.MonthOffer.Id})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Month Subscription created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding month subscription: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding month subscription in MySql: {ex.Message}");
                return false;
            }
        }

    }
}
