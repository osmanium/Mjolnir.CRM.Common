using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.SDK.Optionsets
{

    //Webpage(HTML) - .htm, .html - 1
    //Style Sheet(CSS) - .css - 2
    //Script(JScript) - .js - 3
    //Data(XML)- .xml - 4
    //Image(PNG) - .png - 5
    //Image(JPG) - .jpg - 6
    //Image(GIF) - .gif - 7
    //Silverlight(XAP) - .xap - 8
    //StyleSheet(XSL) - .xsl, .xslt - 9
    //Image(ICO) - .ico - 10


    public enum WebResourceType
    {
        All = 0,
        Html = 1,
        CSS = 2,
        JScript = 3,
        Xml = 4,
        Png = 5,
        Jpg = 6,
        Gif = 7,
        Xap = 8,
        Xsl = 9,
        Ico = 10
    }
}
