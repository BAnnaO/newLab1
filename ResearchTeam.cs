using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab1
{
    class ResearchTeam
    {
        private string _InvestigationTheme;
        public string Theme
        { get { return _InvestigationTheme; }
            set { _InvestigationTheme=value; }
        }
        private string _Organisation;
        public string Organisation {
            get { return _Organisation; }
            set { _Organisation = value; }
        }
        private int _RegistrationNumber;
        public int RegistrNumber {
            get { return _RegistrationNumber; }
            set { _RegistrationNumber = value; }
        }  
        private TimeFrame _InvestigationDuration;
        public TimeFrame TimeDuration {
            get { return _InvestigationDuration; }
            set { _InvestigationDuration = value; }
        }
        private Paper[] _SetOfPublication;
        public Paper[]  getPaper{
            get { return _SetOfPublication; }
            set { _SetOfPublication = value; }
        }
        public ResearchTeam(string InvestigationTheme, string Organisation, int RegistrationNumber, TimeFrame InvestigationDuration) {
            _InvestigationDuration = InvestigationDuration;
            _InvestigationTheme = InvestigationTheme;
            _RegistrationNumber = RegistrationNumber;
            _Organisation = Organisation;
        }
        public ResearchTeam():this("Chaos","IRE",13,TimeFrame.Year) {}
        public Paper LastPaper {
            get
            {
                if (_SetOfPublication != null)
                {
                    DateTime Maxdate = _SetOfPublication[0]._TimeOfPublication;
                    int MaxdateIndex = 0;
                    for (int i = 0; i < _SetOfPublication.Length; i++)
                    {
                        if (_SetOfPublication[i]._TimeOfPublication > Maxdate)
                        {
                            MaxdateIndex = i;
                        }
                    }
                    return _SetOfPublication[MaxdateIndex];
                }
                else { return null; }
            }
        }
        public bool this[TimeFrame SomeTimeFrame] {
            get {
                if (SomeTimeFrame == _InvestigationDuration)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public void AddPapers(params Paper[] Somepaper) {
            if (_SetOfPublication == null)
            {
                _SetOfPublication =  Somepaper ;
            }
            else {
                Paper[] newArr = new Paper[_SetOfPublication.Length + Somepaper.Length];
                Array.Copy(_SetOfPublication,newArr,_SetOfPublication.Length);
                Array.Copy(Somepaper, 0, newArr, _SetOfPublication.Length, Somepaper.Length);
                _SetOfPublication = newArr;

            }
            
        }
        public override string ToString()
        {
            string PublicationString = "";
            foreach (Paper sp in _SetOfPublication) {
                PublicationString += sp.ToString()+"\n";
            }
            return string.Format(_InvestigationTheme,"\n",_Organisation,
                " ",_InvestigationDuration.ToString(),"\n",_RegistrationNumber.ToString(),"\n",
                _InvestigationDuration.ToString()+"\n"+PublicationString);
        }
        public string ToShortString() {
            return string.Format(_InvestigationTheme, "\n", _Organisation,
                " ", _InvestigationDuration.ToString(), "\n", _RegistrationNumber.ToString(), "\n",
                _InvestigationDuration.ToString() + "\n");
        }
    }
}
