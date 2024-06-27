﻿using ProductApp_1165395.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace ProductApp_1165395.DataLayer
{
public class ProductRepositorySQL : IProductsRepository
    {
        IDataAccess _idac = new DataAccess();
        public bool AddProduct(Product prod)
        {
            string sql = "insert into Products(ProductId,ProductName,Description,Price," +
            "OnSale,Discontinued,StockLevel,PColor,CategoryId) values(" +
            "@ProductId,@ProductName,@Description,@Price,@OnSale,@Discontinued," +
            "@StockLevel,@PColor,@CategoryId)";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@ProductId", prod.ProductId);
            ParamList.Add(p1);
            SqlParameter p2 = new SqlParameter("@ProductName", prod.ProductName);
            ParamList.Add(p2);
            SqlParameter p3 = new SqlParameter("@Description", prod.Description);
            ParamList.Add(p3);
            SqlParameter p4 = new SqlParameter("@Price", prod.Price);
            ParamList.Add(p4);
            SqlParameter p5 = new SqlParameter("@OnSale", prod.OnSale);
            ParamList.Add(p5);
            SqlParameter p6 = new SqlParameter("@Discontinued", prod.Discontinued);
            ParamList.Add(p6);
            SqlParameter p7 = new SqlParameter("@StockLevel", prod.StockLevel);
            ParamList.Add(p7);
            SqlParameter p8 = new SqlParameter("@PColor", prod.Pcolor);
            ParamList.Add(p8);
            SqlParameter p9 = new SqlParameter("@CategoryId", prod.CategoryId);
            ParamList.Add(p9);
            int rows = _idac.InsertUpdateDelete(sql, ParamList);
            if (rows > 0)
                return true;
            else
                return false;
        }
        public bool ApplyDiscount(int prodid, double percentDiscount)
        {
            double factor = (1 - percentDiscount / 100.0);
            string sql = "Update Products set Price=Price*" + factor.ToString() +
            " where ProductId=@ProductId";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@ProductId", prodid);
            ParamList.Add(p1);
            int rows = _idac.InsertUpdateDelete(sql, ParamList);
            if (rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteProduct(int prodid)
        {
            string sql = "Delete from Products where ProductId=@ProductId";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@ProductId", prodid);
            ParamList.Add(p1);
        int rows = _idac.InsertUpdateDelete(sql, ParamList);
            if (rows > 0)
                return true;
            else
                return false;
        }
        public List<Category> GetCategories()
        {
            string sql = "Select * from Categories";
            DataTable dt = _idac.GetManyRowsCols(sql, null);
            List<Category> CList = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                Category c1 = new Category();
                c1.CategoryId = (int)dr["CategoryId"];
                c1.CategoryName = dr["CategoryName"].ToString();
                CList.Add(c1);
            }
            return CList;
        }
        public Product GetProductById(int prodid)
        {
            string sql = "Select * from Products where ProductId=@ProductId";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@ProductId", prodid);
            ParamList.Add(p1);
            DataTable dt = _idac.GetManyRowsCols(sql, ParamList);
            Product pr = new Product();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pr.ProductId = (int)dr["ProductId"];
                pr.ProductName = dr["ProductName"].ToString();
                pr.Description = dr["Description"].ToString();
                pr.Price = (decimal)dr["Price"];
                pr.StockLevel = (int)dr["StockLevel"];
                pr.OnSale = (bool)dr["OnSale"];
                pr.Discontinued = (bool)dr["Discontinued"];
                pr.CategoryId = (int)dr["CategoryId"];
                pr.Pcolor = dr["PColor"] == null ? null : (int)dr["PColor"];
            }
            return pr;
        }
        public List<Product> GetProductsByCatId(int catid)
        {
            string sql = "Select * from Products where CategoryId=@CategoryId";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@CategoryId", catid);
            ParamList.Add(p1);
            DataTable dt = _idac.GetManyRowsCols(sql, ParamList);
            List<Product> PList = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                Product pr = new Product();
                pr.ProductId = (int)dr["ProductId"];
            pr.ProductName = dr["ProductName"].ToString();
                pr.Description = dr["Description"].ToString();
                pr.Price = (decimal)dr["Price"];
                pr.StockLevel = (int)dr["StockLevel"];
                pr.OnSale = (bool)dr["OnSale"];
                pr.Discontinued = (bool)dr["Discontinued"];
                pr.CategoryId = (int)dr["CategoryId"];
                var pcol = dr["PColor"].ToString();
                pr.Pcolor = pcol == "" ? null : (int)dr["PColor"];
                PList.Add(pr);
            }
            return PList;
        }
        public bool UpdateProduct(Product prod)
        {
            string sql = "Update Products set ProductName=@ProductName," +
            "Description=@Description,Price=@Price,StockLevel=@StockLevel," +
            "OnSale=@OnSale,Discontinued=@Discontinued,PColor=@PColor," +
            "CategoryId=@CategoryId where ProductId=@ProductId";
            List<DbParameter> ParamList = new List<DbParameter>();
            SqlParameter p1 = new SqlParameter("@ProductId", prod.ProductId);
            ParamList.Add(p1);
            SqlParameter p2 = new SqlParameter("@ProductName", prod.ProductName);
            ParamList.Add(p2);
            SqlParameter p3 = new SqlParameter("@Description", prod.Description);
            ParamList.Add(p3);
            SqlParameter p4 = new SqlParameter("@Price", prod.Price);
            ParamList.Add(p4);
            SqlParameter p5 = new SqlParameter("@OnSale", prod.OnSale);
            ParamList.Add(p5);
            SqlParameter p6 = new SqlParameter("@Discontinued", prod.Discontinued);
            ParamList.Add(p6);
            SqlParameter p7 = new SqlParameter("@StockLevel", prod.StockLevel);
            ParamList.Add(p7);
            SqlParameter p8 = new SqlParameter("@PColor", prod.Pcolor);
            ParamList.Add(p8);
            SqlParameter p9 = new SqlParameter("@CategoryId", prod.CategoryId);
            ParamList.Add(p9);
            int rows = _idac.InsertUpdateDelete(sql, ParamList);
            if (rows > 0)
                return true;
            else
                return false;
        }
    }
}