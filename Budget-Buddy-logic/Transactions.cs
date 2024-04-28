
namespace Budget_Buddy_logic
{
    internal class Transaction
    {
        private string _type;
        private string _date;
        private string _category;
        private float _amount;
        private string _note;
        public Transaction(string type, string date, string category, float amount, string note)
        {
            _type = type;
            _date = date;
            _category = category;
            _amount = amount;
            _note = note;
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
    }
}
