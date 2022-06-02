namespace BowlingExercice
{
    public class Frame
    {
        int? _firstThrow = null;
        int? _secondThrow = null;

        public void Roll(int pin)
        {
            if (FirstThrow == null)
                _firstThrow = pin;
            else if (_secondThrow == null)
                _secondThrow = pin;
            else
                throw new InvalidOperationException("Already two ball thrown for this frame.");

            if (TotalPins > 10)
                throw new ArgumentException("Too many pins specified."); 
        }

        public int TotalPins
        {
            get
            {
                return (FirstThrow ?? 0) + (SecondThrow ?? 0);
            }
        }

        public int Bonus { get; set; }

        public int? FirstThrow { get => _firstThrow; }
        public int? SecondThrow { get => _secondThrow; }

        public bool IsCompleted { get { return TotalPins == 10 || _secondThrow != null; } }
        public bool IsSpare { get { return TotalPins == 10 && _secondThrow != null; } }

        public bool IsStrike { get { return FirstThrow == 10; } }
    }
}