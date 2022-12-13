using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public List<Product> Products { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Customer> Customers { get; set; }

    }
}