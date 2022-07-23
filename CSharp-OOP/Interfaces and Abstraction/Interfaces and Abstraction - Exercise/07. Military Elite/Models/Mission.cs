namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    public class Mission : IMission
    {
        private string codeName;
        public string CodeName
        {
            get
            {
                return codeName;
            }
            set
            {
                codeName = value;
            }
        }

        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException("Invalid mission state!");
                }
            }
        }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
