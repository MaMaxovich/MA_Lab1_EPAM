using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    abstract class Gadjet {
        private string name;
        private int lenght;
        private int width;
        private string os;

        abstract public void ShowScreen();

        public string Name
        {
            get
            {

                return name;
            }

            set
            {
               
                name = value.ToUpper();
            }
        }

        public int Lenght
        {
            get
            {
                return lenght;
            }

            set
            {
                lenght = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public string OS
        {
            get
            {
                return os;
            }

            set
            {
                os = value;
            }
        }
    }
}
