using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Z2data.Invoice.Core.Entity;
using Z2data.Invoice.Core.Interfaces;

namespace Z2data.Invoice.Core.Repository
{
    public class ItemsRepo : ItemsInterface
    {
        private IConfiguration _config;
        
        public ItemsRepo(IConfiguration config)
        {
            _config = config;
        }

        public void AddItems(Items items)
        {
            try
            {
                var Item = new Items();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("InsertItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ItemsName", items.ItemName);
                    cmd.Parameters.AddWithValue("@ItemsDate", items.ItemDate);
                    cmd.Parameters.AddWithValue("@CategoryID", items.CategoryID);
                    cmd.ExecuteNonQuery();
                }       
             }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteItems(int ID)
        {
            try
            {
                var Item = new Items();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("DeleteItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ItemsID", ID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all Items 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Items> GetItems()
        {
            try
            {
                var CS = _config.GetConnectionString("DefaultConnection");
                List<Items> Items = new List<Items>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("GetItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var Item = new Items()
                        {
                            ItemID = Convert.ToInt32(rdr["ItemId"]),
                            ItemName = rdr["ItemName"].ToString(),
                            ItemDate = rdr["ItemDate"].ToString() == null ? (DateTime)rdr["ItemDate"] : default,
                            CategoryID = Convert.ToInt32(rdr["CategoryID"])

                        };
                        Items.Add(Item);
                    }
                    return (Items);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
            /// <summary>
            /// Get Item By id 
            /// </summary>
            /// <param name="ID">int Param</param>
            /// <returns></returns>
            public Items GetItemsById(int ID)
            {
            try
            {
                var Item = new Items();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("GetItemsById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Item = new Items()
                        {
                            ItemID = Convert.ToInt32(rdr["ItemId"]),
                            ItemName = rdr["ItemName"].ToString(),
                            ItemDate = rdr["ItemDate"].ToString() == null ? (DateTime)rdr["ItemDate"] : default,
                            CategoryID = Convert.ToInt32(rdr["CategoryID"])

                        };
                    }
                }
            return Item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// update exist Items
        /// </summary>
        /// <param name="items">Object Param</param>
        /// <returns></returns>
        public Items UpdateItems(Items items)
        {
            try
            {
                var Item = new Items();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("UpdateItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ItemsID", items.ItemID);
                    cmd.Parameters.AddWithValue("@ItemsName", items.ItemName);
                    cmd.Parameters.AddWithValue("@ItemsDate", items.ItemDate);
                    cmd.Parameters.AddWithValue("@CategoryID", items.CategoryID);
                    var res = cmd.ExecuteNonQuery();
                    if (res > 0)
                        return items;
                    
                }
                return Item;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    } 
