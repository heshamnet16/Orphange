using System.Runtime.InteropServices;
using SharpShell.Attributes;
using SharpShell.SharpIconHandler;
using System;
using SharpShell.SharpInfoTipHandler;

namespace Ovih
{
    /// <summary>
    /// The FolderInfoTip handler is an example SharpInfoTipHandler that provides an info tip
    /// for folders that shows the number of items in the folder.
    /// </summary>
    [ComVisible(true)]
    [COMServerAssociation(SharpShell.Attributes.AssociationType.FileExtension, ".Fam")]
    public class FamInfoTipHandler : SharpInfoTipHandler
    {
        /// <summary>
        /// Gets info for the selected item (SelectedItemPath).
        /// </summary>
        /// <param name="infoType">Type of info to return.</param>
        /// <param name="singleLine">if set to <c>true</c>, put the info in a single line.</param>
        /// <returns>
        /// Specified info for the selected file.
        /// </returns>
        protected override string GetInfo(RequestedInfoType infoType, bool singleLine)
        {
            FileCreation.BinaryFile Br = new FileCreation.BinaryFile();
            FileCreation.XmlBuilder xml = new FileCreation.XmlBuilder();
            Br.FileName = SelectedItemPath;
            Br.Overwite = false;
            Br.UseCrypto = true;
            string[] xx = xml.GetInfo(Br.ReadAllBytes());

            switch (infoType)
            {
                case RequestedInfoType.InfoTip:
                    {
                        if (!singleLine)
                        {
                            return String.Format("{0}" + Environment.NewLine +
                            "{1}" + Environment.NewLine + "{2}" + Environment.NewLine
                            + "{3}" + Environment.NewLine + "{4}"
                            + Environment.NewLine + "{5}", xx[0], xx[1], xx[2], xx[3], xx[4], xx[5]);
                        }
                        else
                        {
                            return String.Format("{0};" +"{1};" + "{2}" ,xx[0], xx[1], xx[3]);
                        }
                    }
                case RequestedInfoType.Name:
                    return "اسم الملف: " + System.IO.Path.GetFileNameWithoutExtension(SelectedItemPath);
                default:

                    //  We won't be asked for anything else, like shortcut paths, for folders, so we 
                    //  can return an empty string in the default case.
                    return string.Empty;
            }
        }
    } 
}
