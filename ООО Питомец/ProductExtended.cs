using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООО_Питомец.Model;

namespace ООО_Питомец
{
    internal class ProductExtended
    {
        //    public Products products { get; }

        //    public ProductExtended(Products product)
        //    {
        //        this.products = product;
        //    }

        //    public string ProductImagePath
        //    {
        //        get
        //        {
        //            string path = Environment.CurrentDirectory + "/Resources/" + products.ProductImage;
        //            if (!File.Exists(path))
        //                return "/Resources/dumpPic.png";
        //            return path;
        //        }
        //    }

        //}

        public int ProductID { get; }
        public string ProductName { get; }
        public double ProductPrice { get; }
        public double? ProductSalePrice { get; }
        public int ProductAmount { get; }
        public int ProductCategory { get; }
        public int ProductImage { get; }

        public ProductExtended(Products product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            ProductPrice = product.ProductPrice;
            ProductSalePrice = product.ProductSalePrice;
            ProductAmount = product.ProductAmount;
            ProductCategory = product.ProductCategory;
            ProductImage = product.ProductImage;
        }

        public string ProductImagePath
        {
            get
            {
                string path = Environment.CurrentDirectory + "/Resources/" + ProductImage;
                if (!File.Exists(path))
                    return "/Resources/dumpPic.png";
                return path;
            }
        }
    }
}
