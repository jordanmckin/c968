using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanMcKinneyC968
{
    public class Inventory
    {
        public BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        private int nextPartID = 0;
        private int nextProductID = 0;

        public void AddProduct(Product product)
        {
            product.ProductID = nextProductID;
            nextProductID++;
            Products.Add(product);
        }

        public bool RemoveProduct(int productID)
        {
            Products.Remove(LookupProduct(productID));
            return true;
        }

        public Product LookupProduct(int productID)
        {
            foreach (var product in Products)
            {
                if (Products != null)
                {
                    for (int i = 0; i < Products.Count; i++)
                    {
                        if (product.ProductID == productID)
                        {
                            return product;
                        }
                    }
                }
                else { return null; }
            }
            return null;
        }
        public void UpdateProduct(int productID, Product updatedProduct)
        {
            updatedProduct.ProductID = productID;
            Product productToRemove = Products.FirstOrDefault(product => product.ProductID == productID);
            Products.Remove(productToRemove);
            Products.Add(updatedProduct);
        }

        public void AddPart(Part part)
        {
            part.PartID = nextPartID;
            nextPartID++;
            AllParts.Add(part);
        }

        public bool DeletePart(Part part)
        {

            bool partBeingUsed = false;
            foreach (var product in Products)
            {
                if (product.AssociatedParts != null)
                {
                    for (int i = 0; i < product.AssociatedParts.Count; i++)
                    {
                        if (product.AssociatedParts[i].PartID == part.PartID)
                        {
                            partBeingUsed = true;
                        }
                    }
                }
            }

            if (partBeingUsed) { return false; }
            else
            {
                AllParts.Remove(part);
                return true;
            }
        }

        public Part LookupPart(int partID)
        {
            foreach(var part in AllParts)
            {
                if(AllParts != null)
                {
                    for (int i = 0; i <  AllParts.Count; i++)
                    {
                        if(part.PartID == partID)
                        {
                            return part;
                        }
                    }
                }
                else { return null; }
            }
            return null;
        }

        public void UpdatePart(int partID, Part updatedPart)
        {
            //update the part
            updatedPart.PartID = partID;
            Part partToRemove = AllParts.FirstOrDefault(part => part.PartID == partID);
            AllParts.Remove(partToRemove);
            AllParts.Add(updatedPart);

            foreach (var product in Products)
            {
                for (int i = product.AssociatedParts.Count - 1; i >= 0; i--)
                {
                    if (product.AssociatedParts[i].PartID == partID)
                    {
                        product.AssociatedParts.RemoveAt(i);
                        product.AssociatedParts.Add(updatedPart);
                    }
                }
            }
        }

    }
}
