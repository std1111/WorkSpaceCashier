using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpaceCashier
{
    class ListStaticVar
    {
        public static string URI_BaseAddress = "https://dev-api.checkbox.in.ua/";
        public static string URI_SigningCashier = "/api/v1/cashier/signin";
        public static string URI_ShiftOpen = "/api/v1/shifts";
        public static string URI_ShiftClose = "/api/v1/shifts/close";
        public static string URI_ShiftGetInfo = "/api/v1/shifts/";
        public static string Separator = "-----------------------------------------------------\n";

    }
}
