using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Const
{
    public class eView
    {
        public static readonly string Index = "Index";
        public static readonly string _BookSummary = "_BookSummary";
        public static readonly string Menu = "Menu";
        public static readonly string Checkout = "Checkout";
        public static readonly string CartSummary = "CartSummary";
        public static readonly string Completed = "Completed";
        public static readonly string Error = "Error";
        public static readonly string Edit = "Edit";
    }
    public class eAction
    {
        public static readonly string Index = "Index";
        public static readonly string AddToCart = "AddToCart";
        public static readonly string List = "List";
        public static readonly string Menu = "Menu";
        public static readonly string Checkout = "Checkout";
        public static readonly string CartSummary = "CartSummary";
        public static readonly string Unauthorized = "Unauthorized";
        public static readonly string NotFound = "NotFound";
        public static readonly string Forbidden = "Forbidden";
        public static readonly string NavBar = "NavBar";
        public static readonly string Edit = "Edit";
        public static readonly string Delete = "Delete";
        public static readonly string Create = "Create";
        public static readonly string Customers = "Customers";
        public static readonly string Orders = "Orders";
        public static readonly string Main = "Main";
        public static readonly string EditCustomer = "EditCustomer";
        public static readonly string DeleteCustomer = "DeleteCustomer";
        public static readonly string Details = "Details";

    }
    public class eController
    {
        public static readonly string Book = "Book";
        public static readonly string Cart = "Cart";
        public static readonly string Nav = "Nav";
        public static readonly string Errors = "Errors";
        public static readonly string Admin = "Admin";
    }
    public class eParameters
    {
        public static readonly string ReturnUrl = "returnUrl";
    }
}