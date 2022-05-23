namespace TravelAgencyWebApp.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Image { get; set; }   
        public string Title { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Price { get; set; }


        public Trip()
        {

        }

        public Trip(int id, string image, string title, string description, string length, string price)
        {
            this.Id = id;
            this.Image = image;
            this.Title = title;
            this.Description = description;
            this.Length = length;
            this.Price = price;
        }


    }
}
