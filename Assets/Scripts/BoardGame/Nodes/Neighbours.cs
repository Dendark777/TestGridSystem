using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Nodes
{
    public class Neighbours
    {
        public static readonly Point[] Points = new Point[]
            {
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0),
                new Point(1, -1),
                new Point(0, -1),
                new Point(-1, -1),
                new Point(-1, 0),
                new Point(-1, 1),
            };
    }
}
