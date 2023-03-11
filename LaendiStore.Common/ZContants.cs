using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Common
{
    public class ZContants
    {
        /// <summary>
        /// Special string
        /// </summary>
        public class SpecialString
        {
            public const string Slash = "/";

            public const string BackSlash = @"\";

            public const string Space = " ";

            public const string Semicolon = ";";

            public const string Comma = ",";

            public const string Question = "?";

            public const string Asterisk = "*";

            public const string Caret = "^";

            public const string Plus = "+";

            public const string Blank = "";

            public const string Minus = "-";

            public const string Dot = ".";

            public const string Colon = ":";

            public const string Quotation = "\"";

            public const string LeftSquare = "[";

            public const string RightSquare = "]";

            public const string Underscore = "_";

            public const string VBar = "|";

            public const string Ampersand = "&";

            public const string Percent = "%";

            public const string AtSign = "@";

            /// <summary>
            /// +-
            /// </summary>
            public const string PlusMinus = Plus + Minus;

            /// <summary>
            /// ++-
            /// </summary>
            public const string PlusDoubleMinus = PlusMinus + Minus;

            /// <summary>
            /// --
            /// </summary>
            public const string DoubleMinus = Minus + Minus;

            /// <summary>
            /// ", "
            /// </summary>
            public const string CommaSpace = Comma + Space;

            /// <summary>
            /// " - "
            /// </summary>
            public const string SpaceMinusSpace = Space + Minus + Space;

            /// <summary>
            /// //
            /// </summary>
            public const string DouleSlash = Slash + Slash;

            /// <summary>
            /// \\
            /// </summary>
            public const string DouleBackSlash = BackSlash + BackSlash;

            /// <summary>
            /// \r\n
            /// </summary>
            public const string CarriageReturn = "\r\n";

            /// <summary>
            /// \n
            /// </summary>
            public const string NewLine = "\n";

            /// <summary>
            /// <br />
            /// </summary>
            public const string BrTag = "<br />";

            /// <summary>
            ///</ br>
            /// </summary>
            public const string BrTag2 = "</ br>";

            /// <summary>
            /// Vietnamese dong
            /// </summary>
            public const string VND = "₫";

            /// <summary>
            /// United States dollar 
            /// </summary>
            public const string USD = "$";
        }
    }
}
