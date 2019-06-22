﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.Doc.Models.Doc
{
    public class DocVM
    {
        public HelpMenu HelpMenu { get; set; }
        public IEnumerable<HelpMenu> HelpMenus { get; set; }
        public IEnumerable<HelpDoc> HelpDocs { get; set; }
    }
}