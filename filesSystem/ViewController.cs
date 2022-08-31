using Foundation;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UIKit;

namespace filesSystem
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            FileButton.TouchUpInside += FileButton_TouchUpInside;
            readButton.TouchUpInside += ReadButton_TouchUpInside;
            createButton.TouchUpInside += CreateButton_TouchUpInside;
            logLoopButton.TouchUpInside += LogLoopButton_TouchUpInside;
        }


        private void FileButton_TouchUpInside(object sender, EventArgs e)
        {
            var entries = Directory.EnumerateFiles("./");//EnumerateDirectories("./");
            foreach(var item in entries)
            {
                Console.WriteLine(item);
            }
        }

        private void ReadButton_TouchUpInside(object sender, EventArgs e) {

            var text = File.ReadAllText("story.txt");
            Console.WriteLine(text);

            var text2 = File.ReadAllLines("story.txt");
            foreach (var line in text2)
            {
                Console.WriteLine("####### "+line);
            }

        }

        private void CreateButton_TouchUpInside(object sender, EventArgs e)
        {

            //create file
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//LocalApplicationData);
            var fileName = Path.Combine(documents, "newstory.txt");
            File.WriteAllText(fileName," this is the new story file ! ");
            Console.WriteLine(" file created succesfully in Library/Documents");

            //create Directory
            var directoryName = Path.Combine(documents, "Stories");
            Directory.CreateDirectory(directoryName);
            Console.WriteLine(" directory created succesfully in Library/Documents");

        }

        //non-blocking loop that runs every secound for 5 seconds
        //inside of loop print current datetime to a long file log.txt -> Documents
        private void LogLoopButton_TouchUpInside(object sender, EventArgs e)
        {
            Task.Factory.StartNew(()=>{
                var filePath = Path.Combine(Environment.
                    GetFolderPath(Environment.SpecialFolder.MyDocuments),"log.txt");
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                for( var i= 0; i<5; i++)
                {
                    var time = DateTime.Now.ToShortTimeString();
                    File.AppendAllText(filePath,time+ "\n") ;
                    Thread.Sleep(1000);
                }

                Console.WriteLine(File.ReadAllText(filePath));

            });

        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
