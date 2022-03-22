namespace encoding
{
    class encoding
    {
        public static void Main(String[] args)
        {
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\temp\personal_ledger.accdb";
            string query = "select * from expense_detail where expense_id in (1,2,3,4,5,6,7,8,9,10)";
            List<data.expense_detail> Expense_detail = data.ReadData(ConnectionString, query);
            
            foreach (data.expense_detail expense in Expense_detail)
            {
                Console.WriteLine($" Orginal Value is {data.Decode(expense.expense_id)} | {data.Decode(expense.paid_to)}");
                Console.WriteLine($" Coded  Value is  {expense.expense_id}|  {expense.paid_to}|");               
            }
            Console.ReadKey();
        }


    }
}