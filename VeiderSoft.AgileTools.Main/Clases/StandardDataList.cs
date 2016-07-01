using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Orion.Client.Core.Model
{
    public class StandardDataList : SimpleViewModel
    {
        #region Members
        private int id;
        private int id2;
        private int id3;
        private int idParent;
        private bool isChecked;
        private bool isChecked2;
        private bool isChecked3;
        private bool isChecked4;
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;
        private string text7;
        private string text8;
        private string text9;
        private string text10;
        private DateTime? date1;
        private DateTime? date2;
        private DateTime date3;
        private Guid key;
        private Guid key2;
        private Guid key3;
        private Guid keyParent;
        private int value1;
        private int value2;
        private decimal decimal1;
        private decimal decimal2;
        private decimal decimal3;
        private decimal decimal4;
        private Brush brush1;
        private Brush brush2;
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                if (id == value) return;
                id = value;
                NotifyChanged("Id");
            }
        }
        public int Id2
        {
            get { return id2; }
            set
            {
                if (id2 == value) return;
                id2 = value;
                NotifyChanged("Id2");
            }
        }
        public int Id3
        {
            get { return id3; }
            set
            {
                if (id3 == value) return;
                id3 = value;
                NotifyChanged("Id3");
            }
        }
        public int IdParent
        {
            get { return idParent; }
            set
            {
                if (idParent == value) return;
                idParent = value;
                NotifyChanged("IdParent");
            }
        }
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                NotifyChanged("IsChecked");

                if (OnItemChecked != null)
                    OnItemChecked.Invoke();

                if (Locked == false && OnIsCheckedChanged != null)
                    OnIsCheckedChanged.Invoke(this);
            }
        }
        public bool IsChecked2
        {
            get { return isChecked2; }
            set
            {
                if (isChecked2 == value) return;
                isChecked2 = value;
                NotifyChanged("IsChecked2");

                if (OnItemChecked != null)
                    OnItemChecked.Invoke();
            }
        }
        public bool IsChecked3
        {
            get { return isChecked3; }
            set
            {
                if (isChecked3 == value) return;
                isChecked3 = value;
                NotifyChanged("IsChecked3");

                if (OnItemChecked != null)
                    OnItemChecked.Invoke();
            }
        }
        public bool IsChecked4
        {
            get { return isChecked4; }
            set
            {
                if (isChecked4 == value) return;
                isChecked4 = value;
                NotifyChanged("IsChecked4");

                if (OnItemChecked != null)
                    OnItemChecked.Invoke();
            }
        }
        public string Text1
        {
            get { return text1; }
            set
            {
                if (text1 == value) return;
                text1 = value;
                NotifyChanged("Text1");
            }
        }
        public string Text2
        {
            get { return text2; }
            set
            {
                if (text2 == value) return;
                text2 = value;
                NotifyChanged("Text2");
            }
        }
        public string Text3
        {
            get { return text3; }
            set
            {
                if (text3 == value) return;
                text3 = value;
                NotifyChanged("Text3");
            }
        }
        public string Text4
        {
            get { return text4; }
            set
            {
                if (text4 == value) return;
                text4 = value;
                NotifyChanged("Text4");
            }
        }
        public string Text5
        {
            get { return text5; }
            set
            {
                if (text5 == value) return;
                text5 = value;
                NotifyChanged("Text5");
            }
        }
        public string Text6
        {
            get
            {
                return text6;
            }
            set
            {
                if (text6 == value) return;
                text6 = value;
                NotifyChanged("Text6");
            }
        }
        public string Text7
        {
            get
            {
                return text7;

            }
            set
            {
                if (text7 == value) return;
                text7 = value;
                NotifyChanged("Text7");
            }
        }
        public string Text8
        {
            get
            {
                return text8;

            }
            set
            {
                if (text8 == value) return;
                text8 = value;
                NotifyChanged("Text8");
            }
        }
        public string Text9
        {
            get
            {
                return text9;

            }
            set
            {
                if (text9 == value) return;
                text9 = value;
                NotifyChanged("Text9");
            }
        }
        public string Text10
        {
            get
            {
                return text10;

            }
            set
            {
                if (text10 == value) return;
                text10 = value;
                NotifyChanged("Text10");
            }
        }
        public Guid Key
        {
            get { return key; }
            set
            {
                if (key == value) return;
                key = value;
                NotifyChanged("Key");
            }
        }
        public Guid Key2
        {
            get { return key2; }
            set
            {
                if (key2 == value) return;
                key2 = value;
                NotifyChanged("Key2");
            }
        }
        public Guid Key3
        {
            get { return key3; }
            set
            {
                if (key3 == value) return;
                key3 = value;
                NotifyChanged("Key3");
            }
        }
        public Guid KeyParent
        {
            get { return keyParent; }
            set
            {
                if (keyParent == value) return;
                keyParent = value;
                NotifyChanged("KeyParent");
            }
        }
        public int Value1
        {
            get { return value1; }
            set
            {
                if (value1 == value) return;
                value1 = value;
                NotifyChanged("Value1");
            }
        }
        public int Value2
        {
            get { return value2; }
            set
            {
                if (value2 == value) return;
                value2 = value;
                NotifyChanged("Value2");
            }
        }
        public decimal Decimal1
        {
            get { return decimal1; }
            set
            {
                if (decimal1 == value) return;
                decimal1 = value;
                NotifyChanged("Decimal1");
            }
        }
        public decimal Decimal2
        {
            get
            {
                return decimal2;
            }
            set
            {
                if (decimal2 == value) return;
                decimal2 = value;
                NotifyChanged("Decimal2");
            }
        }
        public decimal Decimal3
        {
            get
            {
                return decimal3;
            }
            set
            {
                if (decimal3 == value) return;
                decimal3 = value;
                NotifyChanged("Decimal3");
            }
        }
        public decimal Decimal4
        {
            get
            {
                return decimal4;
            }
            set
            {
                if (decimal4 == value) return;
                decimal4 = value;
                NotifyChanged("Decimal4");
            }
        }
        public DateTime? Date1
        {
            get
            {
                return date1;
            }
            set
            {
                if (date1 == value) return;
                date1 = value;
                NotifyChanged("Date1");
            }
        }
        public DateTime? Date2
        {
            get
            {
                return date2;
            }
            set
            {
                if (date2 == value) return;
                date2 = value;
                NotifyChanged("Date2");
            }
        }
        public DateTime Date3
        {
            get
            {
                return date3;
            }
            set
            {
                if (date3 == value) return;
                date3 = value;
                NotifyChanged("Date3");
            }
        }
        public Brush Brush1
        {
            get
            {
                return brush1;
            }
            set
            {
                if (brush1 == value) return;
                brush1 = value;
                NotifyChanged("Brush1");
            }
        }
        public Brush Brush2
        {
            get
            {
                return brush2;
            }
            set
            {
                if (brush2 == value) return;
                brush2 = value;
                NotifyChanged("Brush2");
            }
        }
        public bool Locked { get; set; }
        #endregion

        #region Action
        public static Action OnItemChecked;
        public Action<StandardDataList> OnIsCheckedChanged;
        #endregion

        #region Ctor
        public StandardDataList()
        {
            Id = int.MinValue;
            Id2 = int.MinValue;
            Id3 = int.MinValue;
            IdParent = int.MinValue;
            Key = Guid.Empty;
            Key2 = Guid.Empty;
            Key3 = Guid.Empty;
            KeyParent = Guid.Empty;
            Text1 = string.Empty;
            Text2 = string.Empty;
            Text3 = string.Empty;
            Text4 = string.Empty;
            Text5 = string.Empty;
            Text6 = string.Empty;
            Text7 = string.Empty;
            Text8 = string.Empty;
            Text9 = string.Empty;
            Text10 = string.Empty;
            IsChecked = false;
            IsChecked2 = false;
            IsChecked3 = false;
            IsChecked4 = false;
            Value1 = int.MinValue;
            Value2 = int.MinValue;
            Decimal1 = decimal.Zero;
            Decimal2 = decimal.Zero;
            Decimal3 = decimal.Zero;
            Decimal4 = decimal.Zero;
        }
        #endregion

        #region StaticMethods
        public static StandardDataList Create(int id, string text1, int idParent = 0, string text2 = "", string text3 = "", Guid keyParent = new Guid(), int id2 = 0)
        {
            return new StandardDataList()
            {
                Id = id,
                Id2 = id2,
                Text1 = text1,
                Text2 = text2,
                Text3 = text3,
                IdParent = idParent,
                KeyParent = keyParent
            };
        }
        public static StandardDataList Create(Guid id, string text1, int idParent = 0, int idInt = 0, bool isChecked = false)
        {
            return new StandardDataList()
            {
                Id = idInt,
                Key = id,
                Text1 = text1,
                IdParent = idParent,
                IsChecked = isChecked
            };
        }

        public static StandardDataList Create(Guid id, int idInt, string text1)
        {
            return new StandardDataList()
            {
                Id = idInt,
                Key = id,
                Text1 = text1,
            };

        }
        public static StandardDataList Default()
        {
            return new StandardDataList()
            {
                Id = 0,
                Key = Guid.Empty,
                Text1 = "<Seleccionar>",
                IdParent = 0,
                KeyParent = Guid.Empty
            };
        }
        public static List<StandardDataList> EstatusCatalogo()
        {
            return new List<StandardDataList>()
            {
                new StandardDataList()
                {
                    Id = 0,
                    Text1 = "<Seleccionar>",
                    idParent = 0
                },
                new StandardDataList()
                {
                    Id = 3,
                    Text1 = "Activo",
                    idParent = 0
                },
                new StandardDataList()
                {
                    Id = 4,
                    Text1 = "Inactivo",
                    idParent = 0
                }
            };
        }
        public int? GetSelectedId()
        {
            if (this.Id == 0)
                return null;
            else
                return this.Id;
        }
        #endregion
    }
}
