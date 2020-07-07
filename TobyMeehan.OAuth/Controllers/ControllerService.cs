using System;
using System.Collections.Generic;
using System.Text;

namespace TobyMeehan.OAuth.Controllers
{
    public class ControllerService
    {
        public IAccountController Accounts { get; set; }
        public IApplicationController Applications { get; set; }
        public IDownloadController Downloads { get; set; }
        public IScoreboardController Scoreboard { get; set; }
        public ITokenController Token { get; set; }
        public ITransactionController Transactions { get; set; }
    }
}
