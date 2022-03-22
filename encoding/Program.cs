namespace encoding
{
    class encoding
    {
        public static void Main(String[] args)
        {
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\temp\personal_ledger.accdb";
            string query = "select * from expense_detail";
            List<data.expense_detail> Expense_detail = data.ReadData(ConnectionString, query);
            
            /*foreach (data.expense_detail expense in Expense_detail)
            {
                Console.WriteLine($" {expense.expense_id}|  {expense.paid_to}|");

            }*/
            
            foreach(data.expense_detail expense in Expense_detail)
            {
                Console.WriteLine($"{data.Base64Decode(expense.expense_id)} | {data.Base64Decode(expense.paid_to)}");
            }
            Console.ReadKey();

        }


    }
}