﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            while(Console.KeyAvailable)//Here I made some optimizations related with the moving of the racket
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
