using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OrphanageClient
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            try
            {
                WMCont.Browsing.DriveI[] drvs = Form1.obj.S_GetBrowsingDrivers();
                if (drvs != null)
                {
                    foreach (WMCont.Browsing.DriveI drv in drvs)
                    {

                        List<Icon> lst = new List<Icon>();
                        if(drv.Icons != null)
                        foreach (byte[] btt in drv.Icons)
                        {
                            if (btt != null)
                            {
                                MemoryStream mm = new MemoryStream(btt);
                                Icon ic = new Icon(mm);
                                lst.Add(ic);
                            }
                        }
                        AddItem(drv.Name, lst.ToArray());
                    }
                }
            }
            catch { }
        }
        private void AddItem(string fullpath, Icon[] ico)
        {
            string name;
            try
            {

                imageListS.Images.Add(fullpath,ico[0].ToBitmap() );
            }
            catch { imageListS.Images.Add(fullpath, new Bitmap(16,16)); }
            try
            {
                imageListB.Images.Add(fullpath, ico[1].ToBitmap());
            }
            catch { imageListB.Images.Add(fullpath, new Bitmap(64, 64)); }
            if (Path.GetExtension(fullpath) != null && Path.GetExtension(fullpath).Length > 1)
            {
                name = Path.GetFileName(fullpath);
            }
            else
            {          
                int lastSlach = fullpath.LastIndexOf('\\');
                name = fullpath.Substring(lastSlach+1, fullpath.Length - lastSlach-1); ;
            }
            if (name == null || name.Length <= 2)
                name = fullpath;
            ListViewItem itm = new ListViewItem(name, fullpath);
            listView1.Items.Add(itm);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                imageListB.Images.Clear();
                imageListS.Images.Clear();
                WMCont.Browsing.FolderI[] folds = Form1.obj.S_getBrowsingSubFolders(txtAddress.Text);
                if (folds != null)
                {
                    foreach (WMCont.Browsing.FolderI drv in folds)
                    {

                        List<Icon> lst = new List<Icon>();
                        if (drv.Icon != null)
                            foreach (byte[] btt in drv.Icon)
                            {
                                if (btt != null)
                                {
                                    MemoryStream mm = new MemoryStream(btt);
                                    Icon ic = new Icon(mm);
                                    lst.Add(ic);
                                }
                            }
                        AddItem(drv.fullPath, lst.ToArray());
                    }
                }
                WMCont.Browsing.FileI[] fils = Form1.obj.S_GetBrowsingsubFiles(txtAddress.Text);
                if (fils != null)
                {
                    foreach (WMCont.Browsing.FileI drv in fils)
                    {

                        List<Icon> lst = new List<Icon>();
                        if (drv.Icons != null)
                            foreach (byte[] btt in drv.Icons)
                            {
                                if (btt != null)
                                {
                                    MemoryStream mm = new MemoryStream(btt);
                                    Icon ic = new Icon(mm);
                                    lst.Add(ic);
                                }
                            }
                        AddItem(drv.FullPath, lst.ToArray());
                    }
                }
            }
            catch { }
        }
    }
}
