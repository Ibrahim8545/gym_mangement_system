using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Service
{
    public class PackgeSupscribtionService
    {
        public bool CheckMemberInPackageSubscription(int memberId)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = $@"
                SELECT COUNT(*) 
                FROM packge_subscription ps
                INNER JOIN packge p ON ps.packgeID = p.id
                INNER JOIN month_offer mo ON p.month_offerID = mo.id
                WHERE ps.memberID = {memberId}
                AND ps.subscription_date <= now()
                AND DATE_ADD(ps.subscription_date, INTERVAL mo.num_of_months MONTH) >= now()";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error checking member subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool SubscribePackage(PackgeModel packgeModel, MemberModel memberModel, EmployeeModel employeeModel, List<ClassModel> classModels)
        {
            try
            {
                string monthSubscriptionQuery = $"INSERT INTO month_subscription (num_of_attend, start_date, remain_freze_day, memberID, employeeID, monthID) VALUES (0, NOW(), (SELECT max_num_freze FROM month_offer WHERE id = {packgeModel.MonthOffer.Id}), {memberModel.Id}, {employeeModel.Id}, {packgeModel.MonthOffer.Id});";
                int monthRowsAffected = Global.sqlService.SqlNonQuery(monthSubscriptionQuery);
                if (monthRowsAffected == 0)
                {
                    Console.WriteLine("Error adding month subscription: No rows affected");
                    return false;
                }
                int lastClassSubscriptionID = 0;
                string getLastIDQueryc = "SELECT id FROM class_subscription ORDER BY id DESC LIMIT 1;";
                MySqlDataReader reader1 = Global.sqlService.SqlSelect(getLastIDQueryc);
                if (reader1.Read())
                {
                    lastClassSubscriptionID = reader1.GetInt32(0);
                    reader1.Close();
                    Console.WriteLine($"Last inserted class_subscriptionID: {lastClassSubscriptionID}");
                }
                string valuesPart = string.Join(", ", classModels.Select(classModel =>
                    $"(0, NOW(), {employeeModel.Id}, {memberModel.Id}, {classModel.Id})"
                ));
                string classSubscriptionQuery = $"INSERT INTO class_subscription (num_of_attend, start_date, employeeID, memberID, classID) VALUES {valuesPart};";
                int classRowsAffected = Global.sqlService.SqlNonQuery(classSubscriptionQuery);

                if (classRowsAffected == 0)
                {
                    Console.WriteLine("Error adding class subscriptions: No rows affected");
                    return false; // You may choose to handle the error as needed
                }
                int lastMonthSubscriptionID;
                string getLastIDQuery = "SELECT id FROM month_subscription ORDER BY id DESC LIMIT 1;";
                MySqlDataReader reader = Global.sqlService.SqlSelect(getLastIDQuery);
                if (reader.Read())
                {
                    lastMonthSubscriptionID = reader.GetInt32(0);
                    reader.Close();
                    Console.WriteLine($"Last inserted month_subscriptionID: {lastMonthSubscriptionID}");
                }
                else
                {
                    reader.Close();
                    Console.WriteLine("Error retrieving last inserted ID for month_subscription");
                    return false;
                }
                string packgeSubscriptionQuery = $"INSERT INTO packge_subscription (subscription_date, remain_invatation, memberID, employeeID, packgeID, month_subscriptionID) VALUES (NOW(), (SELECT num_of_invatation FROM packge WHERE id = {packgeModel.Id}), {memberModel.Id}, {employeeModel.Id}, {packgeModel.Id}, {lastMonthSubscriptionID});";

                Console.WriteLine($"Executing query: {packgeSubscriptionQuery}");

                int packgeRowsAffected = Global.sqlService.SqlNonQuery(packgeSubscriptionQuery);
                if (packgeRowsAffected > 0)
                {
                    int lastpackgeSubscriptionID = 0;
                    string getLastIDQueryp = "SELECT id FROM packge_subscription ORDER BY id DESC LIMIT 1;";
                    MySqlDataReader reader2 = Global.sqlService.SqlSelect(getLastIDQueryp);
                    if (reader2.Read())
                    {
                        lastpackgeSubscriptionID = reader2.GetInt32(0);
                        reader2.Close();
                        Console.WriteLine($"Last inserted class_subscriptionID: {lastpackgeSubscriptionID}");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding package subscription: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding subscription in MySql: {ex.Message}");
                return false;
            }
        }

    }
}
