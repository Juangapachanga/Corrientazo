using System;
using System.Collections.Generic;
using System.Text;

namespace Corrientazo.Core.Abstractas
{
    public abstract class CoordenadaBase
    {
        private int _x;
        private int _y;
        private int _max;


        public CoordenadaBase(int x, int y, int max)
        {
            _x = x;
            _y = y;
            _max = max;
        }

        public int x
        {
            get { return _x; }
            set {
                if (value>_max)
                {
                    throw new Exception("Fuera del límite X");
                }
                else
                {
                    _x = value;
                }
            }
        }

        public int y
        {
            get { return _y; }
            set
            {
                if (value > _max)
                {
                    throw new Exception("Fuera del límite Y");
                }
                else
                {
                    _y = value;
                }
            }
        }

        public int max
        {
            get
            {
                return _max;
            }
        }

    }
}
