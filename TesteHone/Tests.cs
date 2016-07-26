using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TesteHone
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void NewTest()
        {
            app.Tap(x => x.Text("Login"));
            app.Tap(x => x.Id("up"));
            app.Tap(x => x.Text("Cadastro de Pedidos"));
            app.Tap(x => x.Class("EditText"));
            app.Tap(x => x.Class("NumberPicker"));
            app.Tap(x => x.Id("button1"));
            app.EnterText(x => x.Class("EditText"), "P");
            app.Tap(x => x.Marked("Próximo"));
            app.Tap(x => x.Class("EditText"));
            app.Tap(x => x.Class("NumberPicker"));
            app.EnterText(x => x.Id("numberpicker_input"), "2");
            app.Tap(x => x.Id("button1"));
            app.EnterText(x => x.Class("EditText"), " ");
            app.Tap(x => x.Text("0"));
            app.ClearText(x => x.Class("EntryEditText").Text("02"));
            app.EnterText(x => x.Class("EntryEditText").Text("02"), "00");
            app.Tap(x => x.Text("0"));
            app.ClearText(x => x.Class("EntryEditText").Text("01"));
            app.EnterText(x => x.Class("EntryEditText").Text("01"), "000");
            app.Tap(x => x.Text("Add"));
            app.Tap(x => x.Marked("Próximo"));
            app.Tap(x => x.Class("EditText"));
            app.Tap(x => x.Id("button1"));
            app.EnterText(x => x.Class("EditText"), "F");
            app.Tap(x => x.Class("EditText").Index(3));
            app.Tap(x => x.Id("button1"));
            app.EnterText(x => x.Class("EditText").Index(3), "A");
            app.Tap(x => x.Marked("Próximo"));
            app.Tap(x => x.Marked("Salvar"));
        }
    }
}

