using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DocumentFormat.OpenXml;
using System.Collections;
namespace CTWBOXML
{
    public class BookMarkReplacer
    {            
        public delegate void IntegerProgressHandler(int i);
        public delegate void StringProgressHandler(int i , string txt);
        public event IntegerProgressHandler IntegerProgress;
        public event StringProgressHandler StringProgress;

        private ArrayList _UsedIDs = new ArrayList();
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

        private bool _UseImageBorder;

        public bool UseImageBorder
        {
            get { return _UseImageBorder; }
            set { _UseImageBorder = value; }
        }

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
        private Dictionary<string, Image> _ImageBookMarks;

        public Dictionary<string, Image> ImageBookMarks
        {
            get { return _ImageBookMarks; }
            set { _ImageBookMarks = value; }
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


        public BookMarkReplacer(string TempFileName)
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
                float prog = 0f;
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(savedFile, true))
                {
                    foreach (string book in _StringBookMarks.Keys)
                    {
                        string txt = _StringBookMarks[book];
                        foreach (BookmarkStart Bs in wordDoc.MainDocumentPart.Document.Descendants<BookmarkStart>())
                        {
                            if (Bs.Name == book)
                            {
                                if (Bs.Parent is Paragraph)
                                {
                                    Bs.Parent.AppendChild<Run>(new Run(new Text(txt)));
                                }
                                else if (Bs.Parent is Run)
                                {
                                    Bs.Parent.AppendChild<Text>(new Text(txt));
                                }
                                else
                                {
                                    var nextSP = Bs.NextSibling<Paragraph>();
                                    if (nextSP != null)
                                    {
                                        nextSP.AppendChild<Run>(new Run(new Text(txt)));
                                    }
                                    else
                                    {
                                        var nextSR = Bs.NextSibling<Run>();
                                        if (nextSR != null)
                                        {
                                            nextSR.AppendChild<Text>(new Text(txt));
                                        }
                                        else
                                        {
                                            Bs.Parent.AppendChild<Paragraph>(new Paragraph(new Run(new Text(txt))));
                                        }
                                    }

                                }
                            }//Book != Bs.Name

                        }//Exit for each bookMark
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, txt);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }// exit foreach passed bookstring
                    foreach (string book in _ImageBookMarks.Keys)
                    {
                        Image img = _ImageBookMarks[book];
                        Dictionary<string, string> repted = new Dictionary<string, string>();
                        foreach (BookmarkStart Bs in wordDoc.MainDocumentPart.Document.Descendants<BookmarkStart>())
                        {
                            if (Bs.Name.Value == book)
                            {
                                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                                ImagePart imagePart;
                                string relationshipId;
                                if (!repted.ContainsKey(book))
                                {

                                    imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                                    string picFileName = "Pictest.tmp";
                                    if (File.Exists(picFileName))
                                        File.Delete(picFileName);
                                    Bitmap bitMap = (Bitmap)img;
                                    bitMap.Save(picFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    using (FileStream stream = new FileStream(picFileName, FileMode.Open))
                                    {
                                        imagePart.FeedData(stream);
                                    }
                                    relationshipId = mainPart.GetIdOfPart(imagePart);
                                    repted.Add(book, relationshipId);
                                }
                                else
                                {
                                    relationshipId = repted[book];
                                }
                                if (!_UseDefaultImageSize)
                                {
                                    _DefuaultImageSize = new Size(990000, 792000);

                                }
                                Random rnd = new Random();
                                uint Id = (uint)(rnd.Next(1000, 10000));
                                if (!_UsedIDs.Contains(Id) && !_UsedIDs.Contains(Id + 1333))
                                {
                                    _UsedIDs.Add(Id);
                                }
                                else
                                {
                                    while (_UsedIDs.Contains(Id) || _UsedIDs.Contains(Id + 1333))
                                    {
                                        Id = (uint)(rnd.Next(1000, 10000));
                                    }
                                    _UsedIDs.Add(Id);
                                }
                                _UsedIDs.Add(Id + 1333);
                                var element =
                                    new Drawing(
                                        new DW.Inline(
                                            new DW.Extent() { Cx = (long)_DefuaultImageSize.Width, Cy = (long)_DefuaultImageSize.Height },
                                                new DW.EffectExtent()
                                                {
                                                    LeftEdge = 0L,
                                                    TopEdge = 0L,
                                                    RightEdge = 0L,
                                                    BottomEdge = 0L
                                                },
                                                 new DW.DocProperties()
                                                 {
                                                     Id = (UInt32Value)(Id + 1333),
                                                     Name = Path.GetFileNameWithoutExtension(savedFile)
                                                 },
                                                new DW.NonVisualGraphicFrameDrawingProperties(
                                                new A.GraphicFrameLocks() { NoChangeAspect = true }),
                                                new A.Graphic(
                                                 new A.GraphicData(
                     new PIC.Picture(
                         new PIC.NonVisualPictureProperties(
                             new PIC.NonVisualDrawingProperties()
                             {
                                 Id = (UInt32Value)Id,
                                 Name = Path.GetFileName(savedFile)
                             },
                             new PIC.NonVisualPictureDrawingProperties()),
                         new PIC.BlipFill(
                             new A.Blip(
                                 new A.BlipExtensionList(
                                     new A.BlipExtension()
                                     {
                                         Uri =
                                           "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                     })
                             )
                             {
                                 Embed = relationshipId,
                                 CompressionState =
                                 A.BlipCompressionValues.Print
                             },
                             new A.Stretch(
                                 new A.FillRectangle())),
                         new PIC.ShapeProperties(
                             new A.Transform2D(
                                 new A.Offset() { X = 0L, Y = 0L },
                                 new A.Extents() { Cx = (long)_DefuaultImageSize.Width, Cy = (long)_DefuaultImageSize.Height }),
                             new A.PresetGeometry(
                                 new A.AdjustValueList()
                             ) { Preset = A.ShapeTypeValues.Rectangle }))
                 ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
         )
                                        {
                                            DistanceFromTop = (UInt32Value)0U,
                                            DistanceFromBottom = (UInt32Value)0U,
                                            DistanceFromLeft = (UInt32Value)0U,
                                            DistanceFromRight = (UInt32Value)0U
                                            //EditId = (Id+1).ToString()
                                        });

                                //AddImageToBody(wordDoc, mainPart.GetIdOfPart(imagePart));
                                Bs.NextSibling<BookmarkEnd>().Parent.AppendChild<Drawing>(element);
                            }
                        }
                    }
                    if (_UseCustomBoolean)
                    {
                        foreach (string book in _boolBookmarke.Keys)
                        {
                            foreach (BookmarkStart Bs in wordDoc.MainDocumentPart.Document.Descendants<BookmarkStart>())
                            {
                                if (Bs.Name == book)
                                {
                                    string sym = _boolBookmarke[book].ToString("X4");
                                    SymbolChar Symchar = new SymbolChar();
                                    Symchar.Font = _CustomBoolFontName;
                                    Symchar.Char = HexBinaryValue.FromString(sym);
                                    if (Bs.Parent is Paragraph)
                                    {
                                        Bs.Parent.AppendChild<Run>(new Run(Symchar));
                                    }
                                    else if (Bs.Parent is Run)
                                    {
                                        Bs.Parent.AppendChild<SymbolChar>(Symchar);
                                    }
                                    else
                                    {
                                        var nextSP = Bs.NextSibling<Paragraph>();
                                        if (nextSP != null)
                                        {
                                            nextSP.AppendChild<Run>(new Run(Symchar));
                                        }
                                        else
                                        {
                                            var nextSR = Bs.NextSibling<Run>();
                                            if (nextSR != null)
                                            {
                                                nextSR.AppendChild<SymbolChar>(Symchar);
                                            }
                                            else
                                            {
                                                Bs.Parent.AppendChild<Paragraph>(new Paragraph(new Run(Symchar)));
                                            }
                                        }

                                    }
                                }//Book != Bs.Name

                            }//Exit for each bookMark
                            i++;
                            prog = (i / All) * 100f;
                            if (StringProgress != null)
                                StringProgress((int)prog, book);
                            if (IntegerProgress != null)
                                IntegerProgress((int)prog);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (_throwExceptions)
                    throw ex;
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
                float prog = 0f;
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(savedFile, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }
                    foreach (string book in _StringBookMarks.Keys)
                    {
                        string txt = _StringBookMarks[book];
                        Regex regexText = new Regex(book);
                        docText = regexText.Replace(docText, txt);
                        i++;
                        prog = (i / All) * 100f;
                        if (StringProgress != null)
                            StringProgress((int)prog, txt);
                        if (IntegerProgress != null)
                            IntegerProgress((int)prog);
                    }
                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    foreach (string book in _ImageBookMarks.Keys)
                    {
                        Image img = _ImageBookMarks[book];
                        Dictionary<string, string> repted = new Dictionary<string, string>();
                        foreach (BookmarkStart Bs in wordDoc.MainDocumentPart.Document.Descendants<BookmarkStart>())
                        {
                            if (Bs.Name.Value == book)
                            {
                                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                                ImagePart imagePart;
                                string relationshipId;
                                if (!repted.ContainsKey(book))
                                {

                                    imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                                    string picFileName = "Pictest.tmp";
                                    if (File.Exists(picFileName))
                                        File.Delete(picFileName);
                                    Bitmap bitMap = (Bitmap)img;
                                    bitMap.Save(picFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    using (FileStream stream = new FileStream(picFileName, FileMode.Open))
                                    {
                                        imagePart.FeedData(stream);
                                    }
                                    relationshipId = mainPart.GetIdOfPart(imagePart);
                                    repted.Add(book, relationshipId);
                                }
                                else
                                {
                                    relationshipId = repted[book];
                                }
                                if (!_UseDefaultImageSize)
                                {
                                    _DefuaultImageSize = new Size(990000, 792000);

                                }
                                Random rnd = new Random();
                                uint Id = (uint)(rnd.Next(1000,10000));
                                if (!_UsedIDs.Contains(Id) && !_UsedIDs.Contains(Id+1333))
                                {
                                    _UsedIDs.Add(Id);
                                }
                                else
                                {
                                    while (_UsedIDs.Contains(Id)  || _UsedIDs.Contains(Id + 1333))
                                    {
                                        Id = (uint)(rnd.Next(1000, 10000));
                                    }
                                    _UsedIDs.Add(Id);
                                }
                                _UsedIDs.Add(Id + 1333);
                                var element =
                                    new Drawing(
                                        new DW.Inline(
                                            new DW.Extent() { Cx =  (long)_DefuaultImageSize.Width, Cy = (long)_DefuaultImageSize.Height  },
                                                new DW.EffectExtent()
                                                {
                                                    LeftEdge = 0L,
                                                    TopEdge = 0L,
                                                    RightEdge = 0L,
                                                    BottomEdge = 0L
                                                },
                                                 new DW.DocProperties()
                                                {
                                                    Id = (UInt32Value)(Id+1333),
                                                    Name = Path.GetFileNameWithoutExtension(savedFile)
                                                },
                                                new DW.NonVisualGraphicFrameDrawingProperties(
                                                new A.GraphicFrameLocks() { NoChangeAspect = true }),
                                                new A.Graphic(
                                                 new A.GraphicData(
                     new PIC.Picture(
                         new PIC.NonVisualPictureProperties(
                             new PIC.NonVisualDrawingProperties()
                             {
                                 Id = (UInt32Value)Id,
                                 Name = Path.GetFileName(savedFile)
                             },
                             new PIC.NonVisualPictureDrawingProperties()),
                         new PIC.BlipFill(
                             new A.Blip(
                                 new A.BlipExtensionList(
                                     new A.BlipExtension()
                                     {
                                         Uri =
                                           "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                     })
                             )
                             {
                                 Embed = relationshipId,
                                 CompressionState =
                                 A.BlipCompressionValues.Print
                             },
                             new A.Stretch(
                                 new A.FillRectangle())),
                         new PIC.ShapeProperties(
                             new A.Transform2D(
                                 new A.Offset() { X = 0L, Y = 0L },
                                 new A.Extents() { Cx = (long)_DefuaultImageSize.Width, Cy = (long)_DefuaultImageSize.Height }),
                             new A.PresetGeometry(
                                 new A.AdjustValueList()
                             ) { Preset = A.ShapeTypeValues.Rectangle }))
                 ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
         )
         {
             DistanceFromTop = (UInt32Value)0U,
             DistanceFromBottom = (UInt32Value)0U,
             DistanceFromLeft = (UInt32Value)0U,
             DistanceFromRight = (UInt32Value)0U
             //EditId = (Id+1).ToString()
         });
                                
                                //AddImageToBody(wordDoc, mainPart.GetIdOfPart(imagePart));
                                Bs.NextSibling<BookmarkEnd>().Parent.AppendChild<Drawing>(element );
                            }
                        }
                    }//exit ImageBook

                    if (_UseCustomBoolean)
                    {
                        foreach (string book in _boolBookmarke.Keys)
                        {
                            foreach (Text tx in wordDoc.MainDocumentPart.Document.Descendants<Text>())
                            {
                                if (tx.Text == book)
                                {
                                    string sym = _boolBookmarke[book].ToString("X4");
                                    SymbolChar Symchar = new SymbolChar();
                                    Symchar.Font = _CustomBoolFontName;
                                    Symchar.Char = HexBinaryValue.FromString(sym);

                                    if (tx.Parent is Paragraph)
                                    {
                                        tx.Parent.AppendChild<Run>(new Run(Symchar));
                                        tx.Remove();
                                    }
                                    else if (tx.Parent is Run)
                                    {
                                        tx.Parent.AppendChild<SymbolChar>(Symchar);
                                        tx.Remove();
                                    }
                                    else
                                    {
                                        var nextSP = tx.NextSibling<Paragraph>();
                                        if (nextSP != null)
                                        {
                                            nextSP.AppendChild<Run>(new Run(Symchar));
                                            tx.Remove();
                                        }
                                        else
                                        {
                                            var nextSR = tx.NextSibling<Run>();
                                            if (nextSR != null)
                                            {
                                                nextSR.AppendChild<SymbolChar>(Symchar);
                                                tx.Remove();
                                            }
                                            else
                                            {
                                                tx.Parent.AppendChild<Paragraph>(new Paragraph(new Run(Symchar)));
                                                tx.Remove();
                                            }
                                        }

                                    }
                                }//Book != Bs.Name

                            }//Exit for each bookMark
                            i++;
                            prog = (i / All) * 100f;
                            if (StringProgress != null)
                                StringProgress((int)prog, book);
                            if (IntegerProgress != null)
                                IntegerProgress((int)prog);
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                if (_throwExceptions)
                    throw ex;
            }

        }
    }
}
