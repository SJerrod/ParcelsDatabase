using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Parcels.Models
{
    public class Package
    {
      public int Length { get; set; }
      public int Height { get; set; }
      public int Width { get; set; }
      public int Weight { get; set; }
      public int Volume { get; set; }
      public int ShippingPrice { get; set; } = 3;
      public int Cost { get; set; }

      public int Id { get; }

      public Package (int length, int height, int width, int weight, int id)
      {
        Length = length;
        Height = height;
        Width = width;
        Weight = weight;
        Id = id;
      }
      
      public void GetVolume()
      {
          int volume = Length * Height * Width;
          Volume = volume;
      }

      public void CostToShip()
      {
          int cost = (Volume + Weight) * ShippingPrice;
          Cost = cost;
      }
      public static List<Package> GetAll()
      {
        List<Package> allPackages = new List<Package> { };
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM packages;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
          int packageId = rdr.GetInt32(0);
          int packageLength = rdr.GetInt32(1);
          int packageHeight = rdr.GetInt32(2);
          int packageWidth = rdr.GetInt32(3);
          int packageWeight = rdr.GetInt32(4);
          Package newPackage = new Package(packageLength, packageHeight, packageWidth, packageWeight, packageId);
          allPackages.Add(newPackage);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allPackages;
      }

      public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM parcels;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }
    }
}