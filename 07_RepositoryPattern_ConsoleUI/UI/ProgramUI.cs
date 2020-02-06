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
                        ShowAllShows();
                        break;
                    case "3":
                        //-- Display All Movies
                        break;
                    case "4":
                        //-- Add New Content
                        AddNewStreamingContent();
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
        //Access to streaming repo/the add method 
        //Prompt the user 
        //Take in content 
        //Actually add the content through our add method 
        private void AddNewStreamingContent()
        {
            StreamingContent content = new StreamingContent();
            Console.WriteLine("Hello there, please enter a title");
            content.Title = Console.ReadLine();

            Console.WriteLine("Now, add a description");
            content.Description = Console.ReadLine();

            Console.WriteLine("What is the genre");
            content.Genre = Console.ReadLine();

            Console.WriteLine("What is the star rating?");
            content.StarRating = Convert.ToInt32(Console.ReadLine());
            //content.StarRating = int.Parse(Console.ReadLine());

            Console.WriteLine("Select a Maturity rating (enter a value between 1 and 5)\n" +
                "1) G \n" +
                "2) PG \n" +
                "3) PG 13 \n" +
                "4) R \n" +
                "5) NC 17");

            string maturityString = Console.ReadLine();
            int ratingID = int.Parse(maturityString);
            content.MaturityRating = (MaturityRating)ratingID;

            Console.WriteLine("Select a streaming Quality from below (choose a value between 1 and 5 \n" +
                "1) SD240 \n" +
                "2) SD480 \n" +
                "3) HD720 \n" +
                "4) HD1080 \n" +
                "5) UHD4k");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    content.TypeOfStreamingQuality = StreamingQualityType.SD240;
                    break;
                case "2":
                    content.TypeOfStreamingQuality = StreamingQualityType.SD480;
                    break;
                case "3":
                    content.TypeOfStreamingQuality = StreamingQualityType.HD720;
                    break;
                case "4":
                    content.TypeOfStreamingQuality = StreamingQualityType.HD1080;
                    break;
                case "5":
                    content.TypeOfStreamingQuality = StreamingQualityType.UHD4K;
                    break;
            }
            Console.WriteLine("Last step! What language is this content");
            content.Language = Console.ReadLine();
            _streamingRepo.AddContentToDirectory(content);
            Console.WriteLine("Your content has been added! Press any key to return to the main menu");
            Console.ReadKey();

        }

        //Display all shows
        //make a list -> 
        //add to the list (shows)
        //Display the shows 
        private void ShowAllShows()
        {
            List<Show> shows = new List<Show>();
            shows = _streamingRepo.GetAllShows();
            foreach (Show content in shows)
            {
                Console.WriteLine($"Title: {content.Title} \n" +
                    $"Genre: {content.Genre} \n" +
                    $"Star Rating: {content.StarRating} \n" +
                    $"What is it about?{content.Description} \n" +
                    $"Words: {content.Language} \n" +
                    $"Streaming Quality: {content.TypeOfStreamingQuality} \n" +
                    $"Maturity Rating {content.MaturityRating} \n" +
                    $"Is family friendly: {content.IsFamilyFriendly} \n" +
                    $"Runtime: {content.AverageRunTime} \n" +
                    $"Episode count: {content.EpisodeCount} \n" +
                    $"Season Count: {content.SeasonCount} \n" +
                    $"Episode List: ");
                foreach (Episode episode in content.Episodes)
                {
                    Console.WriteLine(episode.Title);
                }

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllContent()
        {
            Console.Clear();

            // Get all of our content
            List<StreamingContent> directory = _streamingRepo.GetAllContents();

            // Go through each item and display its properties
            foreach (StreamingContent content in directory)
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
