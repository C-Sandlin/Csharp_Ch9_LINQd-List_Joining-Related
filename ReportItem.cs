namespace LINQd_List_joinging_related
{
    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }

        public ReportItem(string customer, string bank)
        {
            CustomerName = customer;
            BankName = bank;
        }
    }
}