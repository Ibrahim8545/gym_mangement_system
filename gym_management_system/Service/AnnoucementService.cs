using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class AnnoucementService
    {
        public List<AnnoucementModl> GetAllAnnouncements(bool includePicture = false)
        {
            try
            {
                List<AnnoucementModl> announcements = new List<AnnoucementModl>();
                string query = $"SELECT {GetSelectColumns(includePicture)} FROM announcement";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AnnoucementModl announcement = new AnnoucementModl(
                            id: Convert.ToInt32(reader["id"]),
                            title: reader["title"].ToString(),
                            content: reader["content"].ToString(),
                            date: Convert.ToDateTime(reader["date"]),
                            base64Image: reader["image"].ToString(),
                            employeeModel: new EmployeeModel(id: Convert.ToInt32(reader["id"]))
                        );

                        if (includePicture)
                        {
                            announcement.Picture = Global.mangeImage.ConvertBase64ToImage(reader["picture"].ToString());
                        }

                        announcements.Add(announcement);
                    }

                    return announcements;
                }
                else
                {
                    Console.WriteLine("Error getting from GetAllAnnouncements: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql GetAllAnnouncements: {ex.Message}");
                return null;
            }
        }
        public bool AddAnnouncement(AnnoucementModl announcementModel)
        {
            try
            {

                string query = $"INSERT INTO announcement (title, content, date, image, employeeID) VALUES " +
                               $"( '{announcementModel.Title}', '{announcementModel.Content}', '{announcementModel.Date.ToString("yyyy-MM-dd")}', " +
                               $"'{announcementModel.Base64Image}', '{announcementModel.EmployeeModel?.Id}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Announcement created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding Announcement: No rows affected");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error adding Announcement in MySql: {ex.Message}");
                return false;
            }
        }
        public bool UpdateAnnouncementAttributes(AnnoucementModl announcementModel, bool title = false, bool content = false, bool date = false, bool image = false, bool employeeId = false)
        {
            try
            {
                string query = "UPDATE annoucement SET";
                if (title)
                {
                    query += $" title = '{announcementModel.Title}',";
                }
                if (content)
                {
                    query += $" content = '{announcementModel.Content}',";
                }
                if (date)
                {
                    query += $" date = '{announcementModel.Date.ToString("yyyy-MM-dd")}',";
                }
                if (image)
                {
                    query += $" image = '{announcementModel.Base64Image}',";
                }
                if (employeeId)
                {
                    query += $" employeeID = '{announcementModel.EmployeeModel.Id}',";
                }

                if (query == "UPDATE annoucement SET")
                {
                    Console.WriteLine($"Error updating announcement attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {announcementModel.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Announcement attributes updated successfully for ID: {announcementModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating announcement attributes: No rows affected for ID: {announcementModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating announcement attributes in MySql: {ex.Message}");
                return false;
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
                return "id, title, content, date, employeeID";
            }
        } 
    }
}
