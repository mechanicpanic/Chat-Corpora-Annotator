using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine
{
    public static class NLPModel
    {
        public static string _SRparserpath { get; private set; }
        public static string _NERpath { get; private set; }
        public static string _POSpath { get; private set; }

        public static string _sutimeRules { get; private set; }
        public static string _root { get; private set; }

        static NLPModel()
        {
            _root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\CCA" + "\\Models";
            _POSpath = _root + "\\POS" + @"\gate-EN-twitter.model";
            _NERpath = _root + "\\NER" + @"\english.muc.7class.caseless.distsim.crf.ser.gz";
            _SRparserpath = _root + "\\Parser" + @"\englishSR.ser.gz";
            _sutimeRules = _root + @"\sutime\defs.sutime.txt,"
                              + _root + @"\sutime\english.holidays.sutime.txt,"
                              + _root + @"\sutime\english.sutime.txt";

        }
    }
}
