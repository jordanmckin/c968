using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanMcKinneyC968
{
    public class Product
    {
        public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool RemoveAssociatedPart(int partID)
        {
           AssociatedParts.Remove(LookupAssociatedPart(partID));
            return true;

        }

        public Part LookupAssociatedPart(int partID)
        {
            foreach (var part in AssociatedParts)
            {
                if (AssociatedParts != null)
                {
                    for (int i = 0; i < AssociatedParts.Count; i++)
                    {
                        if (part.PartID == partID)
                        {
                            return part;
                        }
                    }
                }
                else { return null; }
            }
            return null;
        }
    }
}
