namespace Radio_CSV_Reader_FIleTraverse
{
    //<sum> This is a class object that will be used as an Iquery once ready for DBContent
    //<Values="_Name","_Date","_PassOrFail"> These are the only values that will be taken from the CSV file and uploaded to the SQL server
    //<Functions="Get_{Values}"> These are getting, and setting the privte fields of the DB content
    public class ResultObjets
    {
        private  string _Name { get;  set; }
        private decimal? _Date { get;  set; }
        private bool _PassOrFail { get;  set; }
    
        public string Set_Name
        {
            set
            {
                this._Name = value;
            }
            get => this.Set_Name = _Name;
        }
        public decimal? Set_Date
        {
            set
            {
                this._Date = value;
            }
            get => this.Set_Date = _Date;
        }
        public bool Set_PassOrFail
        {
            set
            {
                this._PassOrFail = value;
            }
            get => this._PassOrFail = _PassOrFail;
        }
    }
}
