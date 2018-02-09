/*
    @author:        Mick Torres
    @course:        CST-227
    @assignment:    Milestone 7
    @date:          December 5th 2017
    @note:          This is my own work. However Kaleb and I have
                    worked on this project together throughout
                    the entire semester.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Milestone6
{
    /*
        This is the FormProvider class.
        Basically it is here so "we don't make a crap ton of forms for no reason" - kaleb
        So only one form will show at a time.
        thanks kaleb.
    */
    public class FormProvider
    {
        public static MainMenu TheMainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new MainMenu();
                }
                return _mainMenu;
            }
        }
        public static MainMenu _mainMenu;
    }
}
