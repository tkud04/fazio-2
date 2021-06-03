using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ass_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ass_2.Helpers
{
    public interface IHelper
    {
	   string readExcelFile(string filename);
    }
}