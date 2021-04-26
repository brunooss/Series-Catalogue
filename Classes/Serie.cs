namespace Series
{
    public class Serie : BaseEntity
    {
        public Serie(int id, Gender gender, string title, string description, int releaseYear) 
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.ReleaseYear = releaseYear;
            this.Excluded = false;
        }
        
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int ReleaseYear { get; set; }
        private bool Excluded { get; set; }

        public override string ToString()
        {
            string response = "";
            response += "Gender: " + this.Gender + "\n";
            response += "Title: " + this.Title + "\n";
            response += "Description: " + this.Description + "\n";
            response += "Year of Release: " + this.ReleaseYear + "\n";
            response += "Exluído: " + this.Excluded + "\n";

            return response;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Excluded = true;
        }

        public bool ReturnExcluded()
        {
            return this.Excluded;
        }
    }
}