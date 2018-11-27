using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTickets.Models
{
    class Seat : INotifyPropertyChanged, ICloneable
    {
        private int rowNum;

        public int RowNum
        {
            get { return rowNum; }
            set { rowNum = value; OnPropertyChanged("RowNum"); }
        }

        private String columnNum;

        public String ColumnNum
        {
            get { return columnNum; }
            set { columnNum = value; OnPropertyChanged("ColumnNum"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String name)
        {
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public object Clone()
        {
            Seat newSeat = new Seat
            {
                RowNum = this.RowNum,
                ColumnNum = this.ColumnNum
            };
            return newSeat;
        }

        public override string ToString()
        {
            return $"Row number: {RowNum} Column number: {ColumnNum}";
        }

    }
}
