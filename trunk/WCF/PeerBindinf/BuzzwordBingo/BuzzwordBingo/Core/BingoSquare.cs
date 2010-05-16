using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BuzzwordBingo.Core
{


    public class BingoSquare : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public event EventHandler<SquareCheckedEventArgs> CheckChanged;

        private string _buzzword = string.Empty;
        public string Buzzword {
            get { return _buzzword; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Cannot set Buzzword to empty or null.");

                if (_buzzword == value)
                    return;
                _buzzword = value;
                OnPropertyChanged("Buzzword");
            }
        }

        private int _position = -1;
        public int Position {
            get { return _position; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentException("Cannot set position to less than zero or greater than max squares (24).");

                _position = value;
            }           
        }

        public BingoSquare(string buzzword, int position)
        {
            this.Buzzword = buzzword;
            this.Position = position;
        }

        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get { 
                if (this.IsConfirmed) 
                    return null;

                return _isChecked; }
            set {
                if (_isChecked == value)
                    return;

                if (!value.HasValue)
                {
                    OnPropertyChanged("IsChecked");
                    return;
                }

                _isChecked = value;
                OnPropertyChanged("IsChecked");
                OnCheckChanged();
                
            }
        }

        private bool _isConfirmed = false;
        public bool IsConfirmed
        {
            get { return _isConfirmed; }
            set
            {
                if (value == _isConfirmed)
                    return;

                _isConfirmed = value;
                OnPropertyChanged("IsConfirmed");
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsChecked");
            }
        }

        public bool IsEnabled
        {
            get { return !_isConfirmed; }
        }

        private void OnCheckChanged()
        {
            EventHandler<SquareCheckedEventArgs> handler = this.CheckChanged;
            if (handler != null)
                CheckChanged(this, new SquareCheckedEventArgs(this, this.IsChecked));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.Buzzword;
        }
    }
}
