

namespace Fizzbuzz.Model
{

    class FizzBuzzParameters
    {
        private int number = 0;
        public int Number
        {
            get
            {
                if (number <= 0)
                {
                    return 1;
                }
                else return number;
            }
            set { number = value; }
        }

        private string text;
        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(text)) return "Undefined";
                else return text;
            }
            set { text = value; }
        }
    }

    struct FizBuzzResults
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
}