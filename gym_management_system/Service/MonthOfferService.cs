using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class MonthOfferService
    {
        //search 
        public List<MonthOfferModel> Search(string search, bool byId = false, bool byNumOfMonth = false)
        {
            try
            {
                List<MonthOfferModel> monthOffers = new List<MonthOfferModel>();
                string query = "";

                if (byId && int.TryParse(search, out int id))
                {
                    query = $"SELECT * FROM month_offer WHERE id = {id}";
                }
                else if (byNumOfMonth && int.TryParse(search, out int numOfMonth))
                {
                    query = $"SELECT * FROM month_offer WHERE num_of_months = {numOfMonth}";
                }

                if (query == "")
                {
                    Console.WriteLine($"Error getting from MonthOffer search: No selected search type");
                    return null;
                }
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MonthOfferModel monthOffer = new MonthOfferModel(
                            id: Convert.ToInt32(reader["id"]),
                            maxNumFreze: Convert.ToInt32(reader["max_num_freze"]),
                            numOfMonth: Convert.ToInt32(reader["num_of_months"]),
                            price: Convert.ToInt32(reader["price"])
                        );

                        monthOffers.Add(monthOffer);
                    }

                    return monthOffers;
                }
                else
                {
                    Console.WriteLine($"Error getting from MonthOffer search: No records found for '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql MonthOffer search: {ex.Message}");
                return null;
            }
        }

        //insert 
        public bool InsertMonthOffer(MonthOfferModel monthOffer)
        {
            try
            {
                string query = $"INSERT INTO month_offer (max_num_freze, num_of_months, price) VALUES " +
                               $"({monthOffer.MaxNumFreze}, {monthOffer.NumOfMonth}, {monthOffer.Price})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("MonthOffer created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding MonthOffer: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding MonthOffer in MySql: {ex.Message}");
                return false;
            }
        }


        //updated 
        public bool UpdateMonthOfferAttributes(MonthOfferModel monthOffer, bool maxNumFreze = false, bool numOfMonth = false, bool price = false)
        {
            try
            {
                string query = "UPDATE month_offer SET";

                if (maxNumFreze)
                {
                    query += $" max_num_freze = {monthOffer.MaxNumFreze},";
                }
                if (numOfMonth)
                {
                    query += $" num_of_months = {monthOffer.NumOfMonth},";
                }
                if (price)
                {
                    query += $" price = {monthOffer.Price},";
                }
                //to stop function 
                if (query == "UPDATE month_offer SET")
                {
                    Console.WriteLine($"Error updating month offer attributes: No selected data modified");
                    return false;
                }
                //if make all if condition (,)appear in end and this remove (,)
                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {monthOffer.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"MonthOffer attributes updated successfully for ID: {monthOffer.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating month offer attributes: No rows affected for ID: {monthOffer.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating month offer attributes in MySql: {ex.Message}");
                return false;
            }
        }


        //to appear all offer

        public List<MonthOfferModel> GetAllMonthOffers()
        {
            try
            {
                List<MonthOfferModel> monthOffers = new List<MonthOfferModel>();
                string query = "SELECT * FROM month_offer";

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MonthOfferModel monthOffer = new MonthOfferModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            MaxNumFreze = Convert.ToInt32(reader["max_num_freze"]),
                            NumOfMonth = Convert.ToInt32(reader["num_of_months"]),
                            Price = Convert.ToInt32(reader["price"])

                        };

                        monthOffers.Add(monthOffer);
                    }

                    return monthOffers;
                }
                else
                {
                    Console.WriteLine("Error getting all month offers: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting all month offers from MySql: {ex.Message}");
                return null;
            }
        }

    }
}
