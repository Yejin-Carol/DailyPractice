using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.util
{
    class CourseTable
    {
        public const int ENGLISH_ONEBYONE = 0;
        public const int ENGLISH_LESSTHANFIVE = 1;
        public const int ENGLISH_LESSTHANTEN = 2;
        public const int SPANISH_ONEBYONE = 3;
        public const int SPANISH_LESSTHANFIVE = 4;
        public const int SPANISH_LESSTHANTEN = 5;

        public static int[] fixPrice =
        {
            500000, 400000, 300000, 
            600000, 500000, 400000
        };
    }

}
