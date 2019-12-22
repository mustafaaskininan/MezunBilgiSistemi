using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class TreeNode
    {
        public object Veri;
        public TreeNode Sol;
        public TreeNode Sag;

        public TreeNode()
        {
            Sol = null;
            Sag = null;
        }
    }
}
