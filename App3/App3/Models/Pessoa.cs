using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App3
{
    public class Pessoa : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        private string _name;

        public string Nome {

            get { return _name; }

            set { if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
                        }
                
                }

        private void OnPropertyChanged ([CallerMemberName]string propertyName = null)
        {
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double _peso;
        public double Peso {

            get { return _peso; }


            set { if (_peso == value)
                    return;

                _peso = value;

                OnPropertyChanged();
            }

        }

        private int _idade;
        public int Idade
        {
            get { return _idade; }


            set
            {
                if (_idade == value)
                    return;

                _idade = value;

                OnPropertyChanged();
            }
        }

    }
   
}
