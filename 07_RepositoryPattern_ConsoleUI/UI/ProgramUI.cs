using _07_RepositoryPattern_Repository;
using _07_RepositoryPattern_Repository.ContentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_ConsoleUI.UI
{
    class ProgramUI
    {
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option number:\n" +
                    "1. Display all streaming content\n" +
                    "2. Display all Shows\n" +
                    "3. Display all Movies\n" +
                    "4. Add streaming content\n" +
                    "5. Update existing content\n" +
                    "6. Remove streaming content\n" +
                    "7. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        //-- Show All Content
                        ShowAllContent();
                        break;
                    case "2":
                        //-- Display All Shows
                        break;
                    case "3":
                        //-- Display All Movies
                        break;
                    case "4":
                        //-- Add New Content
                        break;
                    case "5":
                        //-- Update Content
                        break;
                    case "6":
                        //-- Delete Content
                        break;
                    case "7":
                        //-- Exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowAllContent()
        {
            Console.Clear();

            // Get all of our content
            List<StreamingContent> directory = _streamingRepo.GetAllContents();

            // Go through each item and display its properties
            foreach(StreamingContent content in directory)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $"Description: {content.Description}\n" +
                    $"Genre: {content.Genre}\n" +
                    $"Rating: {content.MaturityRating}\n" +
                    $"Is Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Stars: {content.StarRating}\n" +
                    $"Streaming Quality: {content.TypeOfStreamingQuality}\n" +
                    $"Language: {content.Language}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            StreamingContent toyStory = new StreamingContent("Bromance", "Toy Story", 10, StreamingQualityType.HD720, "A good childhood movie.", "English", MaturityRating.G);
            _streamingRepo.AddContentToDirectory(toyStory);

            Movie rubber = new Movie("Drama", "Rubber", 6, StreamingQualityType.HD1080, "Tyre comes to life and kills people with its mind powers.", "English/French", MaturityRating.R, 85);
            _streamingRepo.AddContentToDirectory(rubber);

            Show avatar = new Show("Adventure", "Avatar", 9, StreamingQualityType.HD1080, "The last airbender", "English", MaturityRating.G, new List<Episode>());
            _streamingRepo.AddContentToDirectory(avatar);
        }
    }
}
