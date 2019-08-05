using System;
using System.IO;
using AgcApp;
using Xunit;

namespace XUnitTestAgcApp
{
    public class UnitTest1
    {
        private string filepathsrc = @"C:\Source\Repos\ConsoleAppRegister\XUnitTestAgcApp\bin\Debug\netcoreapp2.2\Test.src";
        private string filepathasm = @"C:\Source\Repos\ConsoleAppRegister\XUnitTestAgcApp\bin\Debug\netcoreapp2.2\Test.b32";
         private string filepathsrccmpx = @"C:\Source\Repos\ConsoleAppRegister\XUnitTestAgcApp\bin\Debug\netcoreapp2.2\TestComplex.src";
        private string filepathasmcmpx = @"C:\Source\Repos\ConsoleAppRegister\XUnitTestAgcApp\bin\Debug\netcoreapp2.2\TestComplex.b32";

        [Fact]
        public void SourceFileExists()
        {
            Assert.True(File.Exists(filepathsrc));
        }

        [Fact]
        public void SourceAssemble()
        {
            var assy = new Assembler();
            assy.AssembleFromFile(filepathsrc);
        }
        [Fact]
        public void LoadAssembled()
        {
            var mach = new Machine();
            mach.LoadProgramFromFile(filepathasm);
        }
    }
}
