using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WPFFirstTask.Model
{
   public class Person : INotifyPropertyChanged
    {
        
        private string fName;
        private string lName;
        private string mName;
        private string dob;
        private string gender;
        public string FName
        {
            get { return fName; }
            set { fName = value; }//OnPropertyChanged(FName); }
        }
        
        public string LName
        {
            get { return lName; }
            set { lName = value; }//OnPropertyChanged(LName); }
        }
        public string MName
        {
            get { return mName; }
            set { mName = value; }// OnPropertyChanged(MName); }
        }
        public string DOB
        {
            get { return dob; }
            set { dob = value; }// OnPropertyChanged(DOB); }
            
        }
       
        public string Gender
        {
            get { return gender; }
            set { gender = value; } // OnPropertyChanged(Gender); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
                ph(this, new PropertyChangedEventArgs(p));
        }

    }
    
}

 