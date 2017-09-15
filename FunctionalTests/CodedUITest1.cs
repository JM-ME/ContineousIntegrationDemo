using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;


namespace CodedUI_saurabh
{
    [CodedUITest]
    public class CodedUITest1
    {
        StringBuilder sb = new StringBuilder();
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {

            Process proc1 = new Process();
            proc1.StartInfo.FileName = "D:\\Technology\\Target\\ExecuteHelloWorld.exe";
            proc1.Start();   

            //Instance for WinWindow
            UITestControl FormWindow = new UITestControl();
            FormWindow.TechnologyName = "MSAA";
            FormWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Form1";
            
            //Click on Welcome Button
            UITestControl WelcomeButton = new WinButton(FormWindow);
            WelcomeButton.SearchProperties[UITestControl.PropertyNames.Name] = "Welcome";
            Mouse.Click(WelcomeButton);           

            //Get Text from Textbox for Validation
            WinEdit Textbox = new WinEdit(FormWindow);
            Textbox.SearchProperties[WinEdit.PropertyNames.ControlType] = "Edit";
            string text = Textbox.Text;
            if (text == "Hello Jitendra")
            {
                sb.AppendLine("Validation Passed!");
            }
            else
            {
                sb.AppendLine("Validation Failed!");
                Assert.Fail();
            }
            Playback.Wait(5000);
       
        }

        [TestCleanup]
        public void Logging()
        {
            File.WriteAllText("D:\\Technology\\Target" + "\\" + TestContext.TestName + ".txt", sb.ToString());
        }
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
