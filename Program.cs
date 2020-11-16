using System;
using AutomationLinkedLists;

// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung

class Program
{

    // MODIFY: ONLY MODIFY THESE VALUES TO RUN THE TEST
    public const uint CONST_MINRANGE = 0;
    public const uint CONST_MAXRANGE = 100;
    public const uint CONST_LENGTH = 10000;

    static void Main(string[] args)
    {
        AutomationLinkedLists.AutomationLinkedLists automationTest = new AutomationLinkedLists.AutomationLinkedLists();

        automationTest.RunTests(CONST_MINRANGE, CONST_MAXRANGE, CONST_LENGTH);
    }
}
