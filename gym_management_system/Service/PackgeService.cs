using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class PackgeService
    {
        public List<PackgeModel> Search(string search,bool getMonthOfferData = false, bool byId = false, bool byName = false)
        {
            try
            {
                List<PackgeModel> packgeModels = new List<PackgeModel>();
                string query = "";
                if (getMonthOfferData)
                {
                    if (byId && int.TryParse(search, out int id))
                    {
                        query = $"SELECT p.*, mo.* FROM packge p INNER JOIN month_offer mo ON p.month_offerID = mo.id WHERE p.id = {id}";
                    }
                    else if (byName)
                    {
                        query = $"SELECT p.*, mo.* FROM packge p INNER JOIN month_offer mo ON p.month_offerID = mo.id WHERE p.name LIKE '%{search}%'";
                    }

                    if (query == "")
                    {
                        Console.WriteLine($"Error getting from Packge search: No selected search tybe");
                        return null;
                    }
                }
                else
                {
                    if (byId && int.TryParse(search, out int id))
                    {
                        query = $"SELECT * FROM packge WHERE id = {id}";
                    }
                    else if (byName)
                    {
                        query = $"SELECT * FROM packge WHERE name = '{search}'";
                    }

                    if (query == "")
                    {
                        Console.WriteLine($"Error getting from Packge search: No selected search type");
                        return null;
                    }
                }

                MySqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    if (getMonthOfferData)
                    {
                        while (reader.Read())
                        {
                            PackgeModel packageModel = new PackgeModel(
                                id: Convert.ToInt32(reader["id"]),
                                name: reader["name"].ToString(),
                                numOfClass: Convert.ToInt32(reader["num_of_classes"]),
                                numOfInvatation: Convert.ToInt32(reader["num_of_invatation"]),
                                discountPercentage: Convert.ToInt32(reader["discount_percentage"]),
                                status: reader["status"].ToString(),
                                monthOffer: new MonthOfferModel(
                                    id: Convert.ToInt32(reader["month_offerID"]),
                                    maxNumFreze: Convert.ToInt32(reader["max_num_freze"]),
                                    numOfMonth: Convert.ToInt32(reader["num_of_months"]),
                                    price: Convert.ToInt32(reader["price"])
                                )
                            );

                            packgeModels.Add(packageModel);
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            PackgeModel packge = new PackgeModel(
                                id: Convert.ToInt32(reader["id"]),
                                numOfClass: Convert.ToInt32(reader["num_of_classes"]),
                                numOfInvatation: Convert.ToInt32(reader["num_of_invatation"]),
                                name: reader["name"].ToString(),
                                status: reader["status"].ToString(),
                                monthOffer: new MonthOfferModel(Convert.ToInt32(reader["month_offerID"]))
                            );

                            packgeModels.Add(packge);
                        }
                    }

                    return packgeModels;
                }
                else
                {
                    Console.WriteLine($"Error getting from Packge search: No records found for '{search}'");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql Packge search: {ex.Message}");
                return null;
            }
        }

        public bool UpdatePackageAttributes(PackgeModel packageModel, bool name = false, bool numOfClass = false, bool numOfInvitation = false, bool discountPercentage = false, bool status = false, bool monthOffer = false)
        {
            try
            {
                string query = "UPDATE packge SET";
                if (name)
                {
                    query += $" name = '{packageModel.Name}',";
                }
                if (numOfClass)
                {
                    query += $" num_of_classes = {packageModel.NumOfClass},";
                }
                if (numOfInvitation)
                {
                    query += $" num_of_invatation = {packageModel.NumOfInvatation},";
                }
                if (discountPercentage)
                {
                    query += $" discount_percentage = {packageModel.DiscountPercentage},";
                }
                if (status)
                {
                    query += $" status = '{packageModel.Status}',";
                }
                if (monthOffer)
                {
                    query += $" month_offerID = {packageModel.MonthOffer.Id},";
                }

                if (query == $"UPDATE packge SET")
                {
                    Console.WriteLine($"Error updating package attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {packageModel.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Package attributes updated successfully for ID: {packageModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating package attributes: No rows affected for ID: {packageModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating package attributes in MySql: {ex.Message}");
                return false;
            }
        }
        public bool AddPackage(PackgeModel packageModel)
        {
            try
            {
                string query = $"INSERT INTO packge (name, month_offerID, num_of_classes, num_of_invatation, discount_percentage, status) VALUES " +
                               $"('{packageModel.Name}', '{packageModel.MonthOffer.Id}', '{packageModel.NumOfClass}', " +
                               $"'{packageModel.NumOfInvatation}', '{packageModel.DiscountPercentage}', '{packageModel.Status}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Package created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding package: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding package in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
