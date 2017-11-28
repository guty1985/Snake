using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class cola: Objeto
    {
        cola siguiente;
        public cola(int x, int y)
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }

        public void dibujar (Graphics g)
        {
            if (siguiente != null)
            {
                siguiente.dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Green),this.x, this.y, this.ancho, this.ancho);
        }

        public void setxy (int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }
            this.x = x;
            this.y = y;
        }
        public void meter()
        {
            if (siguiente == null)
            {
                siguiente = new cola(this.x, this.y);
            }
            else
            {
                siguiente.meter();
            }
        }


        public int verx()
        {
            return this.x;
        }
        public int very()
        {
            return this.y;
        }
        public cola verSiguiente()
        {
            return siguiente;
        }
    }
}
