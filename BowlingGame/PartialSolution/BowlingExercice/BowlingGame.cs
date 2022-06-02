using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingExercice
{
    public class BowlingGame
    {
        int _currentFrame = 0;

        public Frame[] Frames { get; set; } = new Frame[0];

        public int CurrentFrame { get { return _currentFrame + 1; } }

        public void Start()
        {
            _currentFrame = 0;
            Frames = new Frame[10];
            for (int i = 0; i < Frames.Length; i++)
                Frames[i] = new Frame();
        }

        public void Roll(int pin)
        {
            Frames[_currentFrame].Roll(pin);

            if (_currentFrame > 0 &&
                Frames[_currentFrame - 1].IsSpare &&
                Frames[_currentFrame].SecondThrow == null)
            {
                Frames[_currentFrame - 1].Bonus = pin;
            }

            if (Frames[_currentFrame].IsCompleted) _currentFrame++;     

        }
    }
}
