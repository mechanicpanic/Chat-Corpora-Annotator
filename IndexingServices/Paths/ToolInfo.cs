﻿using System;

namespace IndexEngine.Paths
{
    public static class ToolInfo
    {
        public static string SRparserpath { get; private set; }
        public static string NERpath { get; private set; }
        public static string POSpath { get; private set; }

        public static string sutimeRules { get; private set; }
        public static string root { get; private set; }

        public static string TagsetIndexPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCA\tagsets.txt";
        public static string TagsetColorIndexPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\CCA\tagsetscolors.txt";

        public static void SetModelPaths()
        {
            root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\CCA" + "\\Models";
            POSpath = root + "\\POS" + @"\gate-EN-twitter.model";
            NERpath = root + "\\NER" + @"\english.muc.7class.caseless.distsim.crf.ser.gz";
            SRparserpath = root + "\\Parser" + @"\englishSR.ser.gz";
            sutimeRules = root + @"\sutime\defs.sutime.txt,"
                              + root + @"\sutime\english.holidays.sutime.txt,"
                              + root + @"\sutime\english.sutime.txt";
        }

        static ToolInfo()
        {
            SetModelPaths();
        }
    }
}
