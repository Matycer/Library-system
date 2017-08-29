using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna
{
    class BorrowedBook
    {
        private DateTime borrowed { get; set; }
        private string borrowedBy { get; set; }
        private int remainingDays { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Remaining { get; set; }


        //private DateTime borrowed;
        //private string borrowedBy;
        //private int remainingDays; 
        public BorrowedBook(string userName, DateTime from, String bookName)
        {
            UserName = userName;
            From = from;
            BookName = bookName;
            SetTo();
            SetRemaining();
        }

        private void SetTo()
        {
            To = From.AddMonths(3);
        }
        private void SetRemaining()
        {
            Remaining = (To - DateTime.Now).Days.ToString() + " dnů";
        }
    }
}
