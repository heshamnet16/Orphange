using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Office.Interop.Word;

namespace CTWBCOM
{
    public class BookMarkInserter
    {
        public delegate void IntegerProgressHandler(int i);
        public delegate void StringProgressHandler(int i , string txt);
        public event IntegerProgressHandler IntegerProgress;
        public event StringProgressHandler StringProgress;
        #region Image    
        private bool _UseDefaultImageSize;

        public bool UseDefaultImageSize
        {
            get { return _UseDefaultImageSize; }
            set { _UseDefaultImageSize = value; }
        }

        private Size _DefuaultImageSize;

        public Size DefuaultImageSize
        {
            get { return _DefuaultImageSize; }
            set { _DefuaultImageSize = value; }
        }


        private bool _UseImageBorder;

        public bool UseImageBorder
        {
            get { return _UseImageBorder; }
            set { _UseImageBorder = value; }
        }
        private Dictionary<string, Image> _ImageBookMarks;

        public Dictionary<string, Image> ImageBookMarks
        {
            get { return _ImageBookMarks; }
            set { _ImageBookMarks = value; }
        }
        #endregion


        private string  _TempFileName = null;

        private bool _SaveAsNewFile;

        private string _DestinationFileName;

        public string DestinationFileName
        {
            get { return _DestinationFileName; }
            set { _DestinationFileName = value; }
        }
        public bool SaveAsNewFile
        {
            get { return _SaveAsNewFile; }
            set { _SaveAsNewFile = value; }
        }

        public string TempFileName
        {
            get { return _TempFileName; }
            set { _TempFileName = value; }
        }
        private Dictionary<string, string> _StringBookMarks;

        public Dictionary<string, string> StringBookMarks
        {
            get { return _StringBookMarks; }
            set { _StringBookMarks = value; }
        }
        private bool _UseLastParagraphSetting;

        public bool UseLastParagraphSetting
        {
            get { return _UseLastParagraphSetting; }
            set { _UseLastParagraphSetting = value; }
        }
        private bool _throwExceptions;
        public bool ThrowExceptions
        {
            get { return _throwExceptions; }
            set { _throwExceptions = value; }
        }

        private bool _UseCustomBoolean;
        private string _CustomBoolFontName;

        public string CustomBoolFontName
        {
            get { return _CustomBoolFontName; }
            set { _CustomBoolFontName = value; }
        }
        public bool UseCustomBoolean
        {
            get { return _UseCustomBoolean; }
            set { _UseCustomBoolean = value; }
        }
        private Dictionary<string, int> _boolBookmarke;

        public Dictionary<string, int> BoolBookmarke
        {
            get { return _boolBookmarke; }
            set { _boolBookmarke = value; }
        }

        public BookMarkInserter(string TempFileName)
        {
            _StringBookMarks = new Dictionary<string, string>();
            _ImageBookMarks = new Dictionary<string, Image>();
            _TempFileName = TempFileName  ;
            _throwExceptions = false;
            _UseLastParagraphSetting = true;
            _SaveAsNewFile = false;
            _DestinationFileName = "";
            _UseImageBorder = true;            
        }

        public void Add(string Bookmark_Name, string txt)
        {
            if (!_StringBookMarks.ContainsKey(Bookmark_Name))
                _StringBookMarks.Add(Bookmark_Name, txt);
            else
                if (_throwExceptions)
                    throw new Exception("الإشارة المرجعية موجودة مسبقاً");
        }
        public void AddAfterBookmark()
        {
            try
            {
                float  All = (float)(_StringBookMarks.Count + _ImageBookMarks.Count);
                float i = 0f;
                string savedFile = "";
                if (_SaveAsNewFile)
                {
                    System.IO.File.Copy(_TempFileName, _DestinationFileName, true);
                    savedFile = _DestinationFileName;
                }
                else
                    savedFile = _TempFileName;

                Application WordApp = new Application();
                Document wordDoc =  WordApp.Documents.Open(savedFile);
                float prog = 0f;
                foreach (string book in _StringBookMarks.Keys)
                {
                    string txt = _StringBookMarks[book];
                    if (wordDoc.Bookmarks.Exists(book))
                    {
                        wordDoc.Bookmarks[book].Range.InsertAfter(txt);
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, txt);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }
                }
                foreach (string book in _ImageBookMarks.Keys)
                {
                    Image img = _ImageBookMarks[book];
                    if (wordDoc.Bookmarks.Exists(book))
                    {
                        string tempPic = System.IO.Path.GetTempFileName();
                        Bitmap tempBits = (Bitmap)img;
                        tempBits.Save(tempPic,System.Drawing.Imaging.ImageFormat.Jpeg);                        
                        var shape = wordDoc.Bookmarks[book].Range.InlineShapes.AddPicture(tempPic, false, true);
                        if (_UseDefaultImageSize)
                        {
                            shape.Width = (int)(_DefuaultImageSize.Width / 12700);
                            shape.Height = (int)(_DefuaultImageSize.Height / 12700);
                        }
                        if (_UseImageBorder)
                        {                            
                            shape.Borders[WdBorderType.wdBorderBottom].Visible = true;
                            shape.Borders[WdBorderType.wdBorderLeft].Visible = true;
                            shape.Borders[WdBorderType.wdBorderRight].Visible = true;
                            shape.Borders[WdBorderType.wdBorderTop].Visible = true;
                        }
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, book);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }
                }
                //custom boolMarks
                if (_UseCustomBoolean)
                {
                    object CFn = CustomBoolFontName;
                    foreach (string book in _boolBookmarke.Keys)
                    {
                        int txt = _boolBookmarke[book];
                        object oUnicode = true;
                        object oBias = WdFontBias.wdFontBiasDontCare;
                        if (wordDoc.Bookmarks.Exists(book))
                        {                            
                            wordDoc.Bookmarks[book].Range.InsertSymbol(txt, ref CFn,ref oUnicode,ref oBias);
                            i++;
                            prog = (i / All) * 100f;
                            if (StringProgress != null)
                                StringProgress((int)prog, book);
                            if (IntegerProgress != null)
                                IntegerProgress((int)prog);
                        }
                    }
                }
                wordDoc.Save();
               ((_Application)WordApp).Quit(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdWordDocument);
                
            }
            catch (Exception ex)
            {
                if (_throwExceptions)
                    throw ex;
            }

        }

        private void FindAndReplace(Document  doc,
                                    object findText,
                                    object replaceWithText)
        {
            var range = doc.Range();
            

            range.Find.Execute(FindText: findText, Replace: WdReplace.wdReplaceAll, ReplaceWith: replaceWithText);

            var shapes = doc.Shapes;

            foreach (Shape shape in shapes)
            {
                var initialText = shape.TextFrame.TextRange.Text;
                if (initialText.Length >=2)
                {
                    var resultingText = initialText.Replace((string)findText, (string)replaceWithText);
                    shape.TextFrame.TextRange.Text = resultingText;
                }
            }
        }

        private void FindAndReplaceSymbol(Application wdApp,
                            object findText,
                            int replaceWithSymbol)
        {
            object missing = Type.Missing;
            Document wdDoc = wdApp.ActiveDocument;
            Range wdRange = wdDoc.Range(wdDoc.Content.Start,wdDoc.Content.End);            
            wdRange.Select();
            wdApp.Selection.Find.Text = findText.ToString();
            wdApp.Selection.Find.Forward = true;
            wdApp.Selection.Find.Wrap = WdFindWrap.wdFindStop;
            object wdLine = WdUnits.wdLine;
            object wdExtend = WdMovementType.wdExtend;
            object count = 1;
            object CFn = CustomBoolFontName;
            object oUnicode = true;
            object oBias = WdFontBias.wdFontBiasDontCare;
            while (wdApp.Selection.Find.Execute())
            {
                wdApp.Selection.HomeKey(ref wdLine, ref missing);
                wdApp.Selection.MoveDown(ref wdLine, ref count, ref wdExtend);
                wdApp.Selection.Delete();
                wdApp.Selection.InsertSymbol(replaceWithSymbol, ref CFn, ref oUnicode, ref oBias);
            }
            var shapes = wdDoc.Shapes;
            foreach (Shape shape in shapes)
            {
                var initialText = shape.TextFrame.TextRange.Text;
                if (initialText.Length >= 2)
                {
                    if (initialText.Trim() == findText.ToString())
                    {
                        shape.TextFrame.TextRange.Text = "";
                        shape.TextFrame.TextRange.InsertSymbol(replaceWithSymbol, ref CFn, ref oUnicode, ref oBias);
                    }
                }
            }
        }

        public void ReplaceText()
        {
            try
            {
                float All = (float)(_StringBookMarks.Count + _ImageBookMarks.Count);
                float i = 0f;
                string savedFile = "";
                if (_SaveAsNewFile)
                {
                    System.IO.File.Copy(_TempFileName, _DestinationFileName, true);
                    savedFile = _DestinationFileName;
                }
                else
                    savedFile = _TempFileName;

                Application WordApp = new Application();
                Document wordDoc = WordApp.Documents.Open(savedFile);
                float prog = 0f;
                foreach (string book in _StringBookMarks.Keys)
                {
                    string txt = _StringBookMarks[book];
                    FindAndReplace(wordDoc, book, txt);
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, txt);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                }
                foreach (string book in _ImageBookMarks.Keys)
                {
                    Image img = _ImageBookMarks[book];
                    if (wordDoc.Bookmarks.Exists(book))
                    {
                        string tempPic = System.IO.Path.GetTempFileName();
                        Bitmap tempBits = (Bitmap)img;
                        tempBits.Save(tempPic, System.Drawing.Imaging.ImageFormat.Jpeg);
                        var shape = wordDoc.Bookmarks[book].Range.InlineShapes.AddPicture(tempPic, false, true);
                        if (_UseDefaultImageSize)
                        {
                            shape.Width = (int)(_DefuaultImageSize.Width / 12700);
                            shape.Height = (int)(_DefuaultImageSize.Height / 12700);
                        }
                        if (_UseImageBorder)
                        {
                            shape.Borders[WdBorderType.wdBorderBottom].Visible = true;
                            shape.Borders[WdBorderType.wdBorderLeft].Visible = true;
                            shape.Borders[WdBorderType.wdBorderRight].Visible = true;
                            shape.Borders[WdBorderType.wdBorderTop].Visible = true;
                        }
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, book);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }
                }
                if (_UseCustomBoolean)
                {
                    foreach (string book in _boolBookmarke.Keys)
                    {
                        int txt = _boolBookmarke[book];
                        FindAndReplaceSymbol(WordApp, book, txt);
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, book);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }
                }
                wordDoc.Save();
                ((_Application)WordApp).Quit(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdWordDocument);

            }
            catch (Exception ex)
            {
                if (_throwExceptions)
                    throw ex;
            }

        }

    }
}
