using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Tree
    {
        TreeNode kok;
        Kisi k = null;
        Kisi k2 = null;
        public string isimler;
        private int duzey;
        public void Ekle(object veri)
        {
            k = (Kisi)veri;
            TreeNode tempParent = new TreeNode();
            TreeNode tempSearch = kok;

            while (true)
            {
                if (tempSearch == null)
                    break;
                tempParent = tempSearch;
                k2 = (Kisi)tempSearch.Veri;
                if (string.Compare(k.Ad, k2.Ad) == 0)
                    return;
                else if (string.Compare(k.Ad, k2.Ad) == -1)
                    tempSearch = tempSearch.Sol;
                else
                    tempSearch = tempSearch.Sag;
                
            }
            TreeNode add = new TreeNode();
            add.Veri = veri;

            if (kok == null)
                kok = add;
            else if (string.Compare(k.Ad, k2.Ad) == -1)
                tempParent.Sol = add;
            else
                tempParent.Sag = add;
        }
        public TreeNode min(TreeNode tmpSol)
        {
            while (tmpSol.Sol != null)
            {
                tmpSol = tmpSol.Sol;
            }
            return tmpSol;
        }
        public TreeNode successor(TreeNode hede)
        {
            if (hede.Sag != null)
                return min(hede.Sag);
            else
                return null;
        }

        public bool delete(object veri)
        {
            TreeNode current = kok;
            TreeNode parent = kok;
            k = (Kisi)veri;
            k2 = (Kisi)current.Veri;
            bool issol = true;
            while (current != null)
            {
                parent = current;
                k2 = (Kisi)current.Veri;
                
                if (string.Compare(k.Ad, k2.Ad) == 0)
                {
                    issol = true;
                    break;
                }
                else if (string.Compare(k.Ad, k2.Ad) == -1)
                {
                    issol = false;
                    current = current.Sol;
                }
                else
                {
                    issol = false;
                    current = current.Sag;
                }

            }
            if (current == null)
                return false;
            if (current.Sol == null && current.Sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.Sol = null;
                else
                    parent.Sag = null;
                return true;
            }
            else if (current.Sag == null)
            {
                if (current == kok)
                    kok = current.Sol;
                else if (issol)
                    parent.Sol = current.Sol;
                else
                    parent.Sag = current.Sol;
                return true;
            }
            else if (current.Sol == null)
            {
                if (current == kok)
                    kok = current.Sag;
                else if (issol)
                    parent.Sol = current.Sag;
                else
                    parent.Sag = current.Sag;
                return true;
            }
            else
            {
                TreeNode Successor = successor(current);
                if (current == kok)
                    kok = Successor;
                else if (issol)
                    parent.Sol = Successor;
                else
                    parent.Sag = Successor;
                Successor.Sol = current.Sol;
                return true;
            }
        }

        private void ortziyaret(TreeNode dugum)
        {
            k2 = (Kisi)dugum.Veri;
            if (k2.egitim.NotOrt >= 90)
                isimler += k2.Ad + "\n";
        }
        public void ortisim()
        {
            isimler = "";
            ortAd(kok);
        }
        private void ortAd(TreeNode dugum)
        {
            if(dugum == null)
                return;
            ortziyaret(dugum);
            ortAd(dugum.Sol);
            ortAd(dugum.Sag);
        }

        private void ingziyaret(TreeNode dugum)
        {
            k2 = (Kisi)dugum.Veri;
            if (k2.YabanciDil == "ingilizce")
                isimler += k2.Ad + "\n";
        }
        public void ingisim()
        {
            isimler = "";
            ingAd(kok);
        }
        private void ingAd(TreeNode dugum)
        {
            if (dugum == null)
                return;
            ingziyaret(dugum);
            ingAd(dugum.Sol);
            ingAd(dugum.Sag);
        }
        private void allziyaret(TreeNode dugum)
        {
            duzey++;
            k2 = (Kisi)dugum.Veri;
            isimler += duzey + ". " + k2.Ad + "\n";
        }
        public void allisim()
        {
            duzey = 0;
            isimler = "Preorder\n";
            allAdPreorder(kok);
            duzey = 0;
            isimler += "\nInorder\n";
            allAdInorder(kok);
            duzey = 0;
            isimler += "\nPostorder\n";
            allAdPostorder(kok);
        }
        private void allAdPostorder(TreeNode dugum)
        {
            if (dugum == null)
                return;            
            allAdPostorder(dugum.Sol);
            allAdPostorder(dugum.Sag);
            allziyaret(dugum);
        }

        private void allAdPreorder(TreeNode dugum)
        {
            if (dugum == null)
                return;
            allziyaret(dugum);
            allAdPreorder(dugum.Sol);
            allAdPreorder(dugum.Sag);
        }

        private void allAdInorder(TreeNode dugum)
        {
            if (dugum == null)
                return;
            allAdInorder(dugum.Sol);
            allziyaret(dugum);            
            allAdInorder(dugum.Sag);
        }

        public object Ara(string ad)
        {
            Kisi k2 = null;
            TreeNode tempParent = new TreeNode();
            TreeNode tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                k2 = (Kisi)tempSearch.Veri;
                if (string.Compare(ad, k2.Ad) == 0)
                    return tempSearch.Veri;
                else if (string.Compare(ad, k2.Ad) == -1)
                    tempSearch = tempSearch.Sol;
                else
                    tempSearch = tempSearch.Sag;
            }
            return null;
        }
        public int eSay()
        {
            return elemanSay(kok);
        }
        private int elemanSay(TreeNode node)
        {
            if (node == null)
                return 0;
            if (node.Sol == null && node.Sag == null)
                return 1;
            else
                return elemanSay(node.Sol) +
                       elemanSay(node.Sag); 
        }
    }
}
